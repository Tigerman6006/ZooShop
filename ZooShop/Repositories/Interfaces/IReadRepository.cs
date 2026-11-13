using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooShop.Repositories.Interfaces
{
    public interface IReadRepository<TEntity, TKey>
    {
        TEntity? GetById(TKey id);
        IEnumerable<TEntity> GetAll();
    }
}
