using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaleOfAgriculturalProduct1.Data
{
    public class ProducCategoryview
    {
      public IEnumerable<Product> Products { get; set; }
      public  IEnumerable<Category> Categorys { get; set; }

    }
}
