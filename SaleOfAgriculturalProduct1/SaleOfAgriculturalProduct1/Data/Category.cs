using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaleOfAgriculturalProduct1.Data
{
    public class Category
    {
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }
        public IList<Product> Products { get; set; }

    }
}
