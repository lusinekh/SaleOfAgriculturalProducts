using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaleOfAgriculturalProduct.Services.ProductItmsImageService
{
   public interface IProductItmsImageService<T>
    {
        Task<ProductItmsImage<T>> AddAsync(ProductItmsImage<T> item);
        Task DeleteAsync(ProductItmsImage<T> item);
        Task EditAsync(ProductItmsImage<T> item);
        Task<ProductItmsImage<T>> GetItem(T id);
        Task<IEnumerable<ProductItmsImage<T>>> GetItemsAsync();
    }
}
