using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ZooShop;
using ZooShop.Entities;
using ZooShop.Repositories.Interfaces;

namespace ZooShop
{
    public partial class SupplierListForm : Form
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IServiceProvider _serviceProvider;

        private List<Supplier> _suppliers = new();

        public SupplierListForm(
            ISupplierRepository supplierRepository,
            IServiceProvider serviceProvider)
        {
            InitializeComponent();

            _supplierRepository = supplierRepository;
            _serviceProvider = serviceProvider;

            LoadSuppliers();
        }

        private void LoadSuppliers()
        {
            try
            {
                _suppliers = _supplierRepository.GetAll().ToList();
                ApplySearch();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Не удалось загрузить список поставщиков.\n{ex.Message}",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void ApplySearch()
        {
            string search = txtSearch.Text.Trim().ToLowerInvariant();

            var filteredSuppliers = _suppliers.Where(supplier =>
                supplier.SupplierCode.ToString().Contains(search) ||
                (supplier.Name ?? "").ToLowerInvariant().Contains(search) ||
                (supplier.PhoneNumber ?? "").ToLowerInvariant().Contains(search));

            dgvSuppliers.Rows.Clear();

            foreach (Supplier supplier in filteredSuppliers)
            {
                int rowIndex = dgvSuppliers.Rows.Add(
                    supplier.SupplierCode,
                    supplier.Name,
                    supplier.PhoneNumber,
                    supplier.DeliveryLeadTime);

                dgvSuppliers.Rows[rowIndex].Tag = supplier;
            }
        }

        private Supplier? GetSelectedSupplier()
        {
            if (dgvSuppliers.SelectedRows.Count == 0)
                return null;

            return dgvSuppliers.SelectedRows[0].Tag as Supplier;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using var form =
                _serviceProvider.GetRequiredService<SupplierEditForm>();

            if (form.ShowDialog(this) == DialogResult.OK)
                LoadSuppliers();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Supplier? supplier = GetSelectedSupplier();

            if (supplier == null)
            {
                MessageBox.Show(
                    "Выберите поставщика для редактирования.",
                    "Внимание",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            using var form =
                ActivatorUtilities.CreateInstance<SupplierEditForm>(
                    _serviceProvider,
                    supplier);

            if (form.ShowDialog(this) == DialogResult.OK)
                LoadSuppliers();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Supplier? supplier = GetSelectedSupplier();

            if (supplier == null)
            {
                MessageBox.Show(
                    "Выберите поставщика для удаления.",
                    "Внимание",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            DialogResult result = MessageBox.Show(
                $"Удалить поставщика «{supplier.Name}»?",
                "Подтверждение удаления",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            try
            {
                _supplierRepository.Delete(supplier.SupplierCode);
                LoadSuppliers();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Не удалось удалить поставщика.\n{ex.Message}",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            LoadSuppliers();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ApplySearch();
        }

        private void dgvSuppliers_CellDoubleClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                btnEdit_Click(sender, EventArgs.Empty);
        }
    }
}
