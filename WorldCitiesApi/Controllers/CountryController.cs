using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using WorldCities.Application.Cities.Queries.GetCityList;
using WorldCities.Application.Countries.Commands.CreateCountry;
using WorldCities.Application.Countries.Commands.UpdateCountry;
using WorldCities.Application.Countries.Queries.GetCountryDetails;
using WorldCities.Application.Interfaces;
using WorldCities.Domain;
using WorldCitiesApi.Data;
using WorldCitiesApi.Models;

namespace WorldCitiesApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CountryController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IWorldCitiesDbContext _context;
        public CountryController(IWorldCitiesDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResult<CountryDTO>>> GetAllCountries(
                int pageIndex = 0,
                int pageSize = 10,
                string? sortColumn = null,
                string? sortOrder = null,
                string? filterColumn = null,
                string? filterQuery = null)
        {
            return await ApiResult<CountryDTO>.CreateAsync(
                    _context.Countries.AsNoTracking()
                        .Select(c => new CountryDTO()
                        {
                            Id = c.Id,
                            Name = c.Name,
                            ISO2 = c.ISO2,
                            ISO3 = c.ISO3,
                            NumberOfCities = c.Cities.Count()
                        }),
                    pageIndex,
                    pageSize,
                    sortColumn,
                    sortOrder,
                    filterColumn,
                    filterQuery);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<CountryDetailsVm>> GetCountryDetails(int id)
        {
            var query = new GetCountryDetailsQuery
            {
                Id = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPut]
        public async Task<IActionResult> EditCountry(UpdateDTOCountry updateCountryDto)
        {
            var command = _mapper.Map<UpdateCountryCommand>(updateCountryDto);
            await Mediator.Send(command);
            return Ok(updateCountryDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCountry([FromForm] CreateDTOCountry createCountry)
        {
            var command = _mapper.Map<CreateCountryCommand>(createCountry);
            var country = await Mediator.Send(command);
            return Ok(country);
        }


        [HttpPost]        
        public bool IsDupeField(
           int countryId,
           string fieldName,
           string fieldValue)
        {
            // Default approach (using strongly-typed LAMBA expressions)
            //switch (fieldName)
            //{
            // case "name":
            // return _context.Countries.Any(c => c.Name == fieldValue);
            // case "iso2":
            // return _context.Countries.Any(c => c.ISO2 == fieldValue);
            // case "iso3":
            // return _context.Countries.Any(c => c.ISO3 == fieldValue);
            // default:
            // return false;
            //}

            // Alternative approach (using System.Linq.Dynamic.Core)
            return (ApiResult<Country>.IsValidProperty(fieldName, true))
                ? _context.Countries.Any(
                    string.Format("{0} == @0 && Id != @1", fieldName),
                    fieldValue,
                    countryId)
                : false;
        }
    }
}
