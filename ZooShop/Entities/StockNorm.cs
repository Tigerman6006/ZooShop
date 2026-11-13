using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooShop.Entities
{
    public class StockNorm
    {
        private int minimumStockLevel;
        private int maximumStockLevel;
        private int reviewPeriod;
        private StockNorm(int minimumStockLevel, int maximumStockLevel, int reviewPeriod)
        {
            this.minimumStockLevel = minimumStockLevel;
            this.maximumStockLevel = maximumStockLevel;
            this.reviewPeriod = reviewPeriod;
        }
        public static StockNorm CreateStockNorm(int minimumStockLevel, int maximumStockLevel, int reviewPeriod)
        {
            return new StockNorm(minimumStockLevel, maximumStockLevel, reviewPeriod);
        }
        public int MinimumStockLevel
        {
            get { return minimumStockLevel; }
            set { minimumStockLevel = value; }
        }
        public int MaximumStockLevel
        {
            get { return maximumStockLevel; }
            set { maximumStockLevel = value; }
        }
        public int ReviewPeriod
        {
            get{ return reviewPeriod; }
            set { reviewPeriod = value; }
        }
        public bool isThresholdExceeded(int currentStock)
        {
            return currentStock < minimumStockLevel;
        }
    }
}
