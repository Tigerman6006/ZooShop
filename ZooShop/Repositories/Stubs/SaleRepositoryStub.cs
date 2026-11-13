using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooShop.Entities;
using ZooShop.Repositories.Interfaces;

namespace ZooShop.Repositories.Stubs
{
    public class SaleRepositoryStub : ISaleRepository
    {
        public Sale? GetById(int id)
            => throw new NotImplementedException();

        public IEnumerable<Sale> GetAll()
            => throw new NotImplementedException();

        public void Add(Sale sale)
            => throw new NotImplementedException();

        public IEnumerable<Sale> GetByPeriod(DateTime start, DateTime end)
            => throw new NotImplementedException();
    }
}
