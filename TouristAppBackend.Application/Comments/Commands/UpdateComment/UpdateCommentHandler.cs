using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TouristAppBackend.Application.Common.Interfaces;
using TouristAppBackend.Common;
using TouristAppBackend.Domain.Models;

namespace TouristAppBackend.Application.Comments.Commands.UpdateComment
{
    public class UpdateCommentHandler : IRequestHandler<UpdateCommentCommand>
    {
        private readonly ITouristAppContext _touristAppContext;
        private readonly IMapper _mapper;
        private readonly IDateTime _dateTime;

        public UpdateCommentHandler(ITouristAppContext touristAppContext, IMapper mapper, IDateTime dateTime)
        {
            _touristAppContext = touristAppContext;
            _mapper = mapper;
            _dateTime = dateTime;
        }

        public async Task<Unit> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new ArgumentNullException(string.Format(Constants.ErrorMesseges.UpdateCommandCannotBeNull, nameof(UpdateCommentCommand)));
            }

            var comment = _mapper.Map<Comment>(request);

            var oldComment = await _touristAppContext.Comments.Where(c => c.Id == comment.Id).AsNoTracking().FirstOrDefaultAsync(cancellationToken);

            if (oldComment == null)
            {
                throw new ArgumentNullException(string.Format(Constants.ErrorMesseges.EntityDoesNotExists, nameof(Comment)));
            }

            try
            {
                comment.Created = oldComment.Created;
                comment.CreatedBy = oldComment.CreatedBy;
                comment.AuthorId = oldComment.AuthorId;
                //comment.ModifiedBy = _touristAppContext.Users.Where(u => u.Id == comment.AuthorId).FirstOrDefault().Email;
                
                _touristAppContext.Comments.Update(comment);

                await _touristAppContext.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
            catch (Exception e)
            {
                throw new Exception(string.Format(Constants.ErrorMesseges.SomethingWentWrong, e.Message, e.StackTrace));
            }
        }
    }
}
