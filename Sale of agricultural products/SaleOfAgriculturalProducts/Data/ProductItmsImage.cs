using System;
using System.Collections.Generic;

namespace SaleOfAgriculturalProducts.Models
{
    public class ProductItmsImage
    {
        public Guid ProductItmsImageId { get; set; }

        public string Path { get; set; }

        public string ImageName { get; set; }

        public string Size { get; set; }

        public string Exstention { get; set; }

        public IList<Product> Products { get; set; }


    }
}