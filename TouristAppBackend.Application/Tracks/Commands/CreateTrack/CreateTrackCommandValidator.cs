using FluentValidation;

namespace TouristAppBackend.Application.Tracks.Commands.CreateTrack
{
    public class CreateTrackCommandValidator : AbstractValidator<CreateTrackCommand>
    {
        public CreateTrackCommandValidator()
        {
            RuleFor(t=>t.PathToFile).NotNull();
            RuleFor(t=>t.Name).NotNull().MinimumLength(5).MaximumLength(40);
        }
    }
}
