using MediatR;
using Microsoft.EntityFrameworkCore;
using WorldCities.Application.Common.Exceptions;
using WorldCities.Application.Interfaces;
using WorldCities.Domain;

namespace WorldCities.Application.Countries.Commands.UpdateCountry
{
    public class UpdateCountryCommandHandler : IRequestHandler<UpdateCountryCommand>
    {
        private readonly IWorldCitiesDbContext _context;

        public UpdateCountryCommandHandler(IWorldCitiesDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateCountryCommand request, CancellationToken cancellation)
        {
            var entity = await _context.Countries.FirstOrDefaultAsync(
                country => country.Id == request.Id, cancellation);


            if (entity == null || entity.Id != request.Id)
            {
                throw new NotFoundException(nameof(Country), request.Id);
            }

            entity.Id = request.Id;
            entity.ISO2 = request.ISO2;
            entity.ISO3 = request.ISO3;
            entity.Name = request.Name;

            await _context.SaveChangesAsync(cancellation);

            return Unit.Value;
        }
    }
}
