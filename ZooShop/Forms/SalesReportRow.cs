using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooShop.Forms
{
    public class SalesReportRow
    {
        public string Name { get; set; } = string.Empty;

        public int Quantity { get; set; }

        public decimal Revenue { get; set; }
    }
}
