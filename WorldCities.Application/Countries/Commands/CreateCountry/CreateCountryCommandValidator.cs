using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldCities.Application.Countries.Commands.CreateCountry
{
    public class CreateCountryCommandValidator : AbstractValidator<CreateCountryCommand>
    {
        public CreateCountryCommandValidator()
        {
            RuleFor(createCountryCommand => createCountryCommand.Name).NotNull();          
            RuleFor(createCountryCommand => createCountryCommand.ISO2).NotNull();
            RuleFor(createCountryCommand => createCountryCommand.ISO3).NotNull();        
        }
    }
}
