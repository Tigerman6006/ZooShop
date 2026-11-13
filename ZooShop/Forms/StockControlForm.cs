using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Windows.Forms;
using ZooShop;
using ZooShop.Entities;
using ZooShop.Repositories.Interfaces;

namespace ZooShop
{
    public partial class StockControlForm : Form
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductBatchRepository _batchRepository;
        private readonly IServiceProvider _serviceProvider;

        public StockControlForm(
            IProductRepository productRepository,
            IProductBatchRepository batchRepository,
            IServiceProvider serviceProvider)
        {
            InitializeComponent();

            _productRepository = productRepository;
            _batchRepository = batchRepository;
            _serviceProvider = serviceProvider;

            LoadStock();
        }

        private void LoadStock()
        {
            try
            {
                var products = _productRepository.GetAll().ToList();

                dgvStock.Rows.Clear();

                foreach (Product product in products)
                {
                    int currentStock = _batchRepository
                        .GetByProduct(product.ProductCode)
                        .Sum(batch => batch.RemainingQuantity);

                    int minimum = product.StockNorm?.MinimumStockLevel ?? 0;
                    int maximum = product.StockNorm?.MaximumStockLevel ?? 0;

                    string status;

                    if (product.StockNorm == null)
                    {
                        status = "Норма не задана";
                    }
                    else if (currentStock < minimum)
                    {
                        status = "Нужно пополнение";
                    }
                    else if (currentStock > maximum)
                    {
                        status = "Выше нормы";
                    }
                    else
                    {
                        status = "В норме";
                    }

                    int rowIndex = dgvStock.Rows.Add(
                        product.ProductCode,
                        product.Name,
                        currentStock,
                        minimum,
                        maximum,
                        status);

                    dgvStock.Rows[rowIndex].Tag = product;

                    if (status == "Нужно пополнение")
                    {
                        dgvStock.Rows[rowIndex].DefaultCellStyle.BackColor =
                            System.Drawing.Color.MistyRose;
                    }
                    else if (status == "Норма не задана")
                    {
                        dgvStock.Rows[rowIndex].DefaultCellStyle.BackColor =
                            System.Drawing.Color.LightYellow;
                    }
                }

                UpdateSummary();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Не удалось выполнить проверку запасов.\n{ex.Message}",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void UpdateSummary()
        {
            int total = dgvStock.Rows.Count;
            int lowStock = 0;
            int missingNorm = 0;

            foreach (DataGridViewRow row in dgvStock.Rows)
            {
                string status = Convert.ToString(
                    row.Cells["Status"].Value) ?? "";

                if (status == "Нужно пополнение")
                    lowStock++;

                if (status == "Норма не задана")
                    missingNorm++;
            }

            lblSummary.Text =
                $"Всего товаров: {total} | " +
                $"Требуют пополнения: {lowStock} | " +
                $"Без нормы: {missingNorm}";
        }

        private Product? GetSelectedProduct()
        {
            if (dgvStock.SelectedRows.Count == 0)
                return null;

            return dgvStock.SelectedRows[0].Tag as Product;
        }

        private void btnSetNorm_Click(object sender, EventArgs e)
        {
            Product? product = GetSelectedProduct();

            if (product == null)
            {
                MessageBox.Show(
                    "Выберите товар.",
                    "Внимание",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            using var form =
                ActivatorUtilities.CreateInstance<StockNormEditForm>(
                    _serviceProvider,
                    product);

            if (form.ShowDialog(this) == DialogResult.OK)
                LoadStock();
        }

        private void btnCreateRequest_Click(object sender, EventArgs e)
        {
            Product? product = GetSelectedProduct();

            if (product == null)
            {
                MessageBox.Show(
                    "Выберите товар, для которого нужно создать заявку.",
                    "Внимание",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            using var form =
                _serviceProvider.GetRequiredService<
                    ReplenishmentRequestAddForm>();

            if (form.ShowDialog(this) == DialogResult.OK)
                LoadStock();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadStock();
        }

        private void chkOnlyLowStock_CheckedChanged(
            object sender,
            EventArgs e)
        {
            foreach (DataGridViewRow row in dgvStock.Rows)
            {
                string status = Convert.ToString(
                    row.Cells["Status"].Value) ?? "";

                row.Visible = !chkOnlyLowStock.Checked ||
                              status == "Нужно пополнение";
            }

            UpdateSummary();
        }
    }
}
