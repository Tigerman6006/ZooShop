using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooShop.Entities
{
    public class Sale
    {
        private int receiptNumber;
        private DateTime saleDate;
        private int amount;
        private string paymantMethod;
        private List<SaleItem> saleItems;
        private Sale(int receiptNumber, DateTime saleDate, int amount, string paymantMethod, List<SaleItem> saleItems)
        {
            this.receiptNumber = receiptNumber;
            this.saleDate = saleDate;
            this.amount = amount;
            this.paymantMethod = paymantMethod;
            this.saleItems = saleItems;
        }
        public static Sale CreateSale(int receiptNumber, int amount, string paymantMethod, List<SaleItem> saleItems)
        {
            return new Sale(receiptNumber, DateTime.Now, amount, paymantMethod, saleItems);
        }
        public int ReceiptNumber
        {
            get { return receiptNumber; }
            set { receiptNumber = value; }
        }
        public DateTime SaleDate
        {
            get { return saleDate; }
            set {
                if (value < DateTime.Now)
                {
                    saleDate = value;
                }
            }
        }
        public int Amount
        {
            get { return amount; }
            set { amount = value; }
        }
        public string PaymantMethod
        {
            get { return paymantMethod; }
            set {
                if (!string.IsNullOrEmpty(value))
                {
                    paymantMethod = value;
                }
            }
        }
        public List<SaleItem> SaleItems
        {
            get { return saleItems; }
            set { saleItems = value; }
        }
    }
}
