
using System.Drawing;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace ZooShop
{
    partial class ProductCategoryEditForm
    {
        private System.ComponentModel.IContainer components = null;

        private TableLayoutPanel mainLayout;

        private Label lblCategoryCode;
        private Label lblCategoryName;

        private NumericUpDown nudCategoryCode;
        private TextBox txtCategoryName;

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
            mainLayout = new TableLayoutPanel();
            lblCategoryCode = new Label();
            nudCategoryCode = new NumericUpDown();
            lblCategoryName = new Label();
            txtCategoryName = new TextBox();
            buttonsPanel = new FlowLayoutPanel();
            btnCancel = new Button();
            btnSave = new Button();
            mainLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudCategoryCode).BeginInit();
            buttonsPanel.SuspendLayout();
            SuspendLayout();
            // 
            // mainLayout
            // 
            mainLayout.ColumnCount = 2;
            mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            mainLayout.Controls.Add(lblCategoryCode, 0, 0);
            mainLayout.Controls.Add(nudCategoryCode, 1, 0);
            mainLayout.Controls.Add(lblCategoryName, 0, 1);
            mainLayout.Controls.Add(txtCategoryName, 1, 1);
            mainLayout.Controls.Add(buttonsPanel, 0, 2);
            mainLayout.Dock = DockStyle.Fill;
            mainLayout.Location = new Point(0, 0);
            mainLayout.Name = "mainLayout";
            mainLayout.Padding = new Padding(15);
            mainLayout.RowCount = 3;
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            mainLayout.Size = new Size(450, 210);
            mainLayout.TabIndex = 0;
            // 
            // lblCategoryCode
            // 
            lblCategoryCode.Location = new Point(18, 15);
            lblCategoryCode.Name = "lblCategoryCode";
            lblCategoryCode.Size = new Size(100, 23);
            lblCategoryCode.TabIndex = 0;
            // 
            // nudCategoryCode
            // 
            nudCategoryCode.Dock = DockStyle.Fill;
            nudCategoryCode.Location = new Point(186, 18);
            nudCategoryCode.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            nudCategoryCode.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudCategoryCode.Name = "nudCategoryCode";
            nudCategoryCode.Size = new Size(246, 27);
            nudCategoryCode.TabIndex = 1;
            nudCategoryCode.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblCategoryName
            // 
            lblCategoryName.Location = new Point(18, 60);
            lblCategoryName.Name = "lblCategoryName";
            lblCategoryName.Size = new Size(100, 23);
            lblCategoryName.TabIndex = 2;
            // 
            // txtCategoryName
            // 
            txtCategoryName.Dock = DockStyle.Fill;
            txtCategoryName.Location = new Point(186, 63);
            txtCategoryName.MaxLength = 100;
            txtCategoryName.Name = "txtCategoryName";
            txtCategoryName.Size = new Size(246, 27);
            txtCategoryName.TabIndex = 3;
            // 
            // buttonsPanel
            // 
            mainLayout.SetColumnSpan(buttonsPanel, 2);
            buttonsPanel.Controls.Add(btnCancel);
            buttonsPanel.Controls.Add(btnSave);
            buttonsPanel.Dock = DockStyle.Fill;
            buttonsPanel.FlowDirection = FlowDirection.RightToLeft;
            buttonsPanel.Location = new Point(18, 108);
            buttonsPanel.Name = "buttonsPanel";
            buttonsPanel.Padding = new Padding(0, 10, 0, 0);
            buttonsPanel.Size = new Size(414, 84);
            buttonsPanel.TabIndex = 4;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(336, 13);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 0;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(255, 13);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 1;
            btnSave.Click += btnSave_Click;
            // 
            // ProductCategoryEditForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(450, 210);
            Controls.Add(mainLayout);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            MinimumSize = new Size(430, 200);
            Name = "ProductCategoryEditForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Категория товара";
            mainLayout.ResumeLayout(false);
            mainLayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudCategoryCode).EndInit();
            buttonsPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        private void ConfigureLabel(Label label, string text)
        {
            label.Text = text;
            label.Dock = DockStyle.Fill;
            label.TextAlign = ContentAlignment.MiddleLeft;
        }

        private void ConfigureButton(Button button, string text)
        {
            button.Text = text;
            button.Size = new Size(115, 35);
            button.FlatStyle = FlatStyle.Flat;
            button.Cursor = Cursors.Hand;
        }
    }
}
