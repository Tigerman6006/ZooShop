using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace ZooShop
{
    partial class SaleListForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.Label lblEndDate;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.DateTimePicker dtpEndDate;

        private System.Windows.Forms.DataGridView dgvSales;

        private System.Windows.Forms.Label lblSalesCount;
        private System.Windows.Forms.Label lblSalesTotal;

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDetails;
        private System.Windows.Forms.Button btnRefresh;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblSearch = new System.Windows.Forms.Label();
            txtSearch = new System.Windows.Forms.TextBox();
            lblStartDate = new System.Windows.Forms.Label();
            lblEndDate = new System.Windows.Forms.Label();
            dtpStartDate = new System.Windows.Forms.DateTimePicker();
            dtpEndDate = new System.Windows.Forms.DateTimePicker();

            dgvSales = new System.Windows.Forms.DataGridView();

            lblSalesCount = new System.Windows.Forms.Label();
            lblSalesTotal = new System.Windows.Forms.Label();

            btnAdd = new System.Windows.Forms.Button();
            btnDetails = new System.Windows.Forms.Button();
            btnRefresh = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)dgvSales).BeginInit();
            SuspendLayout();

            // Search
            lblSearch.AutoSize = true;
            lblSearch.Location = new System.Drawing.Point(20, 20);
            lblSearch.Text = "Поиск:";

            txtSearch.Location = new System.Drawing.Point(80, 17);
            txtSearch.Size = new System.Drawing.Size(220, 23);
            txtSearch.TextChanged += txtSearch_TextChanged;

            // Start date
            lblStartDate.AutoSize = true;
            lblStartDate.Location = new System.Drawing.Point(325, 20);
            lblStartDate.Text = "С:";

            dtpStartDate.Format =
                System.Windows.Forms.DateTimePickerFormat.Short;
            dtpStartDate.Location = new System.Drawing.Point(350, 17);
            dtpStartDate.Size = new System.Drawing.Size(120, 23);
            dtpStartDate.ValueChanged += dtpDate_ValueChanged;

            // End date
            lblEndDate.AutoSize = true;
            lblEndDate.Location = new System.Drawing.Point(490, 20);
            lblEndDate.Text = "По:";

            dtpEndDate.Format =
                System.Windows.Forms.DateTimePickerFormat.Short;
            dtpEndDate.Location = new System.Drawing.Point(520, 17);
            dtpEndDate.Size = new System.Drawing.Size(120, 23);
            dtpEndDate.ValueChanged += dtpDate_ValueChanged;

            // Grid
            dgvSales.Location = new System.Drawing.Point(20, 60);
            dgvSales.Size = new System.Drawing.Size(860, 350);
            dgvSales.Anchor =
                System.Windows.Forms.AnchorStyles.Top |
                System.Windows.Forms.AnchorStyles.Bottom |
                System.Windows.Forms.AnchorStyles.Left |
                System.Windows.Forms.AnchorStyles.Right;

            dgvSales.AllowUserToAddRows = false;
            dgvSales.AllowUserToDeleteRows = false;
            dgvSales.ReadOnly = true;
            dgvSales.MultiSelect = false;
            dgvSales.SelectionMode =
                System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvSales.AutoSizeColumnsMode =
                System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            dgvSales.Columns.Add("ReceiptNumber", "Номер чека");
            dgvSales.Columns.Add("SaleDate", "Дата продажи");
            dgvSales.Columns.Add("Amount", "Сумма");
            dgvSales.Columns.Add("PaymentMethod", "Способ оплаты");

            // Summary
            lblSalesCount.AutoSize = true;
            lblSalesCount.Location = new System.Drawing.Point(20, 425);
            lblSalesCount.Text = "Количество чеков: 0";

            lblSalesTotal.AutoSize = true;
            lblSalesTotal.Location = new System.Drawing.Point(250, 425);
            lblSalesTotal.Text = "Общая сумма: 0";

            // Buttons
            btnAdd.Location = new System.Drawing.Point(20, 465);
            btnAdd.Size = new System.Drawing.Size(125, 32);
            btnAdd.Text = "Новая продажа";
            btnAdd.Anchor =
                System.Windows.Forms.AnchorStyles.Bottom |
                System.Windows.Forms.AnchorStyles.Left;
            btnAdd.Click += btnAdd_Click;

            btnDetails.Location = new System.Drawing.Point(155, 465);
            btnDetails.Size = new System.Drawing.Size(125, 32);
            btnDetails.Text = "Состав чека";
            btnDetails.Anchor =
                System.Windows.Forms.AnchorStyles.Bottom |
                System.Windows.Forms.AnchorStyles.Left;
            btnDetails.Click += btnDetails_Click;

            btnRefresh.Location = new System.Drawing.Point(290, 465);
            btnRefresh.Size = new System.Drawing.Size(110, 32);
            btnRefresh.Text = "Обновить";
            btnRefresh.Anchor =
                System.Windows.Forms.AnchorStyles.Bottom |
                System.Windows.Forms.AnchorStyles.Left;
            btnRefresh.Click += btnRefresh_Click;

            // Form
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(900, 520);
            MinimumSize = new System.Drawing.Size(750, 430);

            Controls.Add(lblSearch);
            Controls.Add(txtSearch);
            Controls.Add(lblStartDate);
            Controls.Add(dtpStartDate);
            Controls.Add(lblEndDate);
            Controls.Add(dtpEndDate);
            Controls.Add(dgvSales);
            Controls.Add(lblSalesCount);
            Controls.Add(lblSalesTotal);
            Controls.Add(btnAdd);
            Controls.Add(btnDetails);
            Controls.Add(btnRefresh);

            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Продажи";

            ((System.ComponentModel.ISupportInitialize)dgvSales).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}