using AutoMapper;
using WorldCities.Application.Common.Mappings;
using WorldCities.Domain;

namespace WorldCities.Application.Cities.Queries.GetCityList
{
    public class CityLookupDto : IMapWith<City>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Name_ASCII { get; set; }
        public decimal Lat { get; set; }
        public decimal Lon { get; set; }
        public int CountryId { get; set; }
        public virtual Country? Country { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<City, CityLookupDto>()
                .ForMember(cityCommand => cityCommand.Id,
                    opt => opt.MapFrom(cityDto => cityDto.Id))
                .ForMember(cityCommand => cityCommand.Name,
                    opt => opt.MapFrom(cityDto => cityDto.Name))
                .ForMember(cityCommand => cityCommand.Name_ASCII,
                    opt => opt.MapFrom(cityDto => cityDto.Name_ASCII))
                .ForMember(cityCommand => cityCommand.Lat,
                    opt => opt.MapFrom(cityDto => cityDto.Lat))
                .ForMember(cityCommand => cityCommand.Lon,
                    opt => opt.MapFrom(cityDto => cityDto.Lon))
                .ForMember(cityCommand => cityCommand.CountryId,
                    opt => opt.MapFrom(cityDto => cityDto.CountryId))
                .ForMember(cityCommand => cityCommand.Country,
                    opt => opt.MapFrom(cityDto => cityDto.Country));
        }
    }
}
