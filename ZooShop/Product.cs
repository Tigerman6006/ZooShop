using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooShop
{
    public class Product:Salable
    {
        private int productCode;
        private DateTime expirationDate;
        private StockNorm stockNorm;
        private StorageConditions storageConditions; 
        private Product(int productCode, string name, decimal purchasePrice, decimal sellingPrice, DateTime expirationDate, StockNorm stockNorm, StorageConditions storageConditions)
        {
            this.productCode = productCode;
            this.name = name;
            this.purchasePrice = purchasePrice;
            this.sellingPrice = sellingPrice;
            this.expirationDate = expirationDate;
            this.stockNorm = stockNorm;
            this.storageConditions = storageConditions;
        }
        public static Product CreateProduct(int productCode, string name, decimal purchasePrice, decimal sellingPrice, StockNorm stockNorm, StorageConditions storageConditions)
        {
            return new Product(productCode, name, purchasePrice, sellingPrice, DateTime.Now, stockNorm, storageConditions);
        }
        public int ProductCode
        {
            get { return productCode; }
            set { productCode = value; }
        }
        public DateTime ExpirationDate
        {
            get { return expirationDate; }
            set { 
                if(value < DateTime.Now)
                {
                    expirationDate = value;
                }
            }
        }
        public StockNorm StockNorm
        {
            get { return stockNorm; }
            set { if (value is not null) { stockNorm = value; } }
        }
        public StorageConditions StorageConditions
        {
            get { return storageConditions;}
            set { if (storageConditions is not null) { storageConditions = value; } }
        }
        public int CalculateRemainingStock()
        {
            return ProductBatch.GetAllBatches()
                .Where(batch => batch.Products.ProductCode == this.ProductCode)
                .Sum(batch => batch.RemainingQuantity);
        }
        public bool RequiresReplenishment()
        {
            int currentStock = CalculateRemainingStock();

            return StockNorm.isThresholdExceeded(currentStock);
        }
    }
}
