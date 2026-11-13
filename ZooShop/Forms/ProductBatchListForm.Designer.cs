using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace ZooShop
{
    partial class ProductBatchListForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.CheckBox chkOnlyAvailable;
        private System.Windows.Forms.DataGridView dgvBatches;

        private System.Windows.Forms.Button btnAdd;
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
            chkOnlyAvailable = new System.Windows.Forms.CheckBox();
            dgvBatches = new System.Windows.Forms.DataGridView();

            btnAdd = new System.Windows.Forms.Button();
            btnRefresh = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)dgvBatches).BeginInit();
            SuspendLayout();

            // Search
            lblSearch.AutoSize = true;
            lblSearch.Location = new System.Drawing.Point(20, 20);
            lblSearch.Text = "Поиск:";

            txtSearch.Location = new System.Drawing.Point(80, 17);
            txtSearch.Size = new System.Drawing.Size(300, 23);
            txtSearch.TextChanged += txtSearch_TextChanged;

            // Only available
            chkOnlyAvailable.AutoSize = true;
            chkOnlyAvailable.Location = new System.Drawing.Point(400, 20);
            chkOnlyAvailable.Text = "Только партии с остатком";
            chkOnlyAvailable.CheckedChanged +=
                chkOnlyAvailable_CheckedChanged;

            // Grid
            dgvBatches.Location = new System.Drawing.Point(20, 55);
            dgvBatches.Size = new System.Drawing.Size(960, 390);
            dgvBatches.Anchor =
                System.Windows.Forms.AnchorStyles.Top |
                System.Windows.Forms.AnchorStyles.Bottom |
                System.Windows.Forms.AnchorStyles.Left |
                System.Windows.Forms.AnchorStyles.Right;

            dgvBatches.AllowUserToAddRows = false;
            dgvBatches.AllowUserToDeleteRows = false;
            dgvBatches.ReadOnly = true;
            dgvBatches.MultiSelect = false;
            dgvBatches.SelectionMode =
                System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvBatches.AutoSizeColumnsMode =
                System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            dgvBatches.Columns.Add("BatchNumber", "Номер партии");
            dgvBatches.Columns.Add("Product", "Товар");
            dgvBatches.Columns.Add("Supplier", "Поставщик");
            dgvBatches.Columns.Add("ArrivalDate", "Дата поступления");
            dgvBatches.Columns.Add("ExpirationDate", "Срок годности");
            dgvBatches.Columns.Add("QuantityReceived", "Поступило");
            dgvBatches.Columns.Add("RemainingQuantity", "Остаток");
            dgvBatches.Columns.Add("Status", "Состояние");

            // Add
            btnAdd.Location = new System.Drawing.Point(20, 465);
            btnAdd.Size = new System.Drawing.Size(120, 32);
            btnAdd.Text = "Добавить партию";
            btnAdd.Anchor =
                System.Windows.Forms.AnchorStyles.Bottom |
                System.Windows.Forms.AnchorStyles.Left;
            btnAdd.Click += btnAdd_Click;

            // Refresh
            btnRefresh.Location = new System.Drawing.Point(150, 465);
            btnRefresh.Size = new System.Drawing.Size(110, 32);
            btnRefresh.Text = "Обновить";
            btnRefresh.Anchor =
                System.Windows.Forms.AnchorStyles.Bottom |
                System.Windows.Forms.AnchorStyles.Left;
            btnRefresh.Click += btnRefresh_Click;

            // Form
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1000, 520);
            MinimumSize = new System.Drawing.Size(800, 450);

            Controls.Add(lblSearch);
            Controls.Add(txtSearch);
            Controls.Add(chkOnlyAvailable);
            Controls.Add(dgvBatches);
            Controls.Add(btnAdd);
            Controls.Add(btnRefresh);

            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Партии товаров";

            ((System.ComponentModel.ISupportInitialize)dgvBatches).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}