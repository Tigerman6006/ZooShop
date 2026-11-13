using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ZooShop.Entities;
using ZooShop.Repositories.Interfaces;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace ZooShop
{
    public partial class SaleAddForm : Form
    {
        private readonly ISaleRepository _saleRepository;
        private readonly ISaleItemRepository _saleItemRepository;
        private readonly IProductRepository _productRepository;
        private readonly IAnimalRepository _animalRepository;
        private readonly IProductBatchRepository _batchRepository;

        private readonly List<SaleDraftItem> _draftItems = new();

        private class SaleDraftItem
        {
            public Salable Item { get; set; } = null!;
            public int Quantity { get; set; }
            public decimal Discount { get; set; }

            public decimal UnitPrice => Item.SellingPrice;

            public decimal Total =>
                UnitPrice * Quantity * (1 - Discount / 100m);
        }

        public SaleAddForm(
            ISaleRepository saleRepository,
            ISaleItemRepository saleItemRepository,
            IProductRepository productRepository,
            IAnimalRepository animalRepository,
            IProductBatchRepository batchRepository)
        {
            InitializeComponent();

            _saleRepository = saleRepository;
            _saleItemRepository = saleItemRepository;
            _productRepository = productRepository;
            _animalRepository = animalRepository;
            _batchRepository = batchRepository;

            cmbItemType.SelectedIndex = 0;
            LoadItems();
            UpdateReceipt();
        }

        private void LoadItems()
        {
            if (cmbItemType.SelectedIndex == 0)
            {
                var products = _productRepository.GetAll().ToList();

                cmbItem.DataSource = products;
                cmbItem.DisplayMember = nameof(Product.Name);
                cmbItem.ValueMember = nameof(Product.ProductCode);
            }
            else
            {
                var animals = _animalRepository.GetAvailableAnimals().ToList();

                cmbItem.DataSource = animals;
                cmbItem.DisplayMember = nameof(Animal.Name);
                cmbItem.ValueMember = nameof(Animal.AnimalCode);
            }

            cmbItem.SelectedIndex =
                cmbItem.Items.Count > 0 ? 0 : -1;

            UpdateSelectedItemInfo();
        }

        private void cmbItemType_SelectedIndexChanged(
            object sender, EventArgs e)
        {
            LoadItems();
        }

        private void cmbItem_SelectedIndexChanged(
            object sender, EventArgs e)
        {
            UpdateSelectedItemInfo();
        }

        private void UpdateSelectedItemInfo()
        {
            if (cmbItem.SelectedItem is not Salable item)
            {
                lblPrice.Text = "Цена: —";
                return;
            }

            lblPrice.Text = $"Цена: {item.SellingPrice:C}";

            bool isAnimal = cmbItemType.SelectedIndex == 1;

            nudQuantity.Enabled = !isAnimal;
            nudQuantity.Value = 1;
            nudQuantity.Minimum = 1;
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            if (cmbItem.SelectedItem is not Salable item)
            {
                MessageBox.Show(
                    "Выберите товар или животное.",
                    "Внимание",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            int quantity = cmbItemType.SelectedIndex == 1
                ? 1
                : (int)nudQuantity.Value;

            decimal discount = nudDiscount.Value;

            if (discount < 0 || discount > 100)
            {
                MessageBox.Show("Скидка должна быть от 0 до 100%.",
                    "Проверка данных",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (item is Product product)
            {
                int available = GetAvailableStock(product);

                int alreadyAdded = _draftItems
                    .Where(x => x.Item is Product p &&
                                p.ProductCode == product.ProductCode)
                    .Sum(x => x.Quantity);

                if (alreadyAdded + quantity > available)
                {
                    MessageBox.Show(
                        $"Недостаточно товара на складе. Доступно: {available - alreadyAdded}.",
                        "Недостаточно остатка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }
            }

            if (item is Animal animal &&
                _draftItems.Any(x => x.Item is Animal a &&
                                     a.AnimalCode == animal.AnimalCode))
            {
                MessageBox.Show(
                    "Это животное уже добавлено в чек.",
                    "Внимание",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            _draftItems.Add(new SaleDraftItem
            {
                Item = item,
                Quantity = quantity,
                Discount = discount
            });

            UpdateReceipt();
        }

        private int GetAvailableStock(Product product)
        {
            return _batchRepository
                .GetByProduct(product.ProductCode)
                .Where(batch => batch.ExpirationDate.Date >= DateTime.Today)
                .Sum(batch => batch.RemainingQuantity);
        }

        private void UpdateReceipt()
        {
            dgvSaleItems.Rows.Clear();

            foreach (SaleDraftItem item in _draftItems)
            {
                int rowIndex = dgvSaleItems.Rows.Add(
                    item.Item.Name,
                    item.Quantity,
                    item.UnitPrice,
                    item.Discount,
                    item.Total);

                dgvSaleItems.Rows[rowIndex].Tag = item;
            }

            decimal total = _draftItems.Sum(x => x.Total);
            lblTotal.Text = $"Итого: {total:C}";

            btnCompleteSale.Enabled = _draftItems.Count > 0;
        }

        private void btnRemoveItem_Click(object sender, EventArgs e)
        {
            if (dgvSaleItems.SelectedRows.Count == 0)
                return;

            if (dgvSaleItems.SelectedRows[0].Tag is SaleDraftItem item)
            {
                _draftItems.Remove(item);
                UpdateReceipt();
            }
        }

        private void btnCompleteSale_Click(object sender, EventArgs e)
        {
            if (_draftItems.Count == 0)
                return;

            if (string.IsNullOrWhiteSpace(cmbPaymentMethod.Text))
            {
                MessageBox.Show(
                    "Выберите способ оплаты.",
                    "Проверка данных",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            int total = (int)_draftItems.Sum(x => x.Total);

            DialogResult confirmation = MessageBox.Show(
                $"Оформить продажу на сумму {total:C}?",
                "Подтверждение продажи",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmation != DialogResult.Yes)
                return;

            try
            {
                foreach (var group in _draftItems
                    .Where(x => x.Item is Product)
                    .GroupBy(x => ((Product)x.Item).ProductCode))
                {
                    Product product = (Product)group.First().Item;
                    int required = group.Sum(x => x.Quantity);

                    if (GetAvailableStock(product) < required)
                    {
                        throw new InvalidOperationException(
                            $"Недостаточно остатка товара «{product.Name}».");
                    }
                }

                int receiptNumber = GenerateReceiptNumber();

                var saleItems = new List<SaleItem>();

                foreach (SaleDraftItem draft in _draftItems)
                {
                    int id = GenerateSaleItemNumber();
                    SaleItem saleItem = SaleItem.CreateSaleItem(
                        id,
                        draft.Item,
                        draft.Quantity,
                        draft.UnitPrice,
                        draft.Discount);

                    saleItems.Add(saleItem);
                }

                Sale sale = Sale.CreateSale(
                    receiptNumber,
                    total,
                    cmbPaymentMethod.Text,
                    saleItems);


                _saleRepository.Add(sale);

                foreach (SaleItem item in saleItems)
                    _saleItemRepository.Add(item);

                foreach (var group in _draftItems
                    .Where(x => x.Item is Product)
                    .GroupBy(x => ((Product)x.Item).ProductCode))
                {
                    Product product = (Product)group.First().Item;
                    int quantityToRemove = group.Sum(x => x.Quantity);

                    RemoveFromBatches(product, quantityToRemove);
                }


                MessageBox.Show(
                    $"Продажа №{receiptNumber} успешно оформлена.",
                    "Продажа завершена",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Не удалось оформить продажу.\n{ex.Message}",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void RemoveFromBatches(Product product, int quantity)
        {
            var batches = _batchRepository
                .GetByProduct(product.ProductCode)
                .Where(batch =>
                    batch.RemainingQuantity > 0 &&
                    batch.ExpirationDate.Date >= DateTime.Today)
                .OrderBy(batch => batch.ExpirationDate)
                .ThenBy(batch => batch.ArrivalDate)
                .ToList();

            foreach (ProductBatch batch in batches)
            {
                if (quantity <= 0)
                    break;

                int removed = Math.Min(
                    quantity,
                    batch.RemainingQuantity);

                batch.RemainingQuantity -= removed;
                quantity -= removed;


                _batchRepository.Update(batch);
            }

            if (quantity > 0)
            {
                throw new InvalidOperationException(
                    "Не удалось полностью списать товар из партий.");
            }
        }

        private int GenerateReceiptNumber()
        {
            return _saleRepository.GetAll()
                .Select(sale => sale.ReceiptNumber)
                .DefaultIfEmpty(0)
                .Max() + 1;
        }
        private int GenerateSaleItemNumber()
        {
            return _saleItemRepository.GetAll()
                .Select(item => item.Id)
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
