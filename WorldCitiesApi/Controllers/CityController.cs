using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WorldCities.Application.Cities.Commands.CreateCity;
using WorldCities.Application.Cities.Commands.UpdateCity;
using WorldCities.Application.Cities.Queries.GetCityDetails;
using WorldCities.Application.Cities.Queries.GetCityList;
using WorldCities.Application.Interfaces;
using WorldCities.Domain;
using WorldCitiesApi.Data;
using WorldCitiesApi.Models;

namespace WorldCitiesApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CityController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IWorldCitiesDbContext _context;

        public CityController(IMapper mapper, IWorldCitiesDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<ApiResult<CityDTO>>> GetAllCities(
                 int pageIndex = 0,
                 int pageSize = 10,
                 string? sortColumn = null,
                 string? sortOrder = null,
                 string? filterColumn = null,
                 string? filterQuery = null)
        {
            return await ApiResult<CityDTO>.CreateAsync(
                    _context.Cities.AsNoTracking()
                    .Select(c => new CityDTO()
                    {
                        Id = c.Id,
                        Name = c.Name,
                        CountryId = c.CountryId,
                        CountryName = c.Country.Name,
                        Name_ASCII = c.Name_ASCII,
                        Lat = c.Lat,
                        Lon = c.Lon
                    }),
                    pageIndex,
                    pageSize,
                    sortColumn,
                    sortOrder,
                    filterColumn,
                    filterQuery);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<CityDetailsVm>> GetCityDetails(int id)
        {
            var query = new GetCityDetailsQuery
            {
                Id = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
        
        [HttpPut]
        public async Task<IActionResult> EditCity(UpdateDTOCity updateCityDto)
        {
            var command = _mapper.Map<UpdateCityCommand>(updateCityDto);
            await Mediator.Send(command);
            return Ok(updateCityDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCity([FromForm] CreateDTOCity createCity)
        {
            var command = _mapper.Map<CreateCityCommand>(createCity);          
            var city = await Mediator.Send(command);
            return Ok(city);
        }

        [HttpPost]     
        public bool IsDupeCity(City city)
        {
            return _context.Cities.Any(e => e.Name == city.Name
            && e.Lat == city.Lat
            && e.Lon == city.Lon
            && e.CountryId == city.CountryId
            && e.Id != city.Id);
        }

        
    }
}
