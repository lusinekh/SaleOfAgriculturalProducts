using Microsoft.EntityFrameworkCore;
using SaleOfAgriculturalProduct.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaleOfAgriculturalProduct.Services.ProductItemService
{
    public class ProductItmsService : IProductItmsService<Guid>
    {
        private readonly ApplicationDbContext _context;

        public ProductItmsService (ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductItem<Guid>>> GetItemsAsync()
        {
            ProductItmsImage entity1 = new ProductItmsImage
            {
                

        Path ="ttttttttttt",

       ImageName ="rrrrrrrrr",

        Size =89999999999,

         Exstention="gggggggggggggggg" 
       
    };
            await _context.ProductItmsImages.AddAsync(entity1);

            await _context.SaveChangesAsync();

           
            var query = _context.Products.AsQueryable();
            var queri1 = _context.ProductItmsImages.AsQueryable();
            var entities = await query.ToListAsync();
            var entit= await queri1.ToListAsync();
            return entities.Select(entity => new ProductItem<Guid>
            {
               
                Category = entity.Category,
                MeasurementUnit = entity.MeasurementUnit,
                PriceUnit = entity.PriceUnit,
                Count = entity.Count,
                Quality = entity.Quality,
                ShowAllow = entity.ShowAllow,
                ProductionTime = entity.ProductionTime,
                ProductItmsImageId = entity.ProductItmsImageId,              

                FirstName =entity.FirstName,
                LastName =entity.FirstName,
                BirtDate=entity.BirtDate,
                FhoneNamber=entity.FhoneNamber,
                Adress =entity.Adress
    });           
        }
    }
}
