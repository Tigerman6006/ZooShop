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
        private Product? product;
        private Animal? animal;
        private int quantity;
        private decimal price;
        private decimal discount;
        private SaleItem(int id,Product? product,Animal? animal,int quantity,decimal price, decimal discount)
        {
            this.id = id;
            this.product = product;
            this.animal = animal;
            this.quantity = quantity;
            this.price = price;
            this.discount = discount;
        }
        public static SaleItem CreateProductSale(int id, Product product, int quantity, decimal price, decimal discount)
        {
            return new SaleItem(id, product,null, quantity, price, discount);
        }
        public static SaleItem CreateAnimalSale(int id, Animal animal, int quantity, decimal price, decimal discount)
        {
            return new SaleItem(id, null, animal, quantity, price, discount);
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
            get { if (product is not null) { return product; } else { return animal; } }
        }
        
    }
}
