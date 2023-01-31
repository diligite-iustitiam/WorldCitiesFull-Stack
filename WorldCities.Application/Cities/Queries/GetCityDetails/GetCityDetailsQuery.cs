using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldCities.Application.Cities.Queries.GetCityDetails
{
    public class GetCityDetailsQuery : IRequest<CityDetailsVm>
    {
        public int Id { get; set; }

    }
    

}

