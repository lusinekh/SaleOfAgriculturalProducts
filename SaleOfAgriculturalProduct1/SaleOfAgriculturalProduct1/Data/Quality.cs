using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaleOfAgriculturalProduct1.Data
{
    public class Quality
    {
        public Guid QualityId { get; set;}
        public string QualityName { get; set; }
        public IList<Product> Products { get; set; }
    }
}
