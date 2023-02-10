using MediatR;

namespace WorldCities.Application.Countries.Commands.CreateCountry
{
    public class CreateCountryCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? ISO2 { get; set; }
        public string? ISO3 { get; set; }
    }
}
