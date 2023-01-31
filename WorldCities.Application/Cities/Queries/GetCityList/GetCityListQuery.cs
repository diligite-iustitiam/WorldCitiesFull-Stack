using MediatR;

namespace WorldCities.Application.Cities.Queries.GetCityList
{
    public class GetCityListQuery : IRequest<CityListVm>
    {
        public int Id { get; set; }
    }
}
