using FluentValidation;

namespace TouristAppBackend.Application.ForecastPlaces.Commands.CreateForecastPlace
{
    internal class CreateForecastCommandValidator: AbstractValidator<CreateForecastCommand>
    {
        public CreateForecastCommandValidator()
        {
            RuleFor(f => f.ForecastName).NotEmpty();
            RuleFor(f => f.UserId).NotNull().GreaterThan(0);
            RuleFor(x => x.CreateCoordinateVm.Latitude).NotNull();
            RuleFor(x => x.CreateCoordinateVm.Longitude).NotNull();
        }
    }
}
