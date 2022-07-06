using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TouristAppBackend.Application.Common.Interfaces;
using TouristAppBackend.Common;

namespace TouristAppBackend.Application.Comments.Commands.DeleteComment
{
    public class DeleteCommentHandler : IRequestHandler<DeleteCommentCommand>
    {
        private readonly ITouristAppContext _touristAppContext;
        private readonly IDateTime _dateTime;

        public DeleteCommentHandler(ITouristAppContext touristAppContext, IDateTime dateTime)
        {
            _touristAppContext = touristAppContext;
            _dateTime = dateTime;
        }

        public async Task<Unit> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new ArgumentNullException(string.Format(Constants.ErrorMesseges.DeleteCommandCannotBeNull, nameof(DeleteCommentCommand)));
            }

            var comment = await _touristAppContext.Comments.Where(c => c.Id == request.CommentId).FirstOrDefaultAsync(cancellationToken);

            if (comment == null)
            {
                throw new ArgumentNullException(string.Format(Constants.ErrorMesseges.CommentDoesNotExists, request.CommentId, nameof(DeleteCommentCommand)));
            }

            try
            {
               // comment.InactivatedBy = _touristAppContext.Users.Where(x => x.Id == comment.AuthorId).FirstOrDefault().Email;

                _touristAppContext.Comments.Remove(comment);

                await _touristAppContext.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
