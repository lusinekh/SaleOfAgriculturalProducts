using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaleOfAgriculturalProduct.Services.ProductItmsImageService
{
    public static class ProductItmsImageServiceExtensions
    {
        public static IServiceCollection ProductItmsImageService(this IServiceCollection serviceCollection)
        {
            return serviceCollection.AddScoped<IProductItmsImageService<Guid>, ProductItmsImageService>();
        }
    }
}
