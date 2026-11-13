using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooShop.Entities;
using ZooShop.Repositories.Interfaces;

namespace ZooShop.Repositories.Stubs
{
    public class ProductBatchRepositoryStub : IProductBatchRepository
    {
        public ProductBatch? GetById(int id)
            => throw new NotImplementedException();

        public IEnumerable<ProductBatch> GetAll()
            => throw new NotImplementedException();

        public IEnumerable<ProductBatch> GetByProduct(int productCode)
            => throw new NotImplementedException();

        public void Add(ProductBatch batch)
            => throw new NotImplementedException();
        public void Update(ProductBatch batch)
            => throw new NotImplementedException();
    }

}
