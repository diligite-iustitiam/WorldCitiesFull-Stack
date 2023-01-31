using AutoMapper;
using AutoMapper.QueryableExtensions;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WorldCities.Application.Interfaces;

namespace WorldCities.Application.Cities.Queries.GetCityList
{
    public class GetCityListQueryHandler : IRequestHandler<GetCityListQuery, CityListVm>
    {
        private readonly IMapper? _mapper;
        private readonly IWorldCitiesDbContext? _context;
        public GetCityListQueryHandler(IMapper? mapper, IWorldCitiesDbContext? context)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<CityListVm> Handle(GetCityListQuery request,
            CancellationToken cancellationToken)
        {
            var productsQuery = await _context.Cities

                .ProjectTo<CityLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new CityListVm { Cities = productsQuery };
        }
    }
}
