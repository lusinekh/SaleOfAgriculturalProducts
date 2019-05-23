using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaleOfAgriculturalProducts.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirtDate { get; set; }

        public String FhoneNamber { get; set; }

        public String Adres { get; set; }

        public string Gender { get; set; }

        public IList<ApplicationUserProduct> ApplicationUserProducts { get; set; }
    }
   
}
