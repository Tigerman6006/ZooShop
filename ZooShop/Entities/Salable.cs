using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooShop.Entities
{
    public abstract class Salable
    {
        protected string name;
        protected decimal purchasePrice;
        protected decimal sellingPrice;
        
        public string Name
        {
            get { return name; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    name = value;
                }
            }
        }
        public decimal PurchasePrice
        {
            get { return purchasePrice; }
            set { purchasePrice = value; }
        }
        public decimal SellingPrice
        {
            get { return sellingPrice; }
            set { sellingPrice = value; }
        }
    }
}
