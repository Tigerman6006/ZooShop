using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooShop.Entities;

namespace ZooShop.Services
{
    public class StockControl
    {
        private StockNorm stockNorm;
        private StockControl(StockNorm stockNorm)
        {
            this.stockNorm = stockNorm;
        }
        public static StockControl CreateControl(StockNorm stockNorm)
        {
            return new StockControl(stockNorm);
        }
        public StockNorm StockNorm
        {
            get { return stockNorm; }
            set { if (value is not null) { stockNorm = value; } }
        }
        public Dictionary<int, int> CheckStockLevels()
        {
            Dictionary<int, int> stockLevels = new Dictionary<int, int>();

            var batches = ProductBatch.GetAllBatches();

            var groupedProducts = batches.GroupBy(
                batch => batch.Products.ProductCode
            );

            foreach (var group in groupedProducts)
            {
                int currentStock = group.Sum(
                    batch => batch.RemainingQuantity
                );

                Product product = group.First().Products;

                if (product.StockNorm.isThresholdExceeded(currentStock))
                {
                    stockLevels.Add(product.ProductCode, currentStock);
                }
            }

            return stockLevels;
        }
        public ReplenishmentRequest CreateReplenishmentRequest(int requiredQuantity, Product product)
        {
            if (requiredQuantity <= 0)
            {
                throw new ArgumentException(
                    "Required quantity must be greater than zero."
                );
            }

            if (product is null)
            {
                throw new ArgumentNullException(nameof(product));
            }

            return ReplenishmentRequest.CreateRequest(
                requiredQuantity,
                product
            );
        }
    }
}
