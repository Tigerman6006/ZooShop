using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace ZooShop
{
    partial class SalesReportForm
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblTitle;
        private Label lblStart;
        private Label lblEnd;
        private Label lblGrouping;
        private Label lblCategory;

        private DateTimePicker dtpStart;
        private DateTimePicker dtpEnd;

        private ComboBox cmbGrouping;
        private ComboBox cmbCategory;

        private Button btnGenerate;
        private Button btnClose;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblTitle = new Label();
            lblStart = new Label();
            lblEnd = new Label();
            lblGrouping = new Label();
            lblCategory = new Label();

            dtpStart = new DateTimePicker();
            dtpEnd = new DateTimePicker();

            cmbGrouping = new ComboBox();
            cmbCategory = new ComboBox();

            btnGenerate = new Button();
            btnClose = new Button();

            SuspendLayout();

            lblTitle.AutoSize = true;
            lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.Location = new Point(25, 20);
            lblTitle.Text = "Отчёт о продажах";

            lblStart.AutoSize = true;
            lblStart.Location = new Point(30, 85);
            lblStart.Text = "Начало периода:";

            dtpStart.Format = DateTimePickerFormat.Short;
            dtpStart.Location = new Point(160, 80);
            dtpStart.Size = new Size(180, 27);

            lblEnd.AutoSize = true;
            lblEnd.Location = new Point(30, 130);
            lblEnd.Text = "Конец периода:";

            dtpEnd.Format = DateTimePickerFormat.Short;
            dtpEnd.Location = new Point(160, 125);
            dtpEnd.Size = new Size(180, 27);

            lblGrouping.AutoSize = true;
            lblGrouping.Location = new Point(30, 175);
            lblGrouping.Text = "Группировка:";

            cmbGrouping.DropDownStyle =
                ComboBoxStyle.DropDownList;

            cmbGrouping.Items.AddRange(new object[]
            {
                "По товарам",
                "По категориям"
            });

            cmbGrouping.Location = new Point(160, 170);
            cmbGrouping.Size = new Size(180, 28);
            cmbGrouping.SelectedIndexChanged +=
                cmbGrouping_SelectedIndexChanged;

            lblCategory.AutoSize = true;
            lblCategory.Location = new Point(30, 220);
            lblCategory.Text = "Категория:";

            cmbCategory.DropDownStyle =
                ComboBoxStyle.DropDownList;

            cmbCategory.Location = new Point(160, 215);
            cmbCategory.Size = new Size(180, 28);

            btnGenerate.Location = new Point(160, 275);
            btnGenerate.Size = new Size(180, 35);
            btnGenerate.Text = "Сформировать";
            btnGenerate.Click += btnGenerate_Click;

            btnClose.Location = new Point(160, 320);
            btnClose.Size = new Size(180, 35);
            btnClose.Text = "Закрыть";
            btnClose.Click += (s, e) => Close();

            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;

            ClientSize = new Size(390, 385);
            Controls.AddRange(new Control[]
            {
                lblTitle,
                lblStart,
                dtpStart,
                lblEnd,
                dtpEnd,
                lblGrouping,
                cmbGrouping,
                lblCategory,
                cmbCategory,
                btnGenerate,
                btnClose
            });

            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Отчёт о продажах";

            ResumeLayout(false);
            PerformLayout();
        }
    }
}