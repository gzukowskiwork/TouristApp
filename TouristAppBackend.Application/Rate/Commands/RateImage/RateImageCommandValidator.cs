using FluentValidation;

namespace TouristAppBackend.Application.Rate.Commands.RateImage
{
    public class RateImageCommandValidator : AbstractValidator<RateImageCommand>
    {
        public RateImageCommandValidator()
        {
            RuleFor(x => x).NotNull();
            RuleFor(x => x.Rank).GreaterThanOrEqualTo(0).LessThanOrEqualTo(5);
        }
    }
}
