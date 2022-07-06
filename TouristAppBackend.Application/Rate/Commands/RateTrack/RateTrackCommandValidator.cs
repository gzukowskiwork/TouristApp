using FluentValidation;

namespace TouristAppBackend.Application.Rate.Commands.RateTrack
{
    public class RateTrackCommandValidator : AbstractValidator<RateTrackCommand>
    {
        public RateTrackCommandValidator()
        {
            RuleFor(x => x).NotNull();
            RuleFor(x => x.Rank).GreaterThanOrEqualTo(0).LessThanOrEqualTo(5);
        }
    }
}
