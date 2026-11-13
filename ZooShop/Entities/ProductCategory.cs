using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ZooShop.Entities
{
    public class ProductCategory
    {
        private int categoryCode;
        private string categoryName;
        private List<Product> products;
        private ProductCategory(int Code, string Name, List<Product> products)
        {
            categoryCode = Code;
            categoryName = Name;
            this.products = products;
        }

        public static ProductCategory CreateCategory(int Code, string Name, List<Product> products)
        {
            return new ProductCategory(Code, Name, products);
        }
        public int CategoryCode { 
            get { return categoryCode; } 
            set { categoryCode = value; } 
        }
        public string CategoryName { 
            get { return categoryName; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    categoryName = value;
                }
            }
        }
        public List<Product> Products
        {
            get { return products; }
            set {if(value != null) { products = value; } }
        }
    }
}
