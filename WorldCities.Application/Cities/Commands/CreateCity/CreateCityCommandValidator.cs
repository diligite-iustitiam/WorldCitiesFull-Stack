using FluentValidation;

namespace WorldCities.Application.Cities.Commands.CreateCity
{
    public class CreateCityCommandValidator : AbstractValidator<CreateCityCommand>
    {
        public CreateCityCommandValidator()
        {          
            RuleFor(createCityCommand => createCityCommand.Name).NotNull();
            RuleFor(createCityCommand => createCityCommand.Name_ASCII).NotNull();
            RuleFor(createCityCommand => createCityCommand.CountryId).NotEqual(0);
            RuleFor(createCityCommand => createCityCommand.Lat).NotEqual(0);
            RuleFor(createCityCommand => createCityCommand.Lon).NotEqual(0);
        }
    }
}
