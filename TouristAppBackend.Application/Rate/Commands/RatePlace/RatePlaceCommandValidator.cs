using FluentValidation;

namespace TouristAppBackend.Application.Rate.Commands.RatePlace
{
    public class RatePlaceCommandValidator : AbstractValidator<RatePlaceCommand>
    {
        public RatePlaceCommandValidator()
        {
            RuleFor(x => x).NotNull();
            RuleFor(x => x.Rank).GreaterThanOrEqualTo(0).LessThanOrEqualTo(5);
        }
    }
}
