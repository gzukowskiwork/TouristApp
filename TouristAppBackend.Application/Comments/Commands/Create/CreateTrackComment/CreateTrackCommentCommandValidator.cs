using FluentValidation;

namespace TouristAppBackend.Application.Comments.Commands.Create.CreateTrackComment
{
    public class CreateTrackCommentCommandValidator : AbstractValidator<CreateTrackCommentCommand>
    {
        public CreateTrackCommentCommandValidator()
        {
            RuleFor(c => c.CommentedEntityId).NotNull().GreaterThan(0);
            RuleFor(c => c.Content).NotEmpty().MinimumLength(5).MaximumLength(2000);
            RuleFor(c => c.AuthorId).NotNull().GreaterThan(0);
        }
    }
}
