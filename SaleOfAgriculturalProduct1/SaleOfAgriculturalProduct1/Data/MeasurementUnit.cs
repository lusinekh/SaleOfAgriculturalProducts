using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaleOfAgriculturalProduct1.Data
{
    public class MeasurementUnit
    {
        public Guid MeasurementUnitId { get; set; }
        public  string Unit { get; set; }
        public IList<Product> Products { get; set; }
    }
}
