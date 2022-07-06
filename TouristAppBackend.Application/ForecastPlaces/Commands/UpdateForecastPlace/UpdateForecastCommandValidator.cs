using FluentValidation;

namespace TouristAppBackend.Application.ForecastPlaces.Commands.UpdateForecastPlace
{
    internal class UpdateForecastCommandValidator : AbstractValidator<UpdateForecastCommand>
    {
        public UpdateForecastCommandValidator()
        {
            RuleFor(f => f.ForecastName).NotEmpty();
            RuleFor(x => x.CreateCoordinateVm.Latitude).NotNull();
            RuleFor(x => x.CreateCoordinateVm.Longitude).NotNull();
        }
    }
}
