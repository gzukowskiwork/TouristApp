using FluentValidation;

namespace TouristAppBackend.Application.Comments.Commands.UpdateComment
{
    public class UpdateCommentCommandValidator : AbstractValidator<UpdateCommentCommand>
    {
        public UpdateCommentCommandValidator()
        {
            RuleFor(c => c.Id).NotNull().GreaterThan(0);
            RuleFor(c => c.Content).NotEmpty().MinimumLength(5).MaximumLength(2000);
        }
    }
}
