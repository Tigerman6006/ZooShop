using System;
using System.Linq;
using System.Windows.Forms;
using ZooShop.Entities;
using ZooShop.Repositories.Interfaces;

namespace ZooShop
{
    public partial class ReplenishmentRequestAddForm : Form
    {
        private readonly IReplenishmentRequestRepository _requestRepository;
        private readonly IProductRepository _productRepository;
        private readonly ISupplierRepository _supplierRepository;

        public ReplenishmentRequestAddForm(
            IReplenishmentRequestRepository requestRepository,
            IProductRepository productRepository,
            ISupplierRepository supplierRepository)
        {
            InitializeComponent();

            _requestRepository = requestRepository;
            _productRepository = productRepository;
            _supplierRepository = supplierRepository;

            LoadProducts();
            LoadSuppliers();
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

            try
            {
                int requestNumber = GenerateRequestNumber();


                ReplenishmentRequest request =
                    ReplenishmentRequest.CreateRequest(
                        (int)nudRequiredQuantity.Value,
                        product);

                request.SendToSupplier(supplier);

                _requestRepository.Add(request);

                MessageBox.Show(
                    "Заявка создана и отправлена поставщику.",
                    "Готово",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Не удалось создать заявку.\n{ex.Message}",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private int GenerateRequestNumber()
        {
            return _requestRepository.GetAll()
                .Select(request => request.RequestNumber)
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
