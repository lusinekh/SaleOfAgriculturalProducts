using SaleOfAgriculturalProduct.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaleOfAgriculturalProduct.Services
{
    public class ProductItem<T>
    {
        public T ProductID { get; set; }
        public string Category { get; set; }
        public string MeasurementUnit { get; set; }
        public decimal PriceUnit { get; set; }
        public decimal Count { get; set; }
        public string Quality { get; set; }
        public bool ShowAllow { get; set; }
        public DateTime ProductionTime { get; set; }
        public Guid ProductItmsImageId { get; set; }
        public ProductItmsImage<T> ProductItmsImage { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirtDate { get; set; }
        public String FhoneNamber { get; set; }
        public String Adress { get; set; }
    }
}
