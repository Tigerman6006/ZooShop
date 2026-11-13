using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace ZooShop
{
    partial class SaleAddForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblItemType;
        private System.Windows.Forms.Label lblItem;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.Label lblDiscount;
        private System.Windows.Forms.Label lblPaymentMethod;
        private System.Windows.Forms.Label lblTotal;

        private System.Windows.Forms.ComboBox cmbItemType;
        private System.Windows.Forms.ComboBox cmbItem;
        private System.Windows.Forms.ComboBox cmbPaymentMethod;

        private System.Windows.Forms.NumericUpDown nudQuantity;
        private System.Windows.Forms.NumericUpDown nudDiscount;

        private System.Windows.Forms.DataGridView dgvSaleItems;

        private System.Windows.Forms.Button btnAddItem;
        private System.Windows.Forms.Button btnRemoveItem;
        private System.Windows.Forms.Button btnCompleteSale;
        private System.Windows.Forms.Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblItemType = new System.Windows.Forms.Label();
            lblItem = new System.Windows.Forms.Label();
            lblPrice = new System.Windows.Forms.Label();
            lblQuantity = new System.Windows.Forms.Label();
            lblDiscount = new System.Windows.Forms.Label();
            lblPaymentMethod = new System.Windows.Forms.Label();
            lblTotal = new System.Windows.Forms.Label();

            cmbItemType = new System.Windows.Forms.ComboBox();
            cmbItem = new System.Windows.Forms.ComboBox();
            cmbPaymentMethod = new System.Windows.Forms.ComboBox();

            nudQuantity = new System.Windows.Forms.NumericUpDown();
            nudDiscount = new System.Windows.Forms.NumericUpDown();

            dgvSaleItems = new System.Windows.Forms.DataGridView();

            btnAddItem = new System.Windows.Forms.Button();
            btnRemoveItem = new System.Windows.Forms.Button();
            btnCompleteSale = new System.Windows.Forms.Button();
            btnCancel = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)nudQuantity).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudDiscount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvSaleItems).BeginInit();

            SuspendLayout();

            // Item type
            lblItemType.AutoSize = true;
            lblItemType.Location = new System.Drawing.Point(20, 20);
            lblItemType.Text = "Тип позиции:";

            cmbItemType.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbItemType.Items.AddRange(new object[]
            {
                "Товар",
                "Животное"
            });
            cmbItemType.Location = new System.Drawing.Point(120, 17);
            cmbItemType.Size = new System.Drawing.Size(150, 23);
            cmbItemType.SelectedIndexChanged += cmbItemType_SelectedIndexChanged;

            // Item
            lblItem.AutoSize = true;
            lblItem.Location = new System.Drawing.Point(290, 20);
            lblItem.Text = "Наименование:";

            cmbItem.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbItem.Location = new System.Drawing.Point(390, 17);
            cmbItem.Size = new System.Drawing.Size(280, 23);
            cmbItem.SelectedIndexChanged += cmbItem_SelectedIndexChanged;

            // Price
            lblPrice.AutoSize = true;
            lblPrice.Location = new System.Drawing.Point(690, 20);
            lblPrice.Text = "Цена: —";

            // Quantity
            lblQuantity.AutoSize = true;
            lblQuantity.Location = new System.Drawing.Point(20, 65);
            lblQuantity.Text = "Количество:";

            nudQuantity.Location = new System.Drawing.Point(120, 62);
            nudQuantity.Minimum = 1;
            nudQuantity.Maximum = 100000;
            nudQuantity.Value = 1;
            nudQuantity.Size = new System.Drawing.Size(100, 23);

            // Discount
            lblDiscount.AutoSize = true;
            lblDiscount.Location = new System.Drawing.Point(250, 65);
            lblDiscount.Text = "Скидка (%):";

            nudDiscount.Location = new System.Drawing.Point(330, 62);
            nudDiscount.Minimum = 0;
            nudDiscount.Maximum = 100;
            nudDiscount.DecimalPlaces = 2;
            nudDiscount.Size = new System.Drawing.Size(100, 23);

            // Add item
            btnAddItem.Location = new System.Drawing.Point(460, 58);
            btnAddItem.Size = new System.Drawing.Size(130, 32);
            btnAddItem.Text = "Добавить позицию";
            btnAddItem.Click += btnAddItem_Click;

            // Grid
            dgvSaleItems.Location = new System.Drawing.Point(20, 110);
            dgvSaleItems.Size = new System.Drawing.Size(850, 290);
            dgvSaleItems.Anchor =
                System.Windows.Forms.AnchorStyles.Top |
                System.Windows.Forms.AnchorStyles.Bottom |
                System.Windows.Forms.AnchorStyles.Left |
                System.Windows.Forms.AnchorStyles.Right;

            dgvSaleItems.AllowUserToAddRows = false;
            dgvSaleItems.AllowUserToDeleteRows = false;
            dgvSaleItems.ReadOnly = true;
            dgvSaleItems.MultiSelect = false;
            dgvSaleItems.SelectionMode =
                System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvSaleItems.AutoSizeColumnsMode =
                System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            dgvSaleItems.Columns.Add("Name", "Наименование");
            dgvSaleItems.Columns.Add("Quantity", "Количество");
            dgvSaleItems.Columns.Add("Price", "Цена");
            dgvSaleItems.Columns.Add("Discount", "Скидка (%)");
            dgvSaleItems.Columns.Add("Total", "Сумма");

            // Remove
            btnRemoveItem.Location = new System.Drawing.Point(20, 415);
            btnRemoveItem.Size = new System.Drawing.Size(140, 32);
            btnRemoveItem.Text = "Удалить позицию";
            btnRemoveItem.Anchor =
                System.Windows.Forms.AnchorStyles.Bottom |
                System.Windows.Forms.AnchorStyles.Left;
            btnRemoveItem.Click += btnRemoveItem_Click;

            // Payment method
            lblPaymentMethod.AutoSize = true;
            lblPaymentMethod.Location = new System.Drawing.Point(20, 475);
            lblPaymentMethod.Text = "Способ оплаты:";

            cmbPaymentMethod.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbPaymentMethod.Items.AddRange(new object[]
            {
                "Наличные",
                "Банковская карта",
                "Безналичный расчёт"
            });
            cmbPaymentMethod.Location = new System.Drawing.Point(130, 472);
            cmbPaymentMethod.Size = new System.Drawing.Size(200, 23);

            // Total
            lblTotal.AutoSize = true;
            lblTotal.Font = new System.Drawing.Font(
                "Segoe UI", 12F,
                System.Drawing.FontStyle.Bold);
            lblTotal.Location = new System.Drawing.Point(600, 465);
            lblTotal.Text = "Итого: 0";

            // Complete sale
            btnCompleteSale.Location = new System.Drawing.Point(600, 510);
            btnCompleteSale.Size = new System.Drawing.Size(150, 35);
            btnCompleteSale.Text = "Оформить продажу";
            btnCompleteSale.Click += btnCompleteSale_Click;

            // Cancel
            btnCancel.Location = new System.Drawing.Point(760, 510);
            btnCancel.Size = new System.Drawing.Size(110, 35);
            btnCancel.Text = "Отмена";
            btnCancel.Click += btnCancel_Click;

            // Form
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(900, 570);
            MinimumSize = new System.Drawing.Size(800, 500);

            Controls.Add(lblItemType);
            Controls.Add(cmbItemType);
            Controls.Add(lblItem);
            Controls.Add(cmbItem);
            Controls.Add(lblPrice);
            Controls.Add(lblQuantity);
            Controls.Add(nudQuantity);
            Controls.Add(lblDiscount);
            Controls.Add(nudDiscount);
            Controls.Add(btnAddItem);
            Controls.Add(dgvSaleItems);
            Controls.Add(btnRemoveItem);
            Controls.Add(lblPaymentMethod);
            Controls.Add(cmbPaymentMethod);
            Controls.Add(lblTotal);
            Controls.Add(btnCompleteSale);
            Controls.Add(btnCancel);

            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Оформление продажи";

            ((System.ComponentModel.ISupportInitialize)nudQuantity).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudDiscount).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvSaleItems).EndInit();

            ResumeLayout(false);
            PerformLayout();
        }
    }
}