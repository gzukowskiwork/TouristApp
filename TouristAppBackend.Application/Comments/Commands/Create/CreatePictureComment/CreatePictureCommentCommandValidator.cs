using FluentValidation;

namespace TouristAppBackend.Application.Comments.Commands.Create.CreatePictureComment
{
    internal class CreatePictureCommentCommandValidator : AbstractValidator<CreatePictureCommentCommand>
    {
        public CreatePictureCommentCommandValidator()
        {
            RuleFor(c => c.CommentedEntityId).NotNull().GreaterThan(0);
            RuleFor(c => c.Content).NotEmpty().MinimumLength(5).MaximumLength(2000);
            RuleFor(c => c.AuthorId).NotNull().GreaterThan(0);
        }
    }
}
