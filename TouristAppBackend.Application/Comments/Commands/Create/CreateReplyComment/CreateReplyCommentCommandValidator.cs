using FluentValidation;

namespace TouristAppBackend.Application.Comments.Commands.Create.CreateReplyComment
{
    public class CreateReplyCommentCommandValidator : AbstractValidator<CreateReplyCommentCommand>
    {
        public CreateReplyCommentCommandValidator()
        {
            RuleFor(r => r.CommentedEntityId).NotNull().GreaterThan(0);
            RuleFor(r => r.Content).NotEmpty().MinimumLength(5).MaximumLength(2000);
            RuleFor(r => r.AuthorId).NotNull().GreaterThan(0);
        }
    }
}
