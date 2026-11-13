
using System;
using System.Windows.Forms;
using ZooShop.Entities;
using ZooShop.Repositories.Interfaces;

namespace ZooShop
{
    public partial class AnimalEditForm : Form
    {
        private readonly IAnimalRepository _animalRepository;
        private readonly Animal? _editingAnimal;

        public AnimalEditForm(
            IAnimalRepository animalRepository,
            Animal? animal = null)
        {
            InitializeComponent();

            _animalRepository = animalRepository;
            _editingAnimal = animal;

            LoadAnimalData();

            Text = _editingAnimal == null
                ? "Добавление животного"
                : "Редактирование животного";
        }

        private void LoadAnimalData()
        {
            if (_editingAnimal == null)
            {
                nudAnimalCode.Value = 1;
                dtpDateOfBirth.Value = DateTime.Today;
                return;
            }

            Animal animal = _editingAnimal;

            nudAnimalCode.Value = animal.AnimalCode;
            txtName.Text = animal.Name;
            txtSpecies.Text = animal.Species;
            txtBreed.Text = animal.Breed;

            nudPurchasePrice.Value = animal.PurchasePrice;
            nudSellingPrice.Value = animal.SellingPrice;

            dtpDateOfBirth.Value = animal.DateOfBirth;


            // Код нельзя менять при редактировании.
            nudAnimalCode.Enabled = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
                return;

            try
            {
                if (_editingAnimal == null)
                {
                    Animal animal = Animal.CreateAnimal(
                        (int)nudAnimalCode.Value,
                        txtName.Text.Trim(),
                        nudPurchasePrice.Value,
                        nudSellingPrice.Value,
                        txtSpecies.Text.Trim(),
                        txtBreed.Text.Trim(),
                        dtpDateOfBirth.Value
                    );

                    animal.PurchasePrice = nudPurchasePrice.Value;
                    animal.SellingPrice = nudSellingPrice.Value;

                    _animalRepository.Add(animal);
                }
                else
                {
                    _editingAnimal.Name = txtName.Text.Trim();
                    _editingAnimal.Species = txtSpecies.Text.Trim();
                    _editingAnimal.Breed = txtBreed.Text.Trim();

                    _editingAnimal.DateOfBirth = dtpDateOfBirth.Value;

                    _editingAnimal.PurchasePrice = nudPurchasePrice.Value;
                    _editingAnimal.SellingPrice = nudSellingPrice.Value;

                    _animalRepository.Update(_editingAnimal);
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Не удалось сохранить животное.\n{ex.Message}",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Введите кличку животного.");
                txtName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtSpecies.Text))
            {
                MessageBox.Show("Укажите вид животного.");
                txtSpecies.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtBreed.Text))
            {
                MessageBox.Show("Укажите породу животного.");
                txtBreed.Focus();
                return false;
            }

            if (dtpDateOfBirth.Value.Date > DateTime.Today)
            {
                MessageBox.Show("Дата рождения не может быть в будущем.");
                return false;
            }

            if (nudSellingPrice.Value < nudPurchasePrice.Value)
            {
                DialogResult result = MessageBox.Show(
                    "Цена продажи ниже закупочной. Продолжить?",
                    "Проверка цены",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result != DialogResult.Yes)
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

