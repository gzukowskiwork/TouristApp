using FluentValidation;

namespace TouristAppBackend.Application.Places.Commands.CreatePlace
{
    public class CreatePlaceCommandValidator : AbstractValidator<CreatePlaceCommand>
    {
        public CreatePlaceCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty();

            RuleFor(u => u.VisitorId)
                .GreaterThan(0)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.CreateCoordinatesVm)
                .NotNull()
                .NotEmpty();
        }
    }
}
