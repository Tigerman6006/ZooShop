using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using Font = System.Drawing.Font;

namespace ZooShop
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblTitle;
        private Label lblSubtitle;
        private Label lblDate;
        private Label lblStatus;

        private GroupBox grpDirectories;
        private GroupBox grpWarehouse;
        private GroupBox grpSales;

        private Button btnProducts;
        private Button btnCategories;
        private Button btnAnimals;
        private Button btnSuppliers;

        private Button btnStockControl;
        private Button btnReplenishment;

        private Button btnSales;
        private Button btnSalesReport;

        private Button btnExit;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblTitle = new Label();
            lblSubtitle = new Label();
            lblDate = new Label();
            lblStatus = new Label();

            grpDirectories = new GroupBox();
            grpWarehouse = new GroupBox();
            grpSales = new GroupBox();

            btnProducts = new Button();
            btnCategories = new Button();
            btnAnimals = new Button();
            btnSuppliers = new Button();

            btnStockControl = new Button();
            btnReplenishment = new Button();

            btnSales = new Button();
            btnSalesReport = new Button();

            btnExit = new Button();

            grpDirectories.SuspendLayout();
            grpWarehouse.SuspendLayout();
            grpSales.SuspendLayout();
            SuspendLayout();

            // Заголовок

            lblTitle.AutoSize = true;
            lblTitle.Font = new Font(
                "Segoe UI",
                21F,
                FontStyle.Bold);

            lblTitle.Location = new Point(30, 20);
            lblTitle.Text = "PetShop";

            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font(
                "Segoe UI",
                10F);

            lblSubtitle.Location = new Point(34, 65);
            lblSubtitle.Text =
                "Система управления зоомагазином";

            lblDate.AutoSize = true;
            lblDate.Font = new Font(
                "Segoe UI",
                10F,
                FontStyle.Bold);

            lblDate.Location = new Point(650, 35);
            lblDate.Text = "00.00.0000";

            // Справочники

            grpDirectories.Location = new Point(30, 115);
            grpDirectories.Size = new Size(350, 230);
            grpDirectories.Text = "Справочники";
            grpDirectories.Font = new Font(
                "Segoe UI",
                10F,
                FontStyle.Bold);

            btnProducts.Location = new Point(20, 40);
            btnProducts.Size = new Size(145, 65);
            btnProducts.Text = "Товары";
            btnProducts.Font = new Font("Segoe UI", 10F);
            btnProducts.Click += btnProducts_Click;

            btnCategories.Location = new Point(180, 40);
            btnCategories.Size = new Size(145, 65);
            btnCategories.Text = "Категории";
            btnCategories.Font = new Font("Segoe UI", 10F);
            btnCategories.Click += btnCategories_Click;

            btnAnimals.Location = new Point(20, 125);
            btnAnimals.Size = new Size(145, 65);
            btnAnimals.Text = "Животные";
            btnAnimals.Font = new Font("Segoe UI", 10F);
            btnAnimals.Click += btnAnimals_Click;

            btnSuppliers.Location = new Point(180, 125);
            btnSuppliers.Size = new Size(145, 65);
            btnSuppliers.Text = "Поставщики";
            btnSuppliers.Font = new Font("Segoe UI", 10F);
            btnSuppliers.Click += btnSuppliers_Click;

            grpDirectories.Controls.AddRange(new Control[]
            {
                btnProducts,
                btnCategories,
                btnAnimals,
                btnSuppliers
            });

            // Склад и поставки

            grpWarehouse.Location = new Point(410, 115);
            grpWarehouse.Size = new Size(350, 230);
            grpWarehouse.Text = "Склад и поставки";
            grpWarehouse.Font = new Font(
                "Segoe UI",
                10F,
                FontStyle.Bold);

            btnStockControl.Location = new Point(20, 40);
            btnStockControl.Size = new Size(145, 65);
            btnStockControl.Text = "Контроль склада";
            btnStockControl.Font = new Font("Segoe UI", 10F);
            btnStockControl.Click += btnStockControl_Click;

            btnReplenishment.Location = new Point(180, 40);
            btnReplenishment.Size = new Size(145, 65);
            btnReplenishment.Text = "Заявки на\nпополнение";
            btnReplenishment.Font = new Font("Segoe UI", 10F);
            btnReplenishment.Click += btnReplenishment_Click;

            grpWarehouse.Controls.AddRange(new Control[]
            {
                btnStockControl,
                btnReplenishment
            });

            // Продажи и отчёты

            grpSales.Location = new Point(30, 370);
            grpSales.Size = new Size(730, 125);
            grpSales.Text = "Продажи и отчёты";
            grpSales.Font = new Font(
                "Segoe UI",
                10F,
                FontStyle.Bold);

            btnSales.Location = new Point(20, 40);
            btnSales.Size = new Size(200, 60);
            btnSales.Text = "Продажи";
            btnSales.Font = new Font("Segoe UI", 10F);
            btnSales.Click += btnSales_Click;

            btnSalesReport.Location = new Point(240, 40);
            btnSalesReport.Size = new Size(200, 60);
            btnSalesReport.Text = "Отчёты о продажах";
            btnSalesReport.Font = new Font("Segoe UI", 10F);
            btnSalesReport.Click += btnSalesReport_Click;

            grpSales.Controls.AddRange(new Control[]
            {
                btnSales,
                btnSalesReport
            });

            // Строка состояния

            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(30, 525);
            lblStatus.Font = new Font("Segoe UI", 9F);
            lblStatus.Text = "Система готова к работе";

            // Выход

            btnExit.Location = new Point(630, 510);
            btnExit.Size = new Size(130, 40);
            btnExit.Text = "Выход";
            btnExit.Font = new Font("Segoe UI", 10F);
            btnExit.Click += btnExit_Click;

            // Главное окно

            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;

            ClientSize = new Size(800, 575);

            Controls.AddRange(new Control[]
            {
                lblTitle,
                lblSubtitle,
                lblDate,
                grpDirectories,
                grpWarehouse,
                grpSales,
                lblStatus,
                btnExit
            });

            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            StartPosition = FormStartPosition.CenterScreen;

            Text = "PetShop — Главное меню";

            FormClosing += MainForm_FormClosing;

            grpDirectories.ResumeLayout(false);
            grpWarehouse.ResumeLayout(false);
            grpSales.ResumeLayout(false);

            ResumeLayout(false);
            PerformLayout();
        }
    }
}
