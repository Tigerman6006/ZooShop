using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace ZooShop
{
    partial class ProductBatchAddForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblProduct;
        private System.Windows.Forms.Label lblSupplier;
        private System.Windows.Forms.Label lblArrivalDate;
        private System.Windows.Forms.Label lblExpirationDate;
        private System.Windows.Forms.Label lblQuantity;

        private System.Windows.Forms.ComboBox cmbProduct;
        private System.Windows.Forms.ComboBox cmbSupplier;
        private System.Windows.Forms.DateTimePicker dtpArrivalDate;
        private System.Windows.Forms.DateTimePicker dtpExpirationDate;
        private System.Windows.Forms.NumericUpDown nudQuantity;

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblProduct = new System.Windows.Forms.Label();
            lblSupplier = new System.Windows.Forms.Label();
            lblArrivalDate = new System.Windows.Forms.Label();
            lblExpirationDate = new System.Windows.Forms.Label();
            lblQuantity = new System.Windows.Forms.Label();

            cmbProduct = new System.Windows.Forms.ComboBox();
            cmbSupplier = new System.Windows.Forms.ComboBox();
            dtpArrivalDate = new System.Windows.Forms.DateTimePicker();
            dtpExpirationDate = new System.Windows.Forms.DateTimePicker();
            nudQuantity = new System.Windows.Forms.NumericUpDown();

            btnSave = new System.Windows.Forms.Button();
            btnCancel = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)nudQuantity).BeginInit();
            SuspendLayout();

            // Product
            lblProduct.AutoSize = true;
            lblProduct.Location = new System.Drawing.Point(25, 25);
            lblProduct.Text = "Товар:";

            cmbProduct.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbProduct.Location = new System.Drawing.Point(190, 22);
            cmbProduct.Size = new System.Drawing.Size(260, 23);

            // Supplier
            lblSupplier.AutoSize = true;
            lblSupplier.Location = new System.Drawing.Point(25, 65);
            lblSupplier.Text = "Поставщик:";

            cmbSupplier.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbSupplier.Location = new System.Drawing.Point(190, 62);
            cmbSupplier.Size = new System.Drawing.Size(260, 23);

            // Arrival date
            lblArrivalDate.AutoSize = true;
            lblArrivalDate.Location = new System.Drawing.Point(25, 105);
            lblArrivalDate.Text = "Дата поступления:";

            dtpArrivalDate.Format =
                System.Windows.Forms.DateTimePickerFormat.Short;
            dtpArrivalDate.Location = new System.Drawing.Point(190, 102);
            dtpArrivalDate.Size = new System.Drawing.Size(150, 23);

            // Expiration date
            lblExpirationDate.AutoSize = true;
            lblExpirationDate.Location = new System.Drawing.Point(25, 145);
            lblExpirationDate.Text = "Срок годности до:";

            dtpExpirationDate.Format =
                System.Windows.Forms.DateTimePickerFormat.Short;
            dtpExpirationDate.Location = new System.Drawing.Point(190, 142);
            dtpExpirationDate.Size = new System.Drawing.Size(150, 23);

            // Quantity
            lblQuantity.AutoSize = true;
            lblQuantity.Location = new System.Drawing.Point(25, 185);
            lblQuantity.Text = "Количество:";

            nudQuantity.Location = new System.Drawing.Point(190, 182);
            nudQuantity.Minimum = 1;
            nudQuantity.Maximum = 1000000;
            nudQuantity.Value = 1;
            nudQuantity.Size = new System.Drawing.Size(150, 23);

            // Save
            btnSave.Location = new System.Drawing.Point(190, 235);
            btnSave.Size = new System.Drawing.Size(110, 32);
            btnSave.Text = "Сохранить";
            btnSave.Click += btnSave_Click;

            // Cancel
            btnCancel.Location = new System.Drawing.Point(310, 235);
            btnCancel.Size = new System.Drawing.Size(110, 32);
            btnCancel.Text = "Отмена";
            btnCancel.Click += btnCancel_Click;

            // Form
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(480, 300);
            Controls.Add(lblProduct);
            Controls.Add(cmbProduct);
            Controls.Add(lblSupplier);
            Controls.Add(cmbSupplier);
            Controls.Add(lblArrivalDate);
            Controls.Add(dtpArrivalDate);
            Controls.Add(lblExpirationDate);
            Controls.Add(dtpExpirationDate);
            Controls.Add(lblQuantity);
            Controls.Add(nudQuantity);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);

            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Регистрация партии";

            ((System.ComponentModel.ISupportInitialize)nudQuantity).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}