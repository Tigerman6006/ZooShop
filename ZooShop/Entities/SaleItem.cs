using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooShop.Entities
{
    public class SaleItem
    {
        private int id;
        private Salable salable;
        private int quantity;
        private decimal price;
        private decimal discount;
        private SaleItem(int id,Salable salable, int quantity,decimal price, decimal discount)
        {
            this.id = id;
            this.salable = salable;
            this.quantity = quantity;
            this.price = price;
            this.discount = discount;
        }
        public static SaleItem CreateSaleItem(int id, Salable salable, int quantity, decimal price, decimal discount)
        {
            return new SaleItem(id, salable,  quantity, price, discount);
        }
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }
        public decimal Price
        {
            get { return price; }
            set { price = value; }
        }
        public decimal Discount
        {
            get { return discount; }
            set { discount = value; }
        }
        public Salable Salable
        {
            get{ return salable; }
            set { if (value is not null) { salable = value; } }
        }

    }
}
