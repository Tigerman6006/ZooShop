using System;
using System.Windows.Forms;
using System.Xml.Linq;
using ZooShop.Entities;
using ZooShop.Repositories.Interfaces;

namespace ZooShop
{
    public partial class SupplierEditForm : Form
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly Supplier? _supplier;

        public SupplierEditForm(ISupplierRepository supplierRepository)
            : this(supplierRepository, null)
        {
        }

        public SupplierEditForm(
            ISupplierRepository supplierRepository,
            Supplier? supplier)
        {
            InitializeComponent();

            _supplierRepository = supplierRepository;
            _supplier = supplier;

            if (_supplier != null)
            {
                Text = "Редактирование поставщика";
                LoadSupplierData();
            }
            else
            {
                Text = "Добавление поставщика";
            }
        }

        private void LoadSupplierData()
        {
            if (_supplier == null)
                return;

            nudSupplierCode.Value = _supplier.SupplierCode;
            txtName.Text = _supplier.Name;
            txtPhoneNumber.Text = _supplier.PhoneNumber;
            nudDeliveryLeadTime.Value = _supplier.DeliveryLeadTime;

            // Код существующего поставщика не редактируем.
            nudSupplierCode.Enabled = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string phoneNumber = txtPhoneNumber.Text.Trim();

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show(
                    "Введите название поставщика.",
                    "Проверка данных",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtName.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(phoneNumber))
            {
                MessageBox.Show(
                    "Введите номер телефона поставщика.",
                    "Проверка данных",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtPhoneNumber.Focus();
                return;
            }

            try
            {
                if (_supplier == null)
                {
                    Supplier newSupplier = Supplier.CreateSupplier(
                        (int)nudSupplierCode.Value,
                        name,
                        phoneNumber,
                        (int)nudDeliveryLeadTime.Value);

                    _supplierRepository.Add(newSupplier);
                }
                else
                {
                    _supplier.Name = name;
                    _supplier.PhoneNumber = phoneNumber;
                    _supplier.DeliveryLeadTime =
                        (int)nudDeliveryLeadTime.Value;

                    _supplierRepository.Update(_supplier);
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Не удалось сохранить поставщика.\n{ex.Message}",
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
