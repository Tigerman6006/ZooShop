using System;
using System.Windows.Forms;
using ZooShop.Entities;
using ZooShop.Repositories.Interfaces;

namespace ZooShop
{
    public partial class StockNormEditForm : Form
    {
        private readonly IProductRepository _productRepository;
        private readonly Product _product;

        public StockNormEditForm(
            IProductRepository productRepository,
            Product product)
        {
            InitializeComponent();

            _productRepository = productRepository;
            _product = product;

            lblProductName.Text = $"Товар: {_product.Name}";

            LoadNorm();
        }

        private void LoadNorm()
        {
            if (_product.StockNorm == null)
                return;

            nudMinimumStock.Value =
                Math.Max(0, _product.StockNorm.MinimumStockLevel);

            nudMaximumStock.Value =
                Math.Max(nudMinimumStock.Value,
                    _product.StockNorm.MaximumStockLevel);

            nudReviewPeriod.Value =
                Math.Max(1, _product.StockNorm.ReviewPeriod);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int minimum = (int)nudMinimumStock.Value;
            int maximum = (int)nudMaximumStock.Value;
            int reviewPeriod = (int)nudReviewPeriod.Value;

            if (maximum < minimum)
            {
                MessageBox.Show(
                    "Максимальный запас не может быть меньше минимального.",
                    "Проверка данных",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            try
            {
                StockNorm norm = _product.StockNorm ?? StockNorm.CreateStockNorm(minimum, maximum, reviewPeriod);

                norm.MinimumStockLevel = minimum;
                norm.MaximumStockLevel = maximum;
                norm.ReviewPeriod = reviewPeriod;

                _product.StockNorm = norm;

                _productRepository.Update(_product);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Не удалось сохранить норму запаса.\n{ex.Message}",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}