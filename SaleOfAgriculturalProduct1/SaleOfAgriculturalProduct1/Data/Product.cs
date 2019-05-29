using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaleOfAgriculturalProduct1.Data
{
    public class Product
    {
        public Guid ProductID { get; set; }        
        public decimal PriceUnit { get; set; }
        public decimal Count { get; set; }        
        public bool ShowAllow { get; set; }
        public DateTime ProductionTime { get; set; }
        public Guid ProductItmsImageId { get; set; }
        public ProductItmsImage ProductItmsImage { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
        public Guid MeasurementUnitId { get; set; }
        public MeasurementUnit MeasureUnit { get; set; }
        public Guid QualityId { get; set; }
        public Quality Qualitys { get; set; }  
        public string FirstName { get; set; }
        public string LastName { get; set; }     
        public string FhoneNamber { get; set; }
        public string Adress { get; set; }
        public string ApplicationUserGuid { get; set; }
    }
}
