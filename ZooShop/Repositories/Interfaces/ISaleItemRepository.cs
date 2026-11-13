using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooShop.Entities;

namespace ZooShop.Repositories.Interfaces
{
    public interface ISaleItemRepository : IReadRepository<SaleItem, int>
    {
        void Add(SaleItem item);
        IEnumerable<SaleItem> GetBySale(int receiptNumber);
    }
}
