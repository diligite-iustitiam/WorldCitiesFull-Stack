using MediatR;

namespace WorldCities.Application.Countries.Commands.UpdateCountry
{
    public class UpdateCountryCommand : IRequest
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? ISO2 { get; set; }
        public string? ISO3 { get; set; }
    }
}
