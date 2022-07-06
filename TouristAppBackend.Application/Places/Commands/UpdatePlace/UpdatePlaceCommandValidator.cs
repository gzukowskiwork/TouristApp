using FluentValidation;

namespace TouristAppBackend.Application.Places.Commands.UpdatePlace
{
    public class UpdatePlaceCommandValidator : AbstractValidator<UpdatePlaceCommand>
    {
        public UpdatePlaceCommandValidator()
        {
            RuleFor(p => p.VisitorId).NotEmpty().NotEqual(0).NotNull().WithMessage("VisitorId must be same as users id");
            RuleFor(c => c.UpdateCoordinatesVm.Id).GreaterThan(0).WithMessage("Id must be the same as specified coordinate");

        }
    }
}
