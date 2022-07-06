using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TouristAppBackend.Application.Comments.Commands.DeleteComment
{
    public class DeleteCommentCommandValidator:  AbstractValidator<DeleteCommentCommand>
    {
        public DeleteCommentCommandValidator()
        {
            RuleFor(c => c.CommentId).NotNull().GreaterThan(0);
        }
    }
}
