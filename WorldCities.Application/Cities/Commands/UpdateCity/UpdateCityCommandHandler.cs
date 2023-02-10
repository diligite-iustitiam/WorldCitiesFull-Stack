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

namespace WorldCities.Application.Cities.Commands.UpdateCity
{
    public class UpdateCityCommandHandler : IRequestHandler<UpdateCityCommand>
    {
        private readonly IWorldCitiesDbContext _context;

        public UpdateCityCommandHandler(IWorldCitiesDbContext context)
        {
            _context = context;
        }
       
        public async Task<Unit> Handle(UpdateCityCommand request, CancellationToken cancellationToken)
        {
            var entity =
                await _context.Cities.FirstOrDefaultAsync(city =>
                    city.Id == request.Id, cancellationToken);

            if (entity == null || entity.Id != request.Id)
            {
                throw new NotFoundException(nameof(City), request.Id);
            }

            entity.Id = request.Id;
            entity.Name = request.Name;
            entity.Name_ASCII = request.Name_ASCII;
            entity.CountryId = request.CountryId;
            entity.Lat = request.Lat;
            entity.Lon = request.Lon;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
