using MediatR;
using WorldCities.Domain;
using WorldCities.Application.Interfaces;

namespace WorldCities.Application.Countries.Commands.CreateCountry
{
    public class CreateCountryCommandHandler : IRequestHandler<CreateCountryCommand, int>
    {
        private readonly IWorldCitiesDbContext _context;

        public CreateCountryCommandHandler(IWorldCitiesDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateCountryCommand request, CancellationToken cancellationToken)
        {
            var country = new Country()
            {
                Name = request.Name,
                Id = request.Id,
                ISO2 = request.ISO2,
                ISO3 = request.ISO3
            };

             await _context.Countries.AddAsync(country);   
             await _context.SaveChangesAsync(cancellationToken);

            return country.Id;
        }
        
    }
}
