using System;
using System.Linq;
using System.Windows.Forms;
using ZooShop.Entities;
using ZooShop.Repositories.Interfaces;

namespace ZooShop
{
    public partial class ProductBatchAddForm : Form
    {
        private readonly IProductBatchRepository _batchRepository;
        private readonly IProductRepository _productRepository;
        private readonly ISupplierRepository _supplierRepository;

        public ProductBatchAddForm(
            IProductBatchRepository batchRepository,
            IProductRepository productRepository,
            ISupplierRepository supplierRepository)
        {
            InitializeComponent();

            _batchRepository = batchRepository;
            _productRepository = productRepository;
            _supplierRepository = supplierRepository;

            LoadProducts();
            LoadSuppliers();

            dtpArrivalDate.Value = DateTime.Today;
            dtpExpirationDate.Value = DateTime.Today.AddMonths(6);
        }

        private void LoadProducts()
        {
            var products = _productRepository.GetAll().ToList();

            cmbProduct.DataSource = products;
            cmbProduct.DisplayMember = nameof(Product.Name);
            cmbProduct.ValueMember = nameof(Product.ProductCode);
            cmbProduct.SelectedIndex = products.Count > 0 ? 0 : -1;
        }

        private void LoadSuppliers()
        {
            var suppliers = _supplierRepository.GetAll().ToList();

            cmbSupplier.DataSource = suppliers;
            cmbSupplier.DisplayMember = nameof(Supplier.Name);
            cmbSupplier.ValueMember = nameof(Supplier.SupplierCode);
            cmbSupplier.SelectedIndex = suppliers.Count > 0 ? 0 : -1;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbProduct.SelectedItem is not Product product)
            {
                MessageBox.Show(
                    "Выберите товар.",
                    "Проверка данных",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (cmbSupplier.SelectedItem is not Supplier supplier)
            {
                MessageBox.Show(
                    "Выберите поставщика.",
                    "Проверка данных",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            DateTime arrivalDate = dtpArrivalDate.Value.Date;
            DateTime expirationDate = dtpExpirationDate.Value.Date;

            if (expirationDate <= arrivalDate)
            {
                MessageBox.Show(
                    "Дата истечения срока годности должна быть позже даты поступления.",
                    "Проверка данных",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            try
            {

                int batchNumber = GenerateBatchNumber();

                ProductBatch batch = ProductBatch.CreateBatch(
                    batchNumber,
                    arrivalDate,
                    expirationDate,
                    (int)nudQuantity.Value,
                    product,
                    supplier);

                _batchRepository.Add(batch);

                MessageBox.Show(
                    "Партия успешно зарегистрирована.",
                    "Готово",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Не удалось зарегистрировать партию.\n{ex.Message}",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private int GenerateBatchNumber()
        {
            return _batchRepository.GetAll()
                .Select(batch => batch.BatchNumber)
                .DefaultIfEmpty(0)
                .Max() + 1;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
