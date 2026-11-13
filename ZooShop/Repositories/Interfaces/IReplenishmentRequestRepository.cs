using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooShop.Entities;

namespace ZooShop.Repositories.Interfaces
{
    public interface IReplenishmentRequestRepository : IReadRepository<ReplenishmentRequest, int>
    {
        void Add(ReplenishmentRequest request);
        void Update(ReplenishmentRequest request);
        IEnumerable<ReplenishmentRequest> GetBySupplier(int supplierCode);
    }
}
