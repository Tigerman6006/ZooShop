using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;
using ZooShop;

namespace ZooShop
{
    public partial class MainForm : Form
    {
        private readonly IServiceProvider _serviceProvider;

        public MainForm(IServiceProvider serviceProvider)
        {
            InitializeComponent();

            _serviceProvider = serviceProvider;

            lblDate.Text = DateTime.Now.ToString(
                "dd.MM.yyyy");

            lblStatus.Text = "Система готова к работе";
        }

        private void OpenForm<TForm>()
            where TForm : Form
        {
            try
            {
                var form = _serviceProvider
                    .GetRequiredService<TForm>();

                form.ShowDialog(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Не удалось открыть раздел.\n\n{ex.Message}",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnProducts_Click(
            object sender, EventArgs e)
        {
            OpenForm<ProductListForm>();
        }

        private void btnCategories_Click(
            object sender, EventArgs e)
        {
            OpenForm<ProductCategoryListForm>();
        }

        private void btnAnimals_Click(
            object sender, EventArgs e)
        {
            OpenForm<AnimalListForm>();
        }

        private void btnSuppliers_Click(
            object sender, EventArgs e)
        {
            OpenForm<SupplierListForm>();
        }


        private void btnStockControl_Click(
            object sender, EventArgs e)
        {
            OpenForm<StockControlForm>();
        }

        private void btnReplenishment_Click(
            object sender, EventArgs e)
        {
            OpenForm<ReplenishmentRequestListForm>();
        }


        private void btnSales_Click(
            object sender, EventArgs e)
        {
            OpenForm<SaleListForm>();
        }

        private void btnSalesReport_Click(
            object sender, EventArgs e)
        {
            OpenForm<SalesReportForm>();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void MainForm_FormClosing(
            object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                var result = MessageBox.Show(
                    "Закрыть приложение?",
                    "Подтверждение выхода",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }
    }
}


