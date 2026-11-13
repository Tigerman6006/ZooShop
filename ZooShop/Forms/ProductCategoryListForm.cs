
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
    public partial class ProductCategoryListForm : Form
    {
        private readonly IProductCategoryRepository _categoryRepository;
        private readonly IServiceProvider _serviceProvider;

        private List<ProductCategory> _categories = new();

        public ProductCategoryListForm(
            IProductCategoryRepository categoryRepository,
            IServiceProvider serviceProvider)
        {
            InitializeComponent();

            _categoryRepository = categoryRepository;
            _serviceProvider = serviceProvider;

            ConfigureGrid();
            LoadCategories();
        }

        private void ConfigureGrid()
        {
            dgvCategories.AutoGenerateColumns = false;
            dgvCategories.AllowUserToAddRows = false;
            dgvCategories.AllowUserToDeleteRows = false;
            dgvCategories.ReadOnly = true;
            dgvCategories.MultiSelect = false;
            dgvCategories.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvCategories.Columns.Clear();

            dgvCategories.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CategoryCode",
                HeaderText = "Код",
                Width = 100
            });

            dgvCategories.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CategoryName",
                HeaderText = "Название категории",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgvCategories.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ProductsCount",
                HeaderText = "Количество товаров",
                Width = 160
            });
        }

        private void LoadCategories()
        {
            try
            {
                _categories = _categoryRepository.GetAll().ToList();

                ApplyFilter();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Не удалось загрузить категории.\n{ex.Message}",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void ApplyFilter()
        {
            string search = txtSearch.Text.Trim()
                .ToLowerInvariant();

            var filteredCategories = _categories
                .Where(c =>
                    c.CategoryName.ToLowerInvariant().Contains(search) ||
                    c.CategoryCode.ToString().Contains(search))
                .ToList();

            dgvCategories.Rows.Clear();

            foreach (ProductCategory category in filteredCategories)
            {
                int productsCount = category.Products?.Count ?? 0;

                int rowIndex = dgvCategories.Rows.Add(
                    category.CategoryCode,
                    category.CategoryName,
                    productsCount
                );

                dgvCategories.Rows[rowIndex].Tag = category;
            }

            lblCount.Text =
                $"Количество категорий: {filteredCategories.Count}";
        }

        private ProductCategory? GetSelectedCategory()
        {
            if (dgvCategories.SelectedRows.Count == 0)
                return null;

            return dgvCategories.SelectedRows[0].Tag
                as ProductCategory;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using ProductCategoryEditForm form =
                ActivatorUtilities.CreateInstance<ProductCategoryEditForm>(
                    _serviceProvider);

            if (form.ShowDialog(this) == DialogResult.OK)
                LoadCategories();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            ProductCategory? category = GetSelectedCategory();

            if (category == null)
            {
                MessageBox.Show("Выберите категорию для редактирования.");
                return;
            }

            using ProductCategoryEditForm form =
                ActivatorUtilities.CreateInstance<ProductCategoryEditForm>(
                    _serviceProvider,
                    category);

            if (form.ShowDialog(this) == DialogResult.OK)
                LoadCategories();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            ProductCategory? category = GetSelectedCategory();

            if (category == null)
            {
                MessageBox.Show("Выберите категорию для удаления.");
                return;
            }

            if (category.Products != null &&
                category.Products.Count > 0)
            {
                MessageBox.Show(
                    "Нельзя удалить категорию, в которой есть товары.\n" +
                    "Сначала перенесите товары в другую категорию.",
                    "Удаление запрещено",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            DialogResult result = MessageBox.Show(
                $"Удалить категорию «{category.CategoryName}»?",
                "Подтверждение удаления",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            try
            {
                _categoryRepository.Delete(category.CategoryCode);
                LoadCategories();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Не удалось удалить категорию.\n{ex.Message}",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadCategories();
        }

        private void txtSearch_TextChanged(
            object sender,
            EventArgs e)
        {
            ApplyFilter();
        }

        private void dgvCategories_CellDoubleClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                btnEdit_Click(sender, e);
        }
    }
}

