using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooShop
{
    public class ProductBatch
    {
        private int batchNumber;
        private DateTime arrivalDate;
        private DateTime expirationDate;
        private int quantityReceived;
        private int remainingQuantity;
        private Product products;
        private Supplier? supplier;
        private static List<ProductBatch> allBatches = new List<ProductBatch>();
        private ProductBatch(int batchNumber, DateTime arrivalDate, DateTime expirationDate, int quantityReceived, int remainingQuantity, Product products, Supplier? supplier)
        {
            this.batchNumber = batchNumber;
            this.arrivalDate = arrivalDate;
            this.expirationDate = expirationDate;
            this.quantityReceived = quantityReceived;
            this.remainingQuantity = remainingQuantity;
            this.products = products;
            this.supplier = supplier;
        }
        public static ProductBatch CreateBatch(int batchNumber, DateTime arrivalDate, DateTime expirationDate, int quantityReceived, int remainingQuantity, Product products, Supplier? supplier)
        {
            ProductBatch batch = new ProductBatch(
                batchNumber,
                arrivalDate,
                expirationDate,
                quantityReceived,
                remainingQuantity,
                products,
                supplier);

            allBatches.Add(batch);

            return batch;
        }
        public int BatchNumber
        {
            get { return batchNumber; }
            set { batchNumber = value; }
        }
        public DateTime ArrivalDate
        {
            get{ return arrivalDate; }
            set { arrivalDate = value; }
        }
        public DateTime ExpirationDate
        {
            get { return expirationDate; }
            set {  expirationDate = value; }
        }
        public int QuantityReceived
        {
            get { return quantityReceived; }
            set { quantityReceived = value; }
        }
        public int RemainingQuantity
        {
            get { return remainingQuantity; }
            set { remainingQuantity = value; }
        }
        public Product Products
        {
            get { return products; }
            set { if (value is not null) { products = value; } }
        }
        public Supplier? Supplier
        {
            get { return supplier; }
            set { if (value is not null) { supplier = value; } }
        }
        public static List<ProductBatch> GetAllBatches()
        {
            return allBatches;
        }
        public bool isExpired(DateTime expirationDate)
        {
            return DateTime.Now > expirationDate;
        }
    }
}
