using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaleOfAgriculturalProduct1.Data
{
    public class ProductItmsImage
    {
        public Guid ProductItmsImageId { get; set; }

        public string Path { get; set; }

        public string ImageName { get; set; }

        public decimal Size { get; set; }

        public string Exstention { get; set; }

        public IList<Product> Products { get; set; }

    }
}
