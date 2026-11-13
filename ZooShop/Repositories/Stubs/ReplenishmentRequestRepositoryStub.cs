using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooShop.Entities;
using ZooShop.Repositories.Interfaces;

namespace ZooShop.Repositories.Stubs
{
    public class ReplenishmentRequestRepositoryStub : IReplenishmentRequestRepository
    {
        public ReplenishmentRequest? GetById(int id)
            => throw new NotImplementedException();

        public IEnumerable<ReplenishmentRequest> GetAll()
            => throw new NotImplementedException();

        public void Add(ReplenishmentRequest request)
            => throw new NotImplementedException();

        public void Update(ReplenishmentRequest request)
            => throw new NotImplementedException();

        public IEnumerable<ReplenishmentRequest> GetBySupplier(int supplierCode)
            => throw new NotImplementedException();
    }
}
