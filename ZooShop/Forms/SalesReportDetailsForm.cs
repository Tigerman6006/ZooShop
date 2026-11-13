using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ZooShop.Forms;

namespace ZooShop;
public partial class SalesReportDetailsForm : Form
{
    private readonly List<SalesReportRow> _rows;
    private readonly DateTime _start;
    private readonly DateTime _end;

    public SalesReportDetailsForm(
        List<SalesReportRow> rows,
        DateTime start,
        DateTime end)
    {
        InitializeComponent();

        _rows = rows;
        _start = start;
        _end = end;

        LoadReport();
    }

    private void LoadReport()
    {
        lblPeriod.Text =
            $"Период: {_start:dd.MM.yyyy} — {_end:dd.MM.yyyy}";

        dgvReport.DataSource = _rows
            .Select(x => new
            {
                Наименование = x.Name,
                Количество = x.Quantity,
                Выручка = x.Revenue.ToString("N2")
            })
            .ToList();

        int totalQuantity = _rows.Sum(x => x.Quantity);
        decimal totalRevenue = _rows.Sum(x => x.Revenue);

        lblTotalQuantity.Text =
            $"Общее количество: {totalQuantity}";

        lblTotalRevenue.Text =
            $"Общая выручка: {totalRevenue:N2}";
    }

    private void btnClose_Click(object sender, EventArgs e)
    {
        Close();
    }
}
