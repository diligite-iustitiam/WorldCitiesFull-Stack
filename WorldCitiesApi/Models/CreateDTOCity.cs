using AutoMapper;
using WorldCities.Application.Cities.Commands.CreateCity;
using WorldCities.Application.Common.Mappings;

namespace WorldCitiesApi.Models
{
    public class CreateDTOCity : IMapWith<CreateCityCommand>
    {       
        public string? Name { get; set; }
        public string? Name_ASCII { get; set; }
        public decimal Lat { get; set; }
        public decimal Lon { get; set; }
        public int CountryId { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateDTOCity, CreateCityCommand>()               
                .ForMember(cityCommand => cityCommand.Name,
                    opt => opt.MapFrom(cityDto => cityDto.Name))
                .ForMember(cityCommand => cityCommand.Name_ASCII,
                    opt => opt.MapFrom(cityDto => cityDto.Name_ASCII))
                .ForMember(cityCommand => cityCommand.Lat,
                    opt => opt.MapFrom(cityDto => cityDto.Lat))
                .ForMember(cityCommand => cityCommand.Lon,
                    opt => opt.MapFrom(cityDto => cityDto.Lon))
                .ForMember(cityCommand => cityCommand.CountryId,
                    opt => opt.MapFrom(cityDto => cityDto.CountryId));
        }

    }
}
