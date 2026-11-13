using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooShop.Entities;
using ZooShop.Repositories.Interfaces;

namespace ZooShop.Repositories.Stubs
{
    public class AnimalRepositoryStub : RepositoryStub<Animal, int>, IAnimalRepository
    {
        public IEnumerable<Animal> GetAvailableAnimals()
        {
            throw new NotImplementedException();
        }
    }
}
