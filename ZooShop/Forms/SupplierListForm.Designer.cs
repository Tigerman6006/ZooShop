using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace ZooShop
{
    partial class SupplierListForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.DataGridView dgvSuppliers;

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
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
            dgvSuppliers = new System.Windows.Forms.DataGridView();

            btnAdd = new System.Windows.Forms.Button();
            btnEdit = new System.Windows.Forms.Button();
            btnDelete = new System.Windows.Forms.Button();
            btnRefresh = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)dgvSuppliers).BeginInit();
            SuspendLayout();

            // lblSearch
            lblSearch.AutoSize = true;
            lblSearch.Location = new System.Drawing.Point(20, 20);
            lblSearch.Text = "Поиск:";

            // txtSearch
            txtSearch.Location = new System.Drawing.Point(80, 17);
            txtSearch.Size = new System.Drawing.Size(350, 23);
            txtSearch.TextChanged += txtSearch_TextChanged;

            // dgvSuppliers
            dgvSuppliers.Location = new System.Drawing.Point(20, 55);
            dgvSuppliers.Size = new System.Drawing.Size(760, 350);
            dgvSuppliers.Anchor =
                System.Windows.Forms.AnchorStyles.Top |
                System.Windows.Forms.AnchorStyles.Bottom |
                System.Windows.Forms.AnchorStyles.Left |
                System.Windows.Forms.AnchorStyles.Right;

            dgvSuppliers.AllowUserToAddRows = false;
            dgvSuppliers.AllowUserToDeleteRows = false;
            dgvSuppliers.ReadOnly = true;
            dgvSuppliers.MultiSelect = false;
            dgvSuppliers.SelectionMode =
                System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvSuppliers.AutoSizeColumnsMode =
                System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            dgvSuppliers.Columns.Add("SupplierCode", "Код");
            dgvSuppliers.Columns.Add("Name", "Название");
            dgvSuppliers.Columns.Add("PhoneNumber", "Телефон");
            dgvSuppliers.Columns.Add("DeliveryLeadTime", "Срок доставки (дней)");

            dgvSuppliers.CellDoubleClick += dgvSuppliers_CellDoubleClick;

            // Buttons
            btnAdd.Text = "Добавить";
            btnAdd.Size = new System.Drawing.Size(105, 32);
            btnAdd.Location = new System.Drawing.Point(20, 425);
            btnAdd.Anchor =
                System.Windows.Forms.AnchorStyles.Bottom |
                System.Windows.Forms.AnchorStyles.Left;
            btnAdd.Click += btnAdd_Click;

            btnEdit.Text = "Изменить";
            btnEdit.Size = new System.Drawing.Size(105, 32);
            btnEdit.Location = new System.Drawing.Point(135, 425);
            btnEdit.Anchor =
                System.Windows.Forms.AnchorStyles.Bottom |
                System.Windows.Forms.AnchorStyles.Left;
            btnEdit.Click += btnEdit_Click;

            btnDelete.Text = "Удалить";
            btnDelete.Size = new System.Drawing.Size(105, 32);
            btnDelete.Location = new System.Drawing.Point(250, 425);
            btnDelete.Anchor =
                System.Windows.Forms.AnchorStyles.Bottom |
                System.Windows.Forms.AnchorStyles.Left;
            btnDelete.Click += btnDelete_Click;

            btnRefresh.Text = "Обновить";
            btnRefresh.Size = new System.Drawing.Size(105, 32);
            btnRefresh.Location = new System.Drawing.Point(365, 425);
            btnRefresh.Anchor =
                System.Windows.Forms.AnchorStyles.Bottom |
                System.Windows.Forms.AnchorStyles.Left;
            btnRefresh.Click += btnRefresh_Click;

            // SupplierListForm
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 475);
            MinimumSize = new System.Drawing.Size(650, 400);

            Controls.Add(lblSearch);
            Controls.Add(txtSearch);
            Controls.Add(dgvSuppliers);
            Controls.Add(btnAdd);
            Controls.Add(btnEdit);
            Controls.Add(btnDelete);
            Controls.Add(btnRefresh);

            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Поставщики";

            ((System.ComponentModel.ISupportInitialize)dgvSuppliers).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}