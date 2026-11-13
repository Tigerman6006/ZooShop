using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooShop.Repositories.Interfaces;

namespace ZooShop.Repositories.Stubs
{
    public class RepositoryStub<TEntity, TKey>
    : IRepository<TEntity, TKey>
    {
        public TEntity? GetById(TKey id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Add(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(TKey id)
        {
            throw new NotImplementedException();
        }
    }
}
