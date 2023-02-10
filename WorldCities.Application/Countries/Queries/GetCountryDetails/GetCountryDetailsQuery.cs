using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldCities.Application.Countries.Queries.GetCountryDetails
{
    public class GetCountryDetailsQuery : IRequest<CountryDetailsVm>
    {
        public int Id { get; set; }

    }
}
