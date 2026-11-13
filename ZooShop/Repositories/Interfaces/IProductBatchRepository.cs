using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooShop.Entities;

namespace ZooShop.Repositories.Interfaces
{
    public interface IProductBatchRepository : IReadRepository<ProductBatch, int>
    {
        IEnumerable<ProductBatch> GetByProduct(int productCode);
        void Add(ProductBatch batch);
        void Update(ProductBatch batch);
    }
}
