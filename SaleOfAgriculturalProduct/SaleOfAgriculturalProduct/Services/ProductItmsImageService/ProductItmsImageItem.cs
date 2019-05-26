using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaleOfAgriculturalProduct.Services
{
    public class ProductItmsImage<T>
    {
        public T ProductItmsImageId { get; set; }

        public string Path { get; set; }

        public string ImageName { get; set; }

        public decimal Size { get; set; }

        public string Exstention { get; set; }


    }
}
