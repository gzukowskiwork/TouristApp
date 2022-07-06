using FluentValidation;

namespace TouristAppBackend.Application.Rate.Commands.UpdateRate
{
    public class UpdateRateCommandValidator : AbstractValidator<UpdateRateCommand>
    {
        public UpdateRateCommandValidator()
        {
            RuleFor(x => x).NotNull();
            RuleFor(x => x.NewRank).GreaterThanOrEqualTo(0).LessThanOrEqualTo(5);
        }
    }
}
