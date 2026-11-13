using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooShop.Entities;
using ZooShop.Repositories.Interfaces;

namespace ZooShop.Repositories.Stubs
{
    public class SaleItemRepositoryStub : ISaleItemRepository
    {
        public SaleItem? GetById(int id)
            => throw new NotImplementedException();

        public IEnumerable<SaleItem> GetAll()
            => throw new NotImplementedException();

        public void Add(SaleItem item)
            => throw new NotImplementedException();

        public IEnumerable<SaleItem> GetBySale(int receiptNumber)
            => throw new NotImplementedException();
    }
}
