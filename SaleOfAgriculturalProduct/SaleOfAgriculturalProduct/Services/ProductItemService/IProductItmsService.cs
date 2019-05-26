using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaleOfAgriculturalProduct.Services.ProductItemService
{
   public interface IProductItmsService<T>
    {
        Task<IEnumerable<ProductItem<T>>> GetItemsAsync();
    }
}
