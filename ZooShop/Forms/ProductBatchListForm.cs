using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Windows.Forms;
using ZooShop;
using ZooShop.Entities;
using ZooShop.Repositories.Interfaces;

namespace ZooShop
{
    public partial class ProductBatchListForm : Form
    {
        private readonly IProductBatchRepository _batchRepository;
        private readonly IServiceProvider _serviceProvider;

        public ProductBatchListForm(
            IProductBatchRepository batchRepository,
            IServiceProvider serviceProvider)
        {
            InitializeComponent();

            _batchRepository = batchRepository;
            _serviceProvider = serviceProvider;

            LoadBatches();
        }

        private void LoadBatches()
        {
            try
            {
                var batches = _batchRepository.GetAll().ToList();

                string search = txtSearch.Text.Trim()
                    .ToLowerInvariant();

                if (!string.IsNullOrWhiteSpace(search))
                {
                    batches = batches.Where(batch =>
                        batch.BatchNumber.ToString().Contains(search) ||
                        (batch.Products?.Name ?? "")
                            .ToLowerInvariant().Contains(search) ||
                        (batch.Supplier?.Name ?? "")
                            .ToLowerInvariant().Contains(search))
                        .ToList();
                }

                if (chkOnlyAvailable.Checked)
                {
                    batches = batches
                        .Where(batch => batch.RemainingQuantity > 0)
                        .ToList();
                }

                dgvBatches.Rows.Clear();

                foreach (ProductBatch batch in batches)
                {
                    bool expired = batch.ExpirationDate.Date < DateTime.Today;

                    int rowIndex = dgvBatches.Rows.Add(
                        batch.BatchNumber,
                        batch.Products?.Name ?? "Не указан",
                        batch.Supplier?.Name ?? "Не указан",
                        batch.ArrivalDate.ToShortDateString(),
                        batch.ExpirationDate.ToShortDateString(),
                        batch.QuantityReceived,
                        batch.RemainingQuantity,
                        expired ? "Просрочена" : "Действительна");

                    dgvBatches.Rows[rowIndex].Tag = batch;

                    if (expired)
                    {
                        dgvBatches.Rows[rowIndex].DefaultCellStyle.BackColor =
                            System.Drawing.Color.MistyRose;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Не удалось загрузить партии.\n{ex.Message}",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using var form =
                _serviceProvider.GetRequiredService<ProductBatchAddForm>();

            if (form.ShowDialog(this) == DialogResult.OK)
                LoadBatches();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            chkOnlyAvailable.Checked = false;
            LoadBatches();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadBatches();
        }

        private void chkOnlyAvailable_CheckedChanged(
            object sender,
            EventArgs e)
        {
            LoadBatches();
        }
    }
}
