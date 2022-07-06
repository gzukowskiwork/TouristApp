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

namespace TouristAppBackend.Application.Comments.Commands.Create.CreateReplyComment
{
    class CeateReplyCommentHandler : IRequestHandler<CreateReplyCommentCommand, string>
    {
        private readonly ITouristAppContext _touristAppContext;
        private readonly IMapper _mapper;
        private readonly IDateTime _dateTime;

        public CeateReplyCommentHandler(ITouristAppContext touristAppContext, IMapper mapper, IDateTime dateTime)
        {
            _mapper = mapper;
            _touristAppContext = touristAppContext;
            _dateTime = dateTime;
        }

        public async Task<string> Handle(CreateReplyCommentCommand request, CancellationToken cancellationToken)
        {
            if(request == null)
            {
                throw new ArgumentNullException(string.Format(Constants.ErrorMesseges.CreateCommandCannotBeNull, nameof(CreateReplyCommentCommand)));
            }

            var comment = _mapper.Map<Comment>(request);

            try
            {
                return await CreateReply(request, comment, cancellationToken);
            }
            catch (Exception e)
            {
                throw new Exception(string.Format(Constants.ErrorMesseges.SomethingWentWrong, e.Message, e.StackTrace));
            }
        }

        private async Task<string> CreateReply(CreateReplyCommentCommand request, Comment comment, CancellationToken cancellationToken)
        {
            if (_touristAppContext.Comments.Any(x => x.Id == request.CommentedEntityId))
            {
                var commentToReply = await _touristAppContext.Comments.Where(x => x.Id == request.CommentedEntityId).FirstOrDefaultAsync();
                comment.StatusId = 1;
                comment.Created = _dateTime.Now;
                //comment.CreatedBy = _touristAppContext.Users.Where(u => u.Id == request.AuthorId).Select(a => a.FirstName).FirstOrDefault();


                commentToReply.Replies.Add(comment);

                await _touristAppContext.SaveChangesAsync(cancellationToken);

                return comment.Content;
            }
            else
            {
                return string.Format(Constants.ErrorMesseges.EntityDoesNotExists, nameof(Comment));
            }
        }
    }
}
