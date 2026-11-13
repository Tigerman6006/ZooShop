using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using ZooShop.Repositories.Interfaces;
using ZooShop.Repositories.Stubs;

namespace ZooShop
{

    

    public static class DependencyInjection
    {
        public static ServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            // Справочники
            services.AddScoped<
                IProductCategoryRepository,
                ProductCategoryRepositoryStub>();

            services.AddScoped<
                ISupplierRepository,
                SupplierRepositoryStub>();

            // Каталог
            services.AddScoped<
                IProductRepository,
                ProductRepositoryStub>();

            services.AddScoped<
                IAnimalRepository,
                AnimalRepositoryStub>();

            // Складские операции
            services.AddScoped<
                IProductBatchRepository,
                ProductBatchRepositoryStub>();

            services.AddScoped<
                IReplenishmentRequestRepository,
                ReplenishmentRequestRepositoryStub>();

            // Продажи
            services.AddScoped<
                ISaleRepository,
                SaleRepositoryStub>();

            services.AddScoped<
                ISaleItemRepository,
                SaleItemRepositoryStub>();

            return services.BuildServiceProvider();
        }
    }

}
