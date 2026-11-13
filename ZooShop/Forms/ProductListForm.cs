
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
    public partial class ProductListForm : Form
    {
        private readonly IProductRepository _productRepository;
        private readonly IServiceProvider _serviceProvider;

        private List<Product> _products = new();

        public ProductListForm(
            IProductRepository productRepository,
            IServiceProvider serviceProvider)
        {
            InitializeComponent();

            _productRepository = productRepository;
            _serviceProvider = serviceProvider;

            ConfigureGrid();
            LoadProducts();
        }

        // Настройка таблицы.
        private void ConfigureGrid()
        {
            dgvProducts.AutoGenerateColumns = false;
            dgvProducts.AllowUserToAddRows = false;
            dgvProducts.AllowUserToDeleteRows = false;
            dgvProducts.ReadOnly = true;
            dgvProducts.MultiSelect = false;
            dgvProducts.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvProducts.Columns.Clear();

            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ProductCode",
                HeaderText = "Код",
                DataPropertyName = "ProductCode",
                Width = 65
            });

            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Name",
                HeaderText = "Название",
                DataPropertyName = "Name",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "PurchasePrice",
                HeaderText = "Закупочная цена",
                DataPropertyName = "PurchasePrice",
                Width = 120
            });

            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "SellingPrice",
                HeaderText = "Цена продажи",
                DataPropertyName = "SellingPrice",
                Width = 110
            });

            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ExpirationDate",
                HeaderText = "Срок годности",
                Width = 120
            });

            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "RemainingStock",
                HeaderText = "Остаток",
                Width = 90
            });
        }

        // Загрузка товаров из репозитория.
        private void LoadProducts()
        {
            try
            {
                _products = _productRepository.GetAll().ToList();

                ApplyFilter();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Не удалось загрузить товары.\n{ex.Message}",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // Поиск по названию и коду.
        private void ApplyFilter()
        {
            string search = txtSearch.Text.Trim()
                .ToLowerInvariant();

            var filteredProducts = _products
                .Where(p =>
                    p.Name.ToLowerInvariant().Contains(search) ||
                    p.ProductCode.ToString().Contains(search))
                .ToList();

            dgvProducts.Rows.Clear();

            foreach (Product product in filteredProducts)
            {
                int remainingStock = product.CalculateRemainingStock();

                int rowIndex = dgvProducts.Rows.Add(
                    product.ProductCode,
                    product.Name,
                    product.PurchasePrice,
                    product.SellingPrice,
                    product.ExpirationDate.ToShortDateString(),
                    remainingStock
                );

                // Сохраняем объект товара в строке.
                dgvProducts.Rows[rowIndex].Tag = product;
            }

            lblCount.Text =
                $"Количество товаров: {filteredProducts.Count}";
        }

        // Получение выбранного товара.
        private Product? GetSelectedProduct()
        {
            if (dgvProducts.SelectedRows.Count == 0)
                return null;

            return dgvProducts.SelectedRows[0].Tag as Product;
        }

        // Добавление товара.
        private void btnAdd_Click(object sender, EventArgs e)
        {
            using ProductEditForm form =
                ActivatorUtilities.CreateInstance<ProductEditForm>(
                    _serviceProvider);

            if (form.ShowDialog(this) == DialogResult.OK)
            {
                LoadProducts();
            }
        }

        // Редактирование товара.
        private void btnEdit_Click(object sender, EventArgs e)
        {
            Product? product = GetSelectedProduct();

            if (product == null)
            {
                MessageBox.Show(
                    "Выберите товар для редактирования.",
                    "Внимание",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            using ProductEditForm form =
                ActivatorUtilities.CreateInstance<ProductEditForm>(
                    _serviceProvider,
                    product);

            if (form.ShowDialog(this) == DialogResult.OK)
            {
                LoadProducts();
            }
        }

        // Удаление товара.
        private void btnDelete_Click(object sender, EventArgs e)
        {
            Product? product = GetSelectedProduct();

            if (product == null)
            {
                MessageBox.Show(
                    "Выберите товар для удаления.",
                    "Внимание",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            DialogResult result = MessageBox.Show(
                $"Удалить товар «{product.Name}»?",
                "Подтверждение удаления",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            try
            {
                _productRepository.Delete(product.ProductCode);
                LoadProducts();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Не удалось удалить товар.\n{ex.Message}",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // Обновление списка.
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadProducts();
        }

        // Поиск при вводе текста.
        private void txtSearch_TextChanged(
            object sender,
            EventArgs e)
        {
            ApplyFilter();
        }

        // Двойной щелчок по строке открывает редактирование.
        private void dgvProducts_CellDoubleClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                btnEdit_Click(sender, e);
        }
    }
}

