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
        private List<Product>? products;
        private ProductCategory(int Code, string Name)
        {
            categoryCode = Code;
            categoryName = Name;
        }
        public static ProductCategory CreateCategory(int Code, string Name)
        {
            return new ProductCategory(Code, Name);
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
        public List<Product>? Products
        {
            get { return products; }
            set {if(value != null) { products = value; } }
        }
    }
}
