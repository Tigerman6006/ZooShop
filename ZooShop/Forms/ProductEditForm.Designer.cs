using System.Drawing;
using System.Windows.Forms;
namespace ZooShop
{
    partial class ProductEditForm
    {
        private System.ComponentModel.IContainer components = null;

        private TableLayoutPanel mainLayout;
        private Label lblProductCode;
        private Label lblName;
        private Label lblPurchasePrice;
        private Label lblSellingPrice;
        private Label lblExpirationDate;
        private Label lblMinimumStock;
        private Label lblMaximumStock;
        private Label lblReviewPeriod;
        private Label lblTemperature;
        private Label lblHumidity;
        private Label lblSpecialRequirements;

        private NumericUpDown nudProductCode;
        private TextBox txtName;
        private NumericUpDown nudPurchasePrice;
        private NumericUpDown nudSellingPrice;
        private DateTimePicker dtpExpirationDate;
        private NumericUpDown nudMinimumStock;
        private NumericUpDown nudMaximumStock;
        private NumericUpDown nudReviewPeriod;
        private NumericUpDown nudTemperature;
        private NumericUpDown nudHumidity;
        private CheckedListBox clbSpecialRequirements;

        private FlowLayoutPanel buttonsPanel;
        private Button btnSave;
        private Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            mainLayout = new TableLayoutPanel();
            buttonsPanel = new FlowLayoutPanel();

            lblProductCode = new Label();
            lblName = new Label();
            lblPurchasePrice = new Label();
            lblSellingPrice = new Label();
            lblExpirationDate = new Label();
            lblMinimumStock = new Label();
            lblMaximumStock = new Label();
            lblReviewPeriod = new Label();
            lblTemperature = new Label();
            lblHumidity = new Label();
            lblSpecialRequirements = new Label();

            nudProductCode = new NumericUpDown();
            txtName = new TextBox();
            nudPurchasePrice = new NumericUpDown();
            nudSellingPrice = new NumericUpDown();
            dtpExpirationDate = new DateTimePicker();
            nudMinimumStock = new NumericUpDown();
            nudMaximumStock = new NumericUpDown();
            nudReviewPeriod = new NumericUpDown();
            nudTemperature = new NumericUpDown();
            nudHumidity = new NumericUpDown();
            clbSpecialRequirements = new CheckedListBox();

            btnSave = new Button();
            btnCancel = new Button();

            mainLayout.SuspendLayout();
            buttonsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudProductCode).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudPurchasePrice).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudSellingPrice).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudMinimumStock).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudMaximumStock).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudReviewPeriod).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudTemperature).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudHumidity).BeginInit();

            SuspendLayout();

            mainLayout.ColumnCount = 2;
            mainLayout.RowCount = 12;
            mainLayout.Dock = DockStyle.Fill;
            mainLayout.Padding = new Padding(15);
            mainLayout.AutoSize = false;

            mainLayout.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 40F));
            mainLayout.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 60F));

            for (int i = 0; i < 10; i++)
            {
                mainLayout.RowStyles.Add(
                    new RowStyle(SizeType.Absolute, 38F));
            }

            mainLayout.RowStyles.Add(
                new RowStyle(SizeType.Absolute, 100F));

            mainLayout.RowStyles.Add(
                new RowStyle(SizeType.Percent, 100F));

            ConfigureLabel(lblProductCode, "Код товара:");
            ConfigureLabel(lblName, "Название:");
            ConfigureLabel(lblPurchasePrice, "Закупочная цена:");
            ConfigureLabel(lblSellingPrice, "Цена продажи:");
            ConfigureLabel(lblExpirationDate, "Срок годности:");
            ConfigureLabel(lblMinimumStock, "Минимальный остаток:");
            ConfigureLabel(lblMaximumStock, "Максимальный остаток:");
            ConfigureLabel(lblReviewPeriod, "Период проверки:");
            ConfigureLabel(lblTemperature, "Температура:");
            ConfigureLabel(lblHumidity, "Влажность:");
            ConfigureLabel(lblSpecialRequirements, "Особые условия:");

            ConfigureNumber(nudProductCode, 1, 1000000, 1);
            ConfigureNumber(nudPurchasePrice, 0, 1000000, 2);
            ConfigureNumber(nudSellingPrice, 0, 1000000, 2);
            ConfigureNumber(nudMinimumStock, 0, 1000000, 0);
            ConfigureNumber(nudMaximumStock, 0, 1000000, 0);
            ConfigureNumber(nudReviewPeriod, 1, 365, 0);
            ConfigureNumber(nudTemperature, -100, 100, 1);
            ConfigureNumber(nudHumidity, 0, 100, 1);

            txtName.Dock = DockStyle.Fill;

            dtpExpirationDate.Dock = DockStyle.Fill;
            dtpExpirationDate.Format = DateTimePickerFormat.Short;

            clbSpecialRequirements.Dock = DockStyle.Fill;
            clbSpecialRequirements.CheckOnClick = true;
            clbSpecialRequirements.Height = 90;

            AddRow(0, lblProductCode, nudProductCode);
            AddRow(1, lblName, txtName);
            AddRow(2, lblPurchasePrice, nudPurchasePrice);
            AddRow(3, lblSellingPrice, nudSellingPrice);
            AddRow(4, lblExpirationDate, dtpExpirationDate);
            AddRow(5, lblMinimumStock, nudMinimumStock);
            AddRow(6, lblMaximumStock, nudMaximumStock);
            AddRow(7, lblReviewPeriod, nudReviewPeriod);
            AddRow(8, lblTemperature, nudTemperature);
            AddRow(9, lblHumidity, nudHumidity);
            AddRow(10, lblSpecialRequirements, clbSpecialRequirements);

            buttonsPanel.Dock = DockStyle.Fill;
            buttonsPanel.FlowDirection = FlowDirection.RightToLeft;
            buttonsPanel.Padding = new Padding(0, 10, 0, 0);

            btnSave.Text = "Сохранить";
            btnSave.Width = 110;
            btnSave.Height = 35;
            btnSave.Click += btnSave_Click;

            btnCancel.Text = "Отмена";
            btnCancel.Width = 110;
            btnCancel.Height = 35;
            btnCancel.Click += btnCancel_Click;

            buttonsPanel.Controls.Add(btnCancel);
            buttonsPanel.Controls.Add(btnSave);

            mainLayout.Controls.Add(buttonsPanel, 0, 11);
            mainLayout.SetColumnSpan(buttonsPanel, 2);

            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(520, 570);
            MinimumSize = new Size(500, 570);
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;

            Controls.Add(mainLayout);

            mainLayout.ResumeLayout(false);
            buttonsPanel.ResumeLayout(false);

            ((System.ComponentModel.ISupportInitialize)nudProductCode).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudPurchasePrice).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudSellingPrice).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudMinimumStock).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudMaximumStock).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudReviewPeriod).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudTemperature).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudHumidity).EndInit();

            mainLayout.ResumeLayout(false);
            ResumeLayout(false);
        }

        private void ConfigureLabel(Label label, string text)
        {
            label.Text = text;
            label.Dock = DockStyle.Fill;
            label.TextAlign = ContentAlignment.MiddleLeft;
        }

        private void ConfigureNumber(
            NumericUpDown control,
            decimal min,
            decimal max,
            int decimalPlaces)
        {
            control.Minimum = min;
            control.Maximum = max;
            control.DecimalPlaces = decimalPlaces;
            control.Dock = DockStyle.Fill;
        }

        private void AddRow(int row, Control label, Control input)
        {
            mainLayout.Controls.Add(label, 0, row);
            mainLayout.Controls.Add(input, 1, row);
        }
    }
}
