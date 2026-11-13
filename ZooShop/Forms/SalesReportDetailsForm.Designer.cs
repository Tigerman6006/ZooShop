using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace ZooShop
{
    partial class SalesReportDetailsForm
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblTitle;
        private Label lblPeriod;
        private Label lblTotalQuantity;
        private Label lblTotalRevenue;

        private DataGridView dgvReport;
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
            lblPeriod = new Label();
            lblTotalQuantity = new Label();
            lblTotalRevenue = new Label();

            dgvReport = new DataGridView();
            btnClose = new Button();

            ((System.ComponentModel.ISupportInitialize)dgvReport)
                .BeginInit();

            SuspendLayout();

            lblTitle.AutoSize = true;
            lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.Location = new Point(20, 15);
            lblTitle.Text = "Результаты отчёта";

            lblPeriod.AutoSize = true;
            lblPeriod.Location = new Point(25, 60);
            lblPeriod.Text = "Период:";

            dgvReport.Location = new Point(25, 95);
            dgvReport.Size = new Size(690, 300);
            dgvReport.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Bottom |
                AnchorStyles.Left |
                AnchorStyles.Right;

            dgvReport.ReadOnly = true;
            dgvReport.AllowUserToAddRows = false;
            dgvReport.AllowUserToDeleteRows = false;
            dgvReport.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
            dgvReport.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            dgvReport.MultiSelect = false;
            dgvReport.RowHeadersVisible = false;

            lblTotalQuantity.AutoSize = true;
            lblTotalQuantity.Location = new Point(25, 410);
            lblTotalQuantity.Text = "Общее количество: 0";

            lblTotalRevenue.AutoSize = true;
            lblTotalRevenue.Font =
                new System.Drawing.Font("Segoe UI", 10F, FontStyle.Bold);
            lblTotalRevenue.Location = new Point(25, 440);
            lblTotalRevenue.Text = "Общая выручка: 0";

            btnClose.Location = new Point(595, 435);
            btnClose.Size = new Size(120, 35);
            btnClose.Anchor =
                AnchorStyles.Bottom | AnchorStyles.Right;
            btnClose.Text = "Закрыть";
            btnClose.Click += btnClose_Click;

            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;

            ClientSize = new Size(740, 490);
            Controls.AddRange(new Control[]
            {
                lblTitle,
                lblPeriod,
                dgvReport,
                lblTotalQuantity,
                lblTotalRevenue,
                btnClose
            });

            StartPosition = FormStartPosition.CenterParent;
            Text = "Детализация отчёта";

            ((System.ComponentModel.ISupportInitialize)dgvReport)
                .EndInit();

            ResumeLayout(false);
            PerformLayout();
        }
    }
}