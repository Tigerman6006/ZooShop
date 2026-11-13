using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooShop.Entities;

namespace ZooShop.Repositories.Interfaces
{
    public interface ISaleRepository : IReadRepository<Sale, int>
    {
        void Add(Sale sale);
        IEnumerable<Sale> GetByPeriod(DateTime start, DateTime end);
    }
}
