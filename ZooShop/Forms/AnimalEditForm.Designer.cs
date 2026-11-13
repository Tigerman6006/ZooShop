
using System.Drawing;
using System.Windows.Forms;

namespace ZooShop
{
    partial class AnimalEditForm
    {
        private System.ComponentModel.IContainer components = null;

        private TableLayoutPanel mainLayout;

        private Label lblAnimalCode;
        private Label lblName;
        private Label lblSpecies;
        private Label lblBreed;
        private Label lblDateOfBirth;
        private Label lblPurchasePrice;
        private Label lblSellingPrice;

        private NumericUpDown nudAnimalCode;
        private TextBox txtName;
        private TextBox txtSpecies;
        private TextBox txtBreed;
        private DateTimePicker dtpDateOfBirth;
        private NumericUpDown nudPurchasePrice;
        private NumericUpDown nudSellingPrice;

        private FlowLayoutPanel buttonsPanel;
        private Button btnSave;
        private Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            mainLayout = new TableLayoutPanel();
            buttonsPanel = new FlowLayoutPanel();

            lblAnimalCode = new Label();
            lblName = new Label();
            lblSpecies = new Label();
            lblBreed = new Label();
            lblDateOfBirth = new Label();
            lblPurchasePrice = new Label();
            lblSellingPrice = new Label();

            nudAnimalCode = new NumericUpDown();
            txtName = new TextBox();
            txtSpecies = new TextBox();
            txtBreed = new TextBox();
            dtpDateOfBirth = new DateTimePicker();
            nudPurchasePrice = new NumericUpDown();
            nudSellingPrice = new NumericUpDown();

            btnSave = new Button();
            btnCancel = new Button();

            mainLayout.SuspendLayout();
            buttonsPanel.SuspendLayout();

            ((System.ComponentModel.ISupportInitialize)nudAnimalCode).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudPurchasePrice).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudSellingPrice).BeginInit();

            SuspendLayout();

            mainLayout.Dock = DockStyle.Fill;
            mainLayout.Padding = new Padding(15);
            mainLayout.ColumnCount = 2;
            mainLayout.RowCount = 9;

            mainLayout.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 40F));

            mainLayout.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 60F));

            for (int i = 0; i < 8; i++)
            {
                mainLayout.RowStyles.Add(
                    new RowStyle(SizeType.Absolute, 45F));
            }

            mainLayout.RowStyles.Add(
                new RowStyle(SizeType.Percent, 100F));

            ConfigureLabel(lblAnimalCode, "Код животного:");
            ConfigureLabel(lblName, "Кличка:");
            ConfigureLabel(lblSpecies, "Вид:");
            ConfigureLabel(lblBreed, "Порода:");
            ConfigureLabel(lblDateOfBirth, "Дата рождения:");
            ConfigureLabel(lblPurchasePrice, "Закупочная цена:");
            ConfigureLabel(lblSellingPrice, "Цена продажи:");

            ConfigureNumber(nudAnimalCode, 1, 1000000, 0);
            ConfigureNumber(nudPurchasePrice, 0, 1000000, 2);
            ConfigureNumber(nudSellingPrice, 0, 1000000, 2);

            txtName.Dock = DockStyle.Fill;
            txtSpecies.Dock = DockStyle.Fill;
            txtBreed.Dock = DockStyle.Fill;

            dtpDateOfBirth.Dock = DockStyle.Fill;
            dtpDateOfBirth.Format = DateTimePickerFormat.Short;
            dtpDateOfBirth.MaxDate = DateTime.Today;


            AddRow(0, lblAnimalCode, nudAnimalCode);
            AddRow(1, lblName, txtName);
            AddRow(2, lblSpecies, txtSpecies);
            AddRow(3, lblBreed, txtBreed);
            AddRow(4, lblDateOfBirth, dtpDateOfBirth);
            AddRow(5, lblPurchasePrice, nudPurchasePrice);
            AddRow(6, lblSellingPrice, nudSellingPrice);

            buttonsPanel.Dock = DockStyle.Fill;
            buttonsPanel.FlowDirection = FlowDirection.RightToLeft;
            buttonsPanel.Padding = new Padding(0, 12, 0, 0);

            ConfigureButton(btnSave, "Сохранить");
            ConfigureButton(btnCancel, "Отмена");

            btnSave.Click += btnSave_Click;
            btnCancel.Click += btnCancel_Click;

            buttonsPanel.Controls.Add(btnCancel);
            buttonsPanel.Controls.Add(btnSave);

            mainLayout.Controls.Add(buttonsPanel, 0, 8);
            mainLayout.SetColumnSpan(buttonsPanel, 2);

            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(500, 470);
            MinimumSize = new Size(480, 450);

            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;

            MaximizeBox = false;
            MinimizeBox = false;

            Controls.Add(mainLayout);

            mainLayout.ResumeLayout(false);
            buttonsPanel.ResumeLayout(false);

            ((System.ComponentModel.ISupportInitialize)nudAnimalCode).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudPurchasePrice).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudSellingPrice).EndInit();

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

        private void ConfigureButton(Button button, string text)
        {
            button.Text = text;
            button.Width = 115;
            button.Height = 35;
            button.FlatStyle = FlatStyle.Flat;
            button.Cursor = Cursors.Hand;
        }

        private void AddRow(int row, Control label, Control input)
        {
            mainLayout.Controls.Add(label, 0, row);
            mainLayout.Controls.Add(input, 1, row);
        }
    }
}
