using Microsoft.Extensions.DependencyInjection;
using System;
using System;
using System.Collections.Generic;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ZooShop;
using ZooShop.Entities;
using ZooShop.Repositories.Interfaces;

namespace ZooShop
{
    public partial class AnimalListForm : Form
    {
        private readonly IAnimalRepository _animalRepository;
        private readonly IServiceProvider _serviceProvider;

        private List<Animal> _animals = new();

        public AnimalListForm(
            IAnimalRepository animalRepository,
            IServiceProvider serviceProvider)
        {
            InitializeComponent();

            _animalRepository = animalRepository;
            _serviceProvider = serviceProvider;

            ConfigureGrid();
            LoadAnimals();
        }

        private void ConfigureGrid()
        {
            dgvAnimals.AutoGenerateColumns = false;
            dgvAnimals.AllowUserToAddRows = false;
            dgvAnimals.AllowUserToDeleteRows = false;
            dgvAnimals.ReadOnly = true;
            dgvAnimals.MultiSelect = false;
            dgvAnimals.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvAnimals.Columns.Clear();

            dgvAnimals.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "AnimalCode",
                HeaderText = "Код",
                Width = 65
            });

            dgvAnimals.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Name",
                HeaderText = "Кличка",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgvAnimals.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Species",
                HeaderText = "Вид",
                Width = 110
            });

            dgvAnimals.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Breed",
                HeaderText = "Порода",
                Width = 130
            });

            dgvAnimals.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "DateOfBirth",
                HeaderText = "Дата рождения",
                Width = 120
            });

            dgvAnimals.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "SellingPrice",
                HeaderText = "Цена",
                Width = 100
            });
        }

        private void LoadAnimals()
        {
            try
            {
                _animals = _animalRepository.GetAll().ToList();
                ApplyFilter();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Не удалось загрузить животных.\n{ex.Message}",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void ApplyFilter()
        {
            string search = txtSearch.Text.Trim()
                .ToLowerInvariant();

            var filteredAnimals = _animals
                .Where(a =>
                    a.Name.ToLowerInvariant().Contains(search) ||
                    a.Species.ToLowerInvariant().Contains(search) ||
                    a.Breed.ToLowerInvariant().Contains(search) ||
                    a.AnimalCode.ToString().Contains(search))
                .ToList();

            dgvAnimals.Rows.Clear();

            foreach (Animal animal in filteredAnimals)
            {
                int rowIndex = dgvAnimals.Rows.Add(
                    animal.AnimalCode,
                    animal.Name,
                    animal.Species,
                    animal.Breed,
                    animal.DateOfBirth.ToShortDateString(),
                    animal.SellingPrice
                );

                dgvAnimals.Rows[rowIndex].Tag = animal;
            }

            lblCount.Text =
                $"Количество животных: {filteredAnimals.Count}";
        }

        private Animal? GetSelectedAnimal()
        {
            if (dgvAnimals.SelectedRows.Count == 0)
                return null;

            return dgvAnimals.SelectedRows[0].Tag as Animal;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using AnimalEditForm form =
                ActivatorUtilities.CreateInstance<AnimalEditForm>(
                    _serviceProvider);

            if (form.ShowDialog(this) == DialogResult.OK)
                LoadAnimals();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Animal? animal = GetSelectedAnimal();

            if (animal == null)
            {
                MessageBox.Show("Выберите животное для редактирования.");
                return;
            }

            using AnimalEditForm form =
                ActivatorUtilities.CreateInstance<AnimalEditForm>(
                    _serviceProvider,
                    animal);

            if (form.ShowDialog(this) == DialogResult.OK)
                LoadAnimals();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Animal? animal = GetSelectedAnimal();

            if (animal == null)
            {
                MessageBox.Show("Выберите животное для удаления.");
                return;
            }

            

            DialogResult result = MessageBox.Show(
                $"Удалить животное «{animal.Name}»?",
                "Подтверждение удаления",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            try
            {
                _animalRepository.Delete(animal.AnimalCode);
                LoadAnimals();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Не удалось удалить животное.\n{ex.Message}",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadAnimals();
        }

        private void txtSearch_TextChanged(
            object sender,
            EventArgs e)
        {
            ApplyFilter();
        }

        private void dgvAnimals_CellDoubleClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                btnEdit_Click(sender, e);
        }
    }
}

