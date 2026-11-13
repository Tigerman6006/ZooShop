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

            services.AddScoped<
                IProductCategoryRepository,
                ProductCategoryRepositoryStub>();

            services.AddScoped<
                ISupplierRepository,
                SupplierRepositoryStub>();

            services.AddScoped<
                IProductRepository,
                ProductRepositoryStub>();

            services.AddScoped<
                IAnimalRepository,
                AnimalRepositoryStub>();

            services.AddScoped<
                IProductBatchRepository,
                ProductBatchRepositoryStub>();

            services.AddScoped<
                IReplenishmentRequestRepository,
                ReplenishmentRequestRepositoryStub>();

            services.AddScoped<
                ISaleRepository,
                SaleRepositoryStub>();

            services.AddScoped<
                ISaleItemRepository,
                SaleItemRepositoryStub>();

            services.AddTransient<MainForm>();

            return services.BuildServiceProvider();
        }
    }

}
