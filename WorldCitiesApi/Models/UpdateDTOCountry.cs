using AutoMapper;
using System.Text.Json.Serialization;
using WorldCities.Application.Common.Mappings;
using WorldCities.Application.Countries.Commands.UpdateCountry;

namespace WorldCitiesApi.Models
{
    public class UpdateDTOCountry : IMapWith<UpdateCountryCommand>
    {
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string? Name { get; set; }
        [JsonPropertyName("iso2")]
        public string? ISO2 { get; set; }
        [JsonPropertyName("iso3")]
        public string? ISO3 { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateDTOCountry, UpdateCountryCommand>()
               .ForMember(countryCommand => countryCommand.Id,
               opt => opt.MapFrom(countryDto => countryDto.Id))
               .ForMember(countryCommand => countryCommand.Name,
               opt => opt.MapFrom(countryDto => countryDto.Name))
               .ForMember(countryCommand => countryCommand.ISO2,
               opt => opt.MapFrom(countryDto => countryDto.ISO2))
               .ForMember(countryCommand => countryCommand.ISO3,
               opt => opt.MapFrom(countryDto => countryDto.ISO3));
        }
    }
}
