using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using WorldCities.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WorldCities.Application.Common.Exceptions;
using WorldCities.Domain;

namespace WorldCities.Application.Cities.Queries.GetCityDetails
{
    public class GetCityDetailsQueryHandler : IRequestHandler<GetCityDetailsQuery, CityDetailsVm>
    {
        private readonly IMapper _mapper;
        private readonly IWorldCitiesDbContext _context;

        public GetCityDetailsQueryHandler(IMapper mapper, IWorldCitiesDbContext context)
        {
            _mapper = mapper;
            _context = context; 
        }

        public async Task<CityDetailsVm> Handle(GetCityDetailsQuery request,
           CancellationToken cancellationToken)
        {
            var entity = await _context.Cities
                .FirstOrDefaultAsync(city =>
                city.Id == request.Id, cancellationToken);

            if (entity == null || entity.Id != request.Id)
            {
                throw new NotFoundException(nameof(City), request.Id);
            }

            return _mapper.Map<CityDetailsVm>(entity);
        }
    }
}
