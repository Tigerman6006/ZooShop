
using System.Drawing;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using Font = System.Drawing.Font;

namespace ZooShop
{
    partial class AnimalListForm
    {
        private System.ComponentModel.IContainer components = null;

        private Panel topPanel;
        private Panel bottomPanel;

        private Label lblTitle;
        private Label lblSearch;
        private Label lblCount;

        private TextBox txtSearch;
        private DataGridView dgvAnimals;

        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;
        private Button btnRefresh;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            topPanel = new Panel();
            bottomPanel = new Panel();

            lblTitle = new Label();
            lblSearch = new Label();
            lblCount = new Label();

            txtSearch = new TextBox();
            dgvAnimals = new DataGridView();

            btnAdd = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            btnRefresh = new Button();

            topPanel.SuspendLayout();
            bottomPanel.SuspendLayout();

            ((System.ComponentModel.ISupportInitialize)dgvAnimals).BeginInit();

            SuspendLayout();

            topPanel.Dock = DockStyle.Top;
            topPanel.Height = 105;
            topPanel.Padding = new Padding(15);

            lblTitle.Text = "Животные";
            lblTitle.Font = new System.Drawing.Font(
                "Segoe UI", 16F, FontStyle.Bold);

            lblTitle.Location = new Point(15, 10);
            lblTitle.AutoSize = true;

            lblSearch.Text = "Поиск:";
            lblSearch.Location = new Point(18, 58);
            lblSearch.AutoSize = true;

            txtSearch.Location = new Point(80, 54);
            txtSearch.Size = new Size(300, 27);

            txtSearch.TextChanged += txtSearch_TextChanged;

            topPanel.Controls.Add(lblTitle);
            topPanel.Controls.Add(lblSearch);
            topPanel.Controls.Add(txtSearch);

            dgvAnimals.Dock = DockStyle.Fill;
            dgvAnimals.BackgroundColor = Color.White;
            dgvAnimals.BorderStyle = BorderStyle.Fixed3D;
            dgvAnimals.RowHeadersVisible = false;

            dgvAnimals.ColumnHeadersHeight = 35;
            dgvAnimals.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            dgvAnimals.DefaultCellStyle.Font =
                new Font("Segoe UI", 9.5F);

            dgvAnimals.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 9.5F, FontStyle.Bold);

            dgvAnimals.CellDoubleClick +=
                dgvAnimals_CellDoubleClick;

            bottomPanel.Dock = DockStyle.Bottom;
            bottomPanel.Height = 65;
            bottomPanel.Padding = new Padding(12);

            lblCount.Text = "Количество животных: 0";
            lblCount.AutoSize = true;
            lblCount.Location = new Point(15, 23);

            ConfigureButton(btnAdd, "Добавить", 110);
            ConfigureButton(btnEdit, "Редактировать", 125);
            ConfigureButton(btnDelete, "Удалить", 100);
            ConfigureButton(btnRefresh, "Обновить", 100);

            btnAdd.Click += btnAdd_Click;
            btnEdit.Click += btnEdit_Click;
            btnDelete.Click += btnDelete_Click;
            btnRefresh.Click += btnRefresh_Click;

            btnRefresh.Location = new Point(730, 12);
            btnDelete.Location = new Point(620, 12);
            btnEdit.Location = new Point(485, 12);
            btnAdd.Location = new Point(365, 12);

            btnRefresh.Anchor =
                AnchorStyles.Right | AnchorStyles.Top;

            btnDelete.Anchor =
                AnchorStyles.Right | AnchorStyles.Top;

            btnEdit.Anchor =
                AnchorStyles.Right | AnchorStyles.Top;

            btnAdd.Anchor =
                AnchorStyles.Right | AnchorStyles.Top;

            bottomPanel.Controls.Add(lblCount);
            bottomPanel.Controls.Add(btnAdd);
            bottomPanel.Controls.Add(btnEdit);
            bottomPanel.Controls.Add(btnDelete);
            bottomPanel.Controls.Add(btnRefresh);

            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(900, 520);
            MinimumSize = new Size(750, 400);

            StartPosition = FormStartPosition.CenterParent;
            Text = "Список животных";

            Controls.Add(dgvAnimals);
            Controls.Add(bottomPanel);
            Controls.Add(topPanel);

            topPanel.ResumeLayout(false);
            topPanel.PerformLayout();

            bottomPanel.ResumeLayout(false);
            bottomPanel.PerformLayout();

            ((System.ComponentModel.ISupportInitialize)dgvAnimals).EndInit();

            ResumeLayout(false);
        }

        private void ConfigureButton(
            Button button,
            string text,
            int width)
        {
            button.Text = text;
            button.Size = new Size(width, 35);
            button.FlatStyle = FlatStyle.Flat;
            button.BackColor = Color.FromArgb(235, 240, 245);
            button.Font = new Font("Segoe UI", 9F);
            button.Cursor = Cursors.Hand;
        }
    }
}
