using Microsoft.EntityFrameworkCore;
using SaleOfAgriculturalProduct.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaleOfAgriculturalProduct.Services.ProductItmsImageService
{
    public class ProductItmsImageService : IProductItmsImageService<Guid>
    {
        private readonly ApplicationDbContext _context;
        public ProductItmsImageService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<ProductItmsImage<Guid>> AddAsync(ProductItmsImage<Guid> item)
        {
            var entity = new ProductItmsImage
            {
                ImageName = item.ImageName,
                Path = item.Path,
                Exstention = item.Exstention,
                Size = item.Size
            };
            await _context.ProductItmsImages.AddAsync(entity);
            
            await _context.SaveChangesAsync();
            item.ProductItmsImageId = entity.ProductItmsImageId;
            return item;           

        }

        public async Task DeleteAsync(ProductItmsImage<Guid> item)
        {
            var entity = new ProductItmsImage
            {
                ImageName = item.ImageName,
                Path = item.Path,
                Exstention = item.Exstention,
                Size = item.Size
            };
            var e = await _context.ProductItmsImages.SingleOrDefaultAsync(p => p.ProductItmsImageId==item.ProductItmsImageId);
            _context.ProductItmsImages.Remove(e);
            await _context.SaveChangesAsync();
        }

        public async Task EditAsync(ProductItmsImage<Guid> item)
        {
            var entity = await _context.ProductItmsImages.SingleOrDefaultAsync(p => p.ProductItmsImageId == item.ProductItmsImageId);

            entity.ImageName = item.ImageName;
            entity.Path = item.Path;
            entity.Exstention = item.Exstention;
            entity.Size = item.Size;
            _context.ProductItmsImages.Update(entity);
            await _context.SaveChangesAsync();           
        }

        public async Task<ProductItmsImage<Guid>> GetItem(Guid id)
        {

            var entity = await _context.ProductItmsImages.SingleOrDefaultAsync(p => p.ProductItmsImageId == id);


            return new ProductItmsImage<Guid>
            {
                ImageName = entity.ImageName,
                Path = entity.Path,
                Exstention = entity.Exstention,
                Size = entity.Size
            };
        }


     public async   Task<IEnumerable<ProductItmsImage<Guid>>> GetItemsAsync()

        {
            var query = _context.ProductItmsImages.AsQueryable();


            var entities = await query.ToListAsync();

            return entities.Select(entity => new ProductItmsImage<Guid>
            {
                ImageName = entity.ImageName,
                Path = entity.Path,
                Exstention = entity.Exstention,
                Size = entity.Size
            });
        }
    }
}
