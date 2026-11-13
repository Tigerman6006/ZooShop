using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooShop.Entities;

namespace ZooShop.Repositories.Interfaces
{
    public interface IProductRepository : IRepository<Product, int>
    {
        IEnumerable<Product> GetByCategory(int categoryCode);
    }
}
