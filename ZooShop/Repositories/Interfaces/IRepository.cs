using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooShop.Repositories.Interfaces
{
    public interface IRepository<TEntity, TKey> : IReadRepository<TEntity, TKey>
    {
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TKey id);
    }
}
