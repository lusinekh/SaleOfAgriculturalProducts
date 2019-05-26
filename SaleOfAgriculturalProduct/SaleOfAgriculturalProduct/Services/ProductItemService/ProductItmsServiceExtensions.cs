using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaleOfAgriculturalProduct.Services.ProductItemService
{
    public static class ProductItmsServiceExtensions
    {
        public static IServiceCollection ProductItmsService(this IServiceCollection serviceCollection)
        {
            return serviceCollection.AddScoped<IProductItmsService<Guid>, ProductItmsService>();
        }
    }
}
