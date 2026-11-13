using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ZooShop.Entities;
using ZooShop.Forms;
using ZooShop.Repositories.Interfaces;

namespace ZooShop;
public partial class SalesReportForm : Form
{
    private readonly ISaleRepository _saleRepository;
    private readonly ISaleItemRepository _saleItemRepository;
    private readonly IProductCategoryRepository _categoryRepository;
    private readonly IServiceProvider _serviceProvider;
    private List<ProductCategory>? categories;

    public SalesReportForm(
        ISaleRepository saleRepository,
        ISaleItemRepository saleItemRepository,
        IProductCategoryRepository categoryRepository,
        IServiceProvider serviceProvider)
    {
        InitializeComponent();

        _saleRepository = saleRepository;
        _saleItemRepository = saleItemRepository;
        _categoryRepository = categoryRepository;
        _serviceProvider = serviceProvider;

        LoadCategories();
        cmbGrouping.SelectedIndex = 0;
        UpdateCategoryAvailability();
    }

    private void LoadCategories()
    {
        categories = _categoryRepository.GetAll().ToList();

        cmbCategory.DataSource = categories;
        cmbCategory.DisplayMember = "CategoryName";
        cmbCategory.ValueMember = "CategoryCode";
        cmbCategory.SelectedIndex = -1;
    }

    private void cmbGrouping_SelectedIndexChanged(
        object sender, EventArgs e)
    {
        UpdateCategoryAvailability();
    }

    private void UpdateCategoryAvailability()
    {
        bool categoryGrouping =
            cmbGrouping.SelectedIndex == 1;

        cmbCategory.Enabled = categoryGrouping;
    }

    private void btnGenerate_Click(object sender, EventArgs e)
    {
        DateTime start = dtpStart.Value.Date;
        DateTime end = dtpEnd.Value.Date;

        if (start > end)
        {
            MessageBox.Show(
                "Начало периода не может быть позже его окончания.",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            return;
        }

        var sales = _saleRepository
            .GetByPeriod(start, end.AddDays(1).AddTicks(-1))
            .ToList();

        if (sales.Count == 0)
        {
            MessageBox.Show(
                "За выбранный период продаж не найдено.",
                "Отчёт",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            return;
        }

        var allItems = new List<SaleItem>();

        foreach (var sale in sales)
        {
            var items = _saleItemRepository
                .GetBySale(sale.ReceiptNumber);

            allItems.AddRange(items);
        }

        List<SalesReportRow> rows;

        if (cmbGrouping.SelectedIndex == 1)
        {
            if (cmbCategory.SelectedItem == null)
            {
                MessageBox.Show(
                    "Выберите категорию.",
                    "Отчёт",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            int categoryCode =
                (int)cmbCategory.SelectedValue;

            rows = BuildCategoryReport(
                allItems, categories[categoryCode]);
        }
        else
        {
            rows = BuildProductReport(allItems);
        }

        if (rows.Count == 0)
        {
            MessageBox.Show(
                "Для выбранных параметров нет данных.",
                "Отчёт",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            return;
        }

        var detailsForm =
            ActivatorUtilities.CreateInstance<SalesReportDetailsForm>(
                _serviceProvider,
                rows,
                start,
                end);

        detailsForm.ShowDialog(this);
    }

    private List<SalesReportRow> BuildProductReport(
        List<SaleItem> items)
    {
        return items
            .GroupBy(x => x.Salable.Name)
            .Select(group => new SalesReportRow
            {
                Name = group.Key,
                Quantity = group.Sum(x => x.Quantity),
                Revenue = group.Sum(x =>
                    x.Price * x.Quantity * (1 - x.Discount / 100m))
            })
            .OrderByDescending(x => x.Revenue)
            .ToList();
    }

    private List<SalesReportRow> BuildCategoryReport(
        List<SaleItem> items,
        ProductCategory category)
    {
        return items
            .Where(x =>
                x.Salable is Product product && category.Products is not null && category.Products.Contains(product))
            .GroupBy(x => x.Salable.Name)
            .Select(group => new SalesReportRow
            {
                Name = group.Key,
                Quantity = group.Sum(x => x.Quantity),
                Revenue = group.Sum(x =>
                    x.Price * x.Quantity * (1 - x.Discount / 100m))
            })
            .OrderByDescending(x => x.Revenue)
            .ToList();
    }
}
