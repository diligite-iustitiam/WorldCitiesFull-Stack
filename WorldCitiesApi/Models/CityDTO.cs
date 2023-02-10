using WorldCities.Application.Common.Mappings;
using WorldCities.Domain;

namespace WorldCitiesApi.Models
{
    public class CityDTO : IMapWith<City>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Name_ASCII { get; set; }
        public decimal Lat { get; set; }
        public decimal Lon { get; set; }
        public int CountryId { get; set; }
        public string? CountryName { get; set; }    
    }
}
