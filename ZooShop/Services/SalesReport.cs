using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooShop.Entities;

namespace ZooShop.Services
{
    public class SalesReport
    {
        private DateTime periodStart;
        private DateTime periodEnd;
        private ProductCategory? grouping;
        private SalesReport(DateTime periodStart, DateTime periodEnd, ProductCategory? grouping)
        {
            this.periodStart = periodStart;
            this.periodEnd = periodEnd;
            this.grouping = grouping;
        }
        public static SalesReport GenerateByPeriod(DateTime periodStart, DateTime periodEnd)
        {
            return new SalesReport(periodStart, periodEnd, null);
        }
        public static SalesReport GenerateByCategory(DateTime periodStart, DateTime periodEnd, ProductCategory? grouping)
        {
            return new SalesReport(periodStart, periodEnd, grouping);
        }
        public DateTime PeriodStart
        {
            get { return periodStart; }
            set { periodStart = value; }
        }
        public DateTime PeriodEnd
        {
            get { return periodEnd; }
            set { periodEnd = value; }
        }
        public ProductCategory? Grouping
        {
            get => grouping;
            set
            {
                if (value is not null)
                {
                    grouping = value;
                }
            }
        }
    }
}
