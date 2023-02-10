using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldCities.Application.Interfaces;
using WorldCities.Domain;

namespace WorldCities.Application.Cities.Commands.CreateCity
{
    public class CreateCityCommandHandler : IRequestHandler<CreateCityCommand, int>
    {
        private readonly IWorldCitiesDbContext _context;

        public CreateCityCommandHandler(IWorldCitiesDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(CreateCityCommand request, CancellationToken cancellationToken)
        {
            var city = new City()
            {
                Id = request.Id,
                Name = request.Name,
                Name_ASCII = request.Name_ASCII,
                CountryId = request.CountryId,
                Lat = request.Lat,
                Lon = request.Lon,
            };
            await _context.Cities.AddAsync(city);
            await _context.SaveChangesAsync(cancellationToken);

            return city.Id;
        }


       
    }
}
