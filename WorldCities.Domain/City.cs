using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldCities.Domain
{
   public class City
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Name_ASCII { get; set; }      
        public decimal Lat { get; set; }    
        public decimal Lon { get; set; }       
        public int CountryId { get; set; }
        public virtual Country? Country { get; set; }
    }
}
