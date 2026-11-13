using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace ZooShop
{
    partial class ReplenishmentRequestAddForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblProduct;
        private System.Windows.Forms.Label lblSupplier;
        private System.Windows.Forms.Label lblRequiredQuantity;

        private System.Windows.Forms.ComboBox cmbProduct;
        private System.Windows.Forms.ComboBox cmbSupplier;
        private System.Windows.Forms.NumericUpDown nudRequiredQuantity;

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
            lblRequiredQuantity = new System.Windows.Forms.Label();

            cmbProduct = new System.Windows.Forms.ComboBox();
            cmbSupplier = new System.Windows.Forms.ComboBox();
            nudRequiredQuantity = new System.Windows.Forms.NumericUpDown();

            btnSave = new System.Windows.Forms.Button();
            btnCancel = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)nudRequiredQuantity).BeginInit();
            SuspendLayout();

            // Product
            lblProduct.AutoSize = true;
            lblProduct.Location = new System.Drawing.Point(25, 25);
            lblProduct.Text = "Товар:";

            cmbProduct.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbProduct.Location = new System.Drawing.Point(190, 22);
            cmbProduct.Size = new System.Drawing.Size(270, 23);

            // Supplier
            lblSupplier.AutoSize = true;
            lblSupplier.Location = new System.Drawing.Point(25, 70);
            lblSupplier.Text = "Поставщик:";

            cmbSupplier.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbSupplier.Location = new System.Drawing.Point(190, 67);
            cmbSupplier.Size = new System.Drawing.Size(270, 23);

            // Quantity
            lblRequiredQuantity.AutoSize = true;
            lblRequiredQuantity.Location = new System.Drawing.Point(25, 115);
            lblRequiredQuantity.Text = "Требуемое количество:";

            nudRequiredQuantity.Location = new System.Drawing.Point(190, 112);
            nudRequiredQuantity.Minimum = 1;
            nudRequiredQuantity.Maximum = 1000000;
            nudRequiredQuantity.Value = 1;
            nudRequiredQuantity.Size = new System.Drawing.Size(150, 23);

            // Save
            btnSave.Location = new System.Drawing.Point(190, 170);
            btnSave.Size = new System.Drawing.Size(125, 32);
            btnSave.Text = "Создать и отправить";
            btnSave.Click += btnSave_Click;

            // Cancel
            btnCancel.Location = new System.Drawing.Point(325, 170);
            btnCancel.Size = new System.Drawing.Size(110, 32);
            btnCancel.Text = "Отмена";
            btnCancel.Click += btnCancel_Click;

            // Form
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(490, 235);

            Controls.Add(lblProduct);
            Controls.Add(cmbProduct);
            Controls.Add(lblSupplier);
            Controls.Add(cmbSupplier);
            Controls.Add(lblRequiredQuantity);
            Controls.Add(nudRequiredQuantity);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);

            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Новая заявка на пополнение";

            ((System.ComponentModel.ISupportInitialize)nudRequiredQuantity).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}