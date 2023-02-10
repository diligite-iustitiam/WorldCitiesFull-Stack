using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldCities.Application.Common.Mappings;
using WorldCities.Domain;

namespace WorldCities.Application.Countries.Queries.GetCountryDetails
{
    public class CountryDetailsVm : IMapWith<Country>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? ISO2 { get; set; }
        public string? ISO3 { get; set; }
        public virtual List<City>? Cities { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Country, CountryDetailsVm>()
                .ForMember(countryCommand => countryCommand.Id,
                    opt => opt.MapFrom(countryDto => countryDto.Id))
                .ForMember(countryCommand => countryCommand.Name,
                    opt => opt.MapFrom(countryDto => countryDto.Name))
                .ForMember(countryCommand => countryCommand.ISO2,
                    opt => opt.MapFrom(countryDto => countryDto.ISO2))
                .ForMember(countryCommand => countryCommand.ISO3,
                    opt => opt.MapFrom(countryDto => countryDto.ISO3))
                .ForMember(countryCommand => countryCommand.Cities,
                    opt => opt.MapFrom(countryDto => countryDto.Cities));
        }
    }
}
