using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Windows.Forms;
using ZooShop;
using ZooShop.Entities;
using ZooShop.Repositories.Interfaces;

namespace ZooShop
{
    public partial class SaleListForm : Form
    {
        private readonly ISaleRepository _saleRepository;
        private readonly ISaleItemRepository _saleItemRepository;
        private readonly IServiceProvider _serviceProvider;

        public SaleListForm(
            ISaleRepository saleRepository,
            ISaleItemRepository saleItemRepository,
            IServiceProvider serviceProvider)
        {
            InitializeComponent();

            _saleRepository = saleRepository;
            _saleItemRepository = saleItemRepository;
            _serviceProvider = serviceProvider;

            dtpStartDate.Value = DateTime.Today.AddMonths(-1);
            dtpEndDate.Value = DateTime.Today;

            LoadSales();
        }

        private void LoadSales()
        {
            try
            {
                DateTime start = dtpStartDate.Value.Date;
                DateTime end = dtpEndDate.Value.Date;

                if (end < start)
                {
                    MessageBox.Show(
                        "Конечная дата не может быть раньше начальной.",
                        "Проверка дат",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                var sales = _saleRepository
                    .GetByPeriod(start, end.AddDays(1).AddTicks(-1))
                    .ToList();

                string search = txtSearch.Text.Trim()
                    .ToLowerInvariant();

                if (!string.IsNullOrWhiteSpace(search))
                {
                    sales = sales.Where(sale =>
                        sale.ReceiptNumber.ToString().Contains(search) ||
                        sale.PaymentMethod.ToLowerInvariant().Contains(search))
                        .ToList();
                }

                dgvSales.Rows.Clear();

                foreach (Sale sale in sales.OrderByDescending(x => x.SaleDate))
                {
                    int rowIndex = dgvSales.Rows.Add(
                        sale.ReceiptNumber,
                        sale.SaleDate.ToString("dd.MM.yyyy HH:mm"),
                        sale.Amount,
                        sale.PaymentMethod);

                    dgvSales.Rows[rowIndex].Tag = sale;
                }

                lblSalesCount.Text = $"Количество чеков: {sales.Count}";
                lblSalesTotal.Text =
                    $"Общая сумма: {sales.Sum(x => x.Amount):C}";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Не удалось загрузить продажи.\n{ex.Message}",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private Sale? GetSelectedSale()
        {
            if (dgvSales.SelectedRows.Count == 0)
                return null;

            return dgvSales.SelectedRows[0].Tag as Sale;
        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
            Sale? sale = GetSelectedSale();

            if (sale == null)
            {
                MessageBox.Show(
                    "Выберите чек.",
                    "Внимание",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            var items = _saleItemRepository
                .GetBySale(sale.ReceiptNumber)
                .ToList();

            if (items.Count == 0)
            {
                MessageBox.Show(
                    "В этом чеке нет сохранённых позиций.",
                    "Состав чека",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            var details = new System.Text.StringBuilder();

            details.AppendLine($"Чек №{sale.ReceiptNumber}");
            details.AppendLine($"Дата: {sale.SaleDate:g}");
            details.AppendLine("--------------------------------");

            foreach (SaleItem item in items)
            {
                details.AppendLine(
                    $"{item.Salable.Name} — {item.Quantity} шт. × {item.Price:C}");

                details.AppendLine($"Скидка: {item.Discount}%");
            }

            details.AppendLine("--------------------------------");
            details.AppendLine($"Итого: {sale.Amount:C}");

            MessageBox.Show(
                details.ToString(),
                "Состав чека",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            LoadSales();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using var form =
                _serviceProvider.GetRequiredService<SaleAddForm>();

            if (form.ShowDialog(this) == DialogResult.OK)
                LoadSales();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadSales();
        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            LoadSales();
        }
    }
}
