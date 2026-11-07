using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooShop
{
    public class SaleItem
    {
        private int id;
        private string name;
        private int quantity;
        private float price;
        private float discount;
        private SaleItem(int id, string name,  int quantity, float price, float discount)
        {
            this.id = id;
            this.name = name;
            this.quantity = quantity;
            this.price = price;
            this.discount = discount;
        }
        public static SaleItem CreateSaleItem(int id, string name, int quantity, float price, float discount)
        {
            return new SaleItem(id, name, quantity, price, discount);
        }
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Name
        {
            get { return name; }
            set { if (!string.IsNullOrEmpty(value)) { name = value; } }
        }
        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }
        public float Price
        {
            get { return price; }
            set { price = value; }
        }
        public float Discount
        {
            get { return discount; }
            set { discount = value; }
        }
    }
}
