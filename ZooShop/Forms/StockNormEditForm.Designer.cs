using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace ZooShop
{
    partial class StockNormEditForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.Label lblMinimumStock;
        private System.Windows.Forms.Label lblMaximumStock;
        private System.Windows.Forms.Label lblReviewPeriod;

        private System.Windows.Forms.NumericUpDown nudMinimumStock;
        private System.Windows.Forms.NumericUpDown nudMaximumStock;
        private System.Windows.Forms.NumericUpDown nudReviewPeriod;

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
            lblProductName = new System.Windows.Forms.Label();
            lblMinimumStock = new System.Windows.Forms.Label();
            lblMaximumStock = new System.Windows.Forms.Label();
            lblReviewPeriod = new System.Windows.Forms.Label();

            nudMinimumStock = new System.Windows.Forms.NumericUpDown();
            nudMaximumStock = new System.Windows.Forms.NumericUpDown();
            nudReviewPeriod = new System.Windows.Forms.NumericUpDown();

            btnSave = new System.Windows.Forms.Button();
            btnCancel = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)nudMinimumStock).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudMaximumStock).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudReviewPeriod).BeginInit();

            SuspendLayout();

            // Product name
            lblProductName.AutoSize = true;
            lblProductName.Location = new System.Drawing.Point(25, 20);
            lblProductName.Size = new System.Drawing.Size(250, 20);
            lblProductName.Text = "Товар:";

            // Minimum stock
            lblMinimumStock.AutoSize = true;
            lblMinimumStock.Location = new System.Drawing.Point(25, 65);
            lblMinimumStock.Text = "Минимальный остаток:";

            nudMinimumStock.Location = new System.Drawing.Point(220, 62);
            nudMinimumStock.Minimum = 0;
            nudMinimumStock.Maximum = 1000000;
            nudMinimumStock.Size = new System.Drawing.Size(150, 23);

            // Maximum stock
            lblMaximumStock.AutoSize = true;
            lblMaximumStock.Location = new System.Drawing.Point(25, 105);
            lblMaximumStock.Text = "Максимальный остаток:";

            nudMaximumStock.Location = new System.Drawing.Point(220, 102);
            nudMaximumStock.Minimum = 0;
            nudMaximumStock.Maximum = 1000000;
            nudMaximumStock.Size = new System.Drawing.Size(150, 23);

            // Review period
            lblReviewPeriod.AutoSize = true;
            lblReviewPeriod.Location = new System.Drawing.Point(25, 145);
            lblReviewPeriod.Text = "Период проверки (дней):";

            nudReviewPeriod.Location = new System.Drawing.Point(220, 142);
            nudReviewPeriod.Minimum = 1;
            nudReviewPeriod.Maximum = 365;
            nudReviewPeriod.Value = 7;
            nudReviewPeriod.Size = new System.Drawing.Size(150, 23);

            // Save
            btnSave.Location = new System.Drawing.Point(145, 200);
            btnSave.Size = new System.Drawing.Size(110, 32);
            btnSave.Text = "Сохранить";
            btnSave.Click += btnSave_Click;

            // Cancel
            btnCancel.Location = new System.Drawing.Point(265, 200);
            btnCancel.Size = new System.Drawing.Size(105, 32);
            btnCancel.Text = "Отмена";
            btnCancel.Click += btnCancel_Click;

            // Form
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(410, 260);

            Controls.Add(lblProductName);
            Controls.Add(lblMinimumStock);
            Controls.Add(nudMinimumStock);
            Controls.Add(lblMaximumStock);
            Controls.Add(nudMaximumStock);
            Controls.Add(lblReviewPeriod);
            Controls.Add(nudReviewPeriod);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);

            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Настройка нормы запаса";

            ((System.ComponentModel.ISupportInitialize)nudMinimumStock).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudMaximumStock).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudReviewPeriod).EndInit();

            ResumeLayout(false);
            PerformLayout();
        }
    }
}