
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using ZooShop.Entities;
using ZooShop.Enums;
using ZooShop.Repositories.Interfaces;

namespace ZooShop
{
    public partial class ProductEditForm : Form
    {
        private readonly IProductRepository _productRepository;
        private readonly Product? _editingProduct;

        public ProductEditForm(
            IProductRepository productRepository,
            Product? product = null)
        {
            InitializeComponent();

            _productRepository = productRepository;
            _editingProduct = product;

            LoadSpecialRequirements();
            LoadProductData();

            Text = _editingProduct == null
                ? "Добавление товара"
                : "Редактирование товара";
        }

        private void LoadSpecialRequirements()
        {
            clbSpecialRequirements.Items.Clear();

            foreach (SpecialRequirements requirement
                     in Enum.GetValues(typeof(SpecialRequirements)))
            {
                if (requirement == SpecialRequirements.None)
                    continue;

                clbSpecialRequirements.Items.Add(requirement);
            }
        }

        private void LoadProductData()
        {
            if (_editingProduct == null)
            {
                nudProductCode.Value = 1;
                dtpExpirationDate.Value = DateTime.Today.AddMonths(6);
                return;
            }

            Product product = _editingProduct;

            nudProductCode.Value = product.ProductCode;
            txtName.Text = product.Name;

            nudPurchasePrice.Value = product.PurchasePrice;
            nudSellingPrice.Value = product.SellingPrice;

            dtpExpirationDate.Value = product.ExpirationDate;

            nudMinimumStock.Value =
                product.StockNorm.MinimumStockLevel;

            nudMaximumStock.Value =
                product.StockNorm.MaximumStockLevel;

            nudReviewPeriod.Value =
                product.StockNorm.ReviewPeriod;

            nudTemperature.Value =
    (decimal)product.StorageConditions.Temperature;

            nudHumidity.Value =
                (decimal)product.StorageConditions.Humidity;

            SpecialRequirements selected =
                product.StorageConditions.SpecialRequirements;

            for (int i = 0; i < clbSpecialRequirements.Items.Count; i++)
            {
                SpecialRequirements item =
                    (SpecialRequirements)clbSpecialRequirements.Items[i];

                clbSpecialRequirements.SetItemChecked(
                    i,
                    selected.HasFlag(item));
            }

            // Код товара при редактировании менять нельзя.
            nudProductCode.Enabled = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
                return;

            try
            {
                StockNorm stockNorm = StockNorm.CreateStockNorm((int)nudMinimumStock.Value,(int)nudMaximumStock.Value,(int)nudReviewPeriod.Value);

                SpecialRequirements requirements =
                    SpecialRequirements.None;

                foreach (var item in clbSpecialRequirements.CheckedItems)
                {
                    requirements |= (SpecialRequirements)item;
                }

                StorageConditions storageConditions = StorageConditions.CreateConditions((double)nudTemperature.Value,(double)nudHumidity.Value,requirements);

                if (_editingProduct == null)
                {
                    Product product = Product.CreateProduct(
                        (int)nudProductCode.Value,
                        txtName.Text.Trim(),
                        nudPurchasePrice.Value,
                        nudSellingPrice.Value,
                        stockNorm,
                        storageConditions
                    );

                    product.ExpirationDate = dtpExpirationDate.Value;

                    _productRepository.Add(product);
                }
                else
                {
                    _editingProduct.Name = txtName.Text.Trim();
                    _editingProduct.PurchasePrice = nudPurchasePrice.Value;
                    _editingProduct.SellingPrice = nudSellingPrice.Value;
                    _editingProduct.ExpirationDate = dtpExpirationDate.Value;

                    _editingProduct.StockNorm = stockNorm;
                    _editingProduct.StorageConditions = storageConditions;

                    _productRepository.Update(_editingProduct);
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Не удалось сохранить товар.\n{ex.Message}",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show(
                    "Введите название товара.",
                    "Проверка данных",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtName.Focus();
                return false;
            }

            if (nudSellingPrice.Value < nudPurchasePrice.Value)
            {
                DialogResult result = MessageBox.Show(
                    "Цена продажи ниже закупочной цены. Продолжить?",
                    "Проверка цены",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result != DialogResult.Yes)
                    return false;
            }

            if (nudMinimumStock.Value > nudMaximumStock.Value)
            {
                MessageBox.Show(
                    "Минимальный остаток не может быть больше максимального.",
                    "Проверка данных",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return false;
            }

            if (dtpExpirationDate.Value.Date < DateTime.Today)
            {
                MessageBox.Show(
                    "Срок годности не может быть в прошлом.",
                    "Проверка данных",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return false;
            }

            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}

