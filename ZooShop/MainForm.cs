
using Microsoft.Extensions.DependencyInjection;

namespace Zooshop
{
    public partial class MainForm : Form
    {
        private readonly IServiceProvider serviceProvider;

        public MainForm(IServiceProvider serviceProvider)
        {
            InitializeComponent();

            this.serviceProvider = serviceProvider;

            CreateMainMenu();
        }

        private void CreateMainMenu()
        {
            var menuStrip = new MenuStrip();

            // Справочники
            var directoriesMenu = new ToolStripMenuItem("Справочники");

            directoriesMenu.DropDownItems.Add(
                "Товары", null,
                (s, e) => OpenForm<ProductListForm>());

            directoriesMenu.DropDownItems.Add(
                "Животные", null,
                (s, e) => OpenForm<AnimalListForm>());

            directoriesMenu.DropDownItems.Add(
                "Категории товаров", null,
                (s, e) => OpenForm<ProductCategoryListForm>());

            directoriesMenu.DropDownItems.Add(
                "Поставщики", null,
                (s, e) => OpenForm<SupplierListForm>());

            // Операции
            var operationsMenu = new ToolStripMenuItem("Операции");

            operationsMenu.DropDownItems.Add(
                "Поступления товаров", null,
                (s, e) => OpenForm<ProductBatchListForm>());

            operationsMenu.DropDownItems.Add(
                "Заявки на пополнение", null,
                (s, e) => OpenForm<ReplenishmentRequestListForm>());

            operationsMenu.DropDownItems.Add(
                "Продажи", null,
                (s, e) => OpenForm<SaleListForm>());

            // Отчёты
            var reportsMenu = new ToolStripMenuItem("Отчёты");

            menuStrip.Items.Add(directoriesMenu);
            menuStrip.Items.Add(operationsMenu);
            menuStrip.Items.Add(reportsMenu);

            MainMenuStrip = menuStrip;
            Controls.Add(menuStrip);
        }

        private void OpenForm<TForm>()
            where TForm : Form
        {
            var form = serviceProvider.GetRequiredService<TForm>();

            form.ShowDialog(this);
        }
    }
}


