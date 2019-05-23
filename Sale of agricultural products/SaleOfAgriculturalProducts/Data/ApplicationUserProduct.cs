using SaleOfAgriculturalProducts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaleOfAgriculturalProducts.Data
{
    public class ApplicationUserProduct
    {
        public Guid ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUsers { get; set; }
        public Guid ProductId { get; set; }
        public Product Products { get; set; }
    }
}
