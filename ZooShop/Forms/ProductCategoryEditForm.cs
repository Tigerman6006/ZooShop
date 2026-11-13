using System;
using System.Windows.Forms;
using ZooShop.Entities;
using ZooShop.Repositories.Interfaces;

namespace ZooShop
{
    public partial class ProductCategoryEditForm : Form
    {
        private readonly IProductCategoryRepository _categoryRepository;
        private readonly ProductCategory? _editingCategory;

        public ProductCategoryEditForm(
            IProductCategoryRepository categoryRepository,
            ProductCategory? category = null)
        {
            InitializeComponent();

            _categoryRepository = categoryRepository;
            _editingCategory = category;

            LoadCategoryData();

            Text = _editingCategory == null
                ? "Добавление категории"
                : "Редактирование категории";
        }

        private void LoadCategoryData()
        {
            if (_editingCategory == null)
            {
                nudCategoryCode.Value = 1;
                return;
            }

            nudCategoryCode.Value = _editingCategory.CategoryCode;
            txtCategoryName.Text = _editingCategory.CategoryName;

            // Код существующей категории менять нельзя.
            nudCategoryCode.Enabled = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
                return;

            try
            {
                if (_editingCategory == null)
                {
                    ProductCategory category =
                        ProductCategory.CreateCategory(
                            (int)nudCategoryCode.Value,
                            txtCategoryName.Text.Trim()
                        );

                    _categoryRepository.Add(category);
                }
                else
                {
                    _editingCategory.CategoryName =
                        txtCategoryName.Text.Trim();

                    _categoryRepository.Update(_editingCategory);
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Не удалось сохранить категорию.\n{ex.Message}",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtCategoryName.Text))
            {
                MessageBox.Show(
                    "Введите название категории.",
                    "Проверка данных",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtCategoryName.Focus();
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

