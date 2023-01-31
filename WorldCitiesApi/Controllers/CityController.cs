using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WorldCities.Application.Cities.Queries.GetCityDetails;
using WorldCities.Application.Cities.Queries.GetCityList;
using WorldCities.Application.Interfaces;

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
        public async Task<ActionResult<CityListVm>> GetAllCities()
        {
            var query = new GetCityListQuery();
            var vm = await Mediator.Send(query);
            return vm;
        }
        [HttpGet]
        public async Task<ActionResult<CityDetailsVm>> GetCityDetails(int cityId)
        {
            var query = new GetCityDetailsQuery
            {
                Id = cityId
            };
            var vm = await Mediator.Send(query);
            return vm;
        }
    }
}
