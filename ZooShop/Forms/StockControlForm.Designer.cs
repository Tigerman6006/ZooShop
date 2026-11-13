using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace ZooShop
{
    partial class StockControlForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.DataGridView dgvStock;
        private System.Windows.Forms.Label lblSummary;
        private System.Windows.Forms.CheckBox chkOnlyLowStock;

        private System.Windows.Forms.Button btnSetNorm;
        private System.Windows.Forms.Button btnCreateRequest;
        private System.Windows.Forms.Button btnRefresh;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            dgvStock = new System.Windows.Forms.DataGridView();
            lblSummary = new System.Windows.Forms.Label();
            chkOnlyLowStock = new System.Windows.Forms.CheckBox();

            btnSetNorm = new System.Windows.Forms.Button();
            btnCreateRequest = new System.Windows.Forms.Button();
            btnRefresh = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)dgvStock).BeginInit();
            SuspendLayout();

            // Grid
            dgvStock.Location = new System.Drawing.Point(20, 55);
            dgvStock.Size = new System.Drawing.Size(900, 350);
            dgvStock.Anchor =
                System.Windows.Forms.AnchorStyles.Top |
                System.Windows.Forms.AnchorStyles.Bottom |
                System.Windows.Forms.AnchorStyles.Left |
                System.Windows.Forms.AnchorStyles.Right;

            dgvStock.AllowUserToAddRows = false;
            dgvStock.AllowUserToDeleteRows = false;
            dgvStock.ReadOnly = true;
            dgvStock.MultiSelect = false;
            dgvStock.SelectionMode =
                System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvStock.AutoSizeColumnsMode =
                System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            dgvStock.Columns.Add("ProductCode", "Код товара");
            dgvStock.Columns.Add("Name", "Товар");
            dgvStock.Columns.Add("CurrentStock", "Текущий остаток");
            dgvStock.Columns.Add("MinimumStock", "Минимум");
            dgvStock.Columns.Add("MaximumStock", "Максимум");
            dgvStock.Columns.Add("Status", "Состояние");

            // Filter
            chkOnlyLowStock.AutoSize = true;
            chkOnlyLowStock.Location = new System.Drawing.Point(20, 20);
            chkOnlyLowStock.Text = "Показать только товары, требующие пополнения";
            chkOnlyLowStock.CheckedChanged +=
                chkOnlyLowStock_CheckedChanged;

            // Summary
            lblSummary.AutoSize = true;
            lblSummary.Location = new System.Drawing.Point(20, 420);
            lblSummary.Text = "Всего товаров: 0";
            lblSummary.Anchor =
                System.Windows.Forms.AnchorStyles.Bottom |
                System.Windows.Forms.AnchorStyles.Left;

            // Set norm
            btnSetNorm.Location = new System.Drawing.Point(20, 460);
            btnSetNorm.Size = new System.Drawing.Size(145, 35);
            btnSetNorm.Text = "Настроить норму";
            btnSetNorm.Anchor =
                System.Windows.Forms.AnchorStyles.Bottom |
                System.Windows.Forms.AnchorStyles.Left;
            btnSetNorm.Click += btnSetNorm_Click;

            // Create request
            btnCreateRequest.Location = new System.Drawing.Point(175, 460);
            btnCreateRequest.Size = new System.Drawing.Size(175, 35);
            btnCreateRequest.Text = "Создать заявку";
            btnCreateRequest.Anchor =
                System.Windows.Forms.AnchorStyles.Bottom |
                System.Windows.Forms.AnchorStyles.Left;
            btnCreateRequest.Click += btnCreateRequest_Click;

            // Refresh
            btnRefresh.Location = new System.Drawing.Point(360, 460);
            btnRefresh.Size = new System.Drawing.Size(110, 35);
            btnRefresh.Text = "Обновить";
            btnRefresh.Anchor =
                System.Windows.Forms.AnchorStyles.Bottom |
                System.Windows.Forms.AnchorStyles.Left;
            btnRefresh.Click += btnRefresh_Click;

            // Form
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(940, 520);
            MinimumSize = new System.Drawing.Size(750, 430);

            Controls.Add(chkOnlyLowStock);
            Controls.Add(dgvStock);
            Controls.Add(lblSummary);
            Controls.Add(btnSetNorm);
            Controls.Add(btnCreateRequest);
            Controls.Add(btnRefresh);

            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Контроль складских запасов";

            ((System.ComponentModel.ISupportInitialize)dgvStock).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}