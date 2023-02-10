using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldCities.Application.Common.Exceptions;
using WorldCities.Application.Interfaces;
using WorldCities.Domain;

namespace WorldCities.Application.Countries.Queries.GetCountryDetails
{
    public  class GetCountryDetailsQueryHandler : IRequestHandler<GetCountryDetailsQuery, CountryDetailsVm>
    {
        private readonly IMapper _mapper;
        private readonly IWorldCitiesDbContext _context;

        public GetCountryDetailsQueryHandler(IMapper mapper, IWorldCitiesDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<CountryDetailsVm> Handle(GetCountryDetailsQuery request,
           CancellationToken cancellationToken)
        {
            var entity = await _context.Countries
                .FirstOrDefaultAsync(country =>
                country.Id == request.Id, cancellationToken);

            if (entity == null || entity.Id != request.Id)
            {
                throw new NotFoundException(nameof(Country), request.Id);
            }

            return _mapper.Map<CountryDetailsVm>(entity);
        }
    }
}
