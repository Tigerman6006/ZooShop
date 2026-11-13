using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace ZooShop
{
    partial class ReplenishmentRequestListForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cmbStatusFilter;
        private System.Windows.Forms.DataGridView dgvRequests;

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
            lblStatus = new System.Windows.Forms.Label();
            cmbStatusFilter = new System.Windows.Forms.ComboBox();
            dgvRequests = new System.Windows.Forms.DataGridView();

            btnAdd = new System.Windows.Forms.Button();
            btnRefresh = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)dgvRequests).BeginInit();
            SuspendLayout();

            // Search
            lblSearch.AutoSize = true;
            lblSearch.Location = new System.Drawing.Point(20, 20);
            lblSearch.Text = "Поиск:";

            txtSearch.Location = new System.Drawing.Point(80, 17);
            txtSearch.Size = new System.Drawing.Size(260, 23);
            txtSearch.TextChanged += txtSearch_TextChanged;

            // Status filter
            lblStatus.AutoSize = true;
            lblStatus.Location = new System.Drawing.Point(365, 20);
            lblStatus.Text = "Статус:";

            cmbStatusFilter.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbStatusFilter.Location = new System.Drawing.Point(425, 17);
            cmbStatusFilter.Size = new System.Drawing.Size(180, 23);
            cmbStatusFilter.SelectedIndexChanged +=
                cmbStatusFilter_SelectedIndexChanged;

            // Grid
            dgvRequests.Location = new System.Drawing.Point(20, 55);
            dgvRequests.Size = new System.Drawing.Size(960, 390);
            dgvRequests.Anchor =
                System.Windows.Forms.AnchorStyles.Top |
                System.Windows.Forms.AnchorStyles.Bottom |
                System.Windows.Forms.AnchorStyles.Left |
                System.Windows.Forms.AnchorStyles.Right;

            dgvRequests.AllowUserToAddRows = false;
            dgvRequests.AllowUserToDeleteRows = false;
            dgvRequests.ReadOnly = true;
            dgvRequests.MultiSelect = false;
            dgvRequests.SelectionMode =
                System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvRequests.AutoSizeColumnsMode =
                System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            dgvRequests.Columns.Add("RequestNumber", "Номер заявки");
            dgvRequests.Columns.Add("CreationDate", "Дата создания");
            dgvRequests.Columns.Add("Product", "Товар");
            dgvRequests.Columns.Add("RequiredQuantity", "Количество");
            dgvRequests.Columns.Add("Supplier", "Поставщик");
            dgvRequests.Columns.Add("Status", "Статус");

            // Add
            btnAdd.Location = new System.Drawing.Point(20, 465);
            btnAdd.Size = new System.Drawing.Size(160, 32);
            btnAdd.Text = "Создать заявку";
            btnAdd.Anchor =
                System.Windows.Forms.AnchorStyles.Bottom |
                System.Windows.Forms.AnchorStyles.Left;
            btnAdd.Click += btnAdd_Click;

            // Refresh
            btnRefresh.Location = new System.Drawing.Point(190, 465);
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
            Controls.Add(lblStatus);
            Controls.Add(cmbStatusFilter);
            Controls.Add(dgvRequests);
            Controls.Add(btnAdd);
            Controls.Add(btnRefresh);

            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Заявки на пополнение";

            ((System.ComponentModel.ISupportInitialize)dgvRequests).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}