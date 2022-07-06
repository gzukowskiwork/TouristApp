using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TouristAppBackend.Application.Common.Interfaces;
using TouristAppBackend.Common;
using TouristAppBackend.Domain.Models;

namespace TouristAppBackend.Application.Comments.Commands.Create.CreatePictureComment
{
    public class CreatePictureCommentCommandHandler : IRequestHandler<CreatePictureCommentCommand, string>
    {
        private readonly ITouristAppContext _touristAppContext;
        private readonly IMapper _mapper;
        private readonly IDateTime _dateTime;

        public CreatePictureCommentCommandHandler(ITouristAppContext touristAppContext, IMapper mapper, IDateTime dateTime)
        {
            _touristAppContext = touristAppContext;
            _mapper = mapper;
            _dateTime = dateTime;
        }

        public async Task<string> Handle(CreatePictureCommentCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new ArgumentNullException(string.Format(Constants.ErrorMesseges.CreateCommandCannotBeNull, nameof(CreateCommentCommand)));
            }

            var comment = _mapper.Map<Comment>(request);

            try
            {
                return await CreateComment(request, comment, cancellationToken);
            }
            catch (Exception e)
            {
                throw new Exception(string.Format(Constants.ErrorMesseges.SomethingWentWrong, e.Message, e.StackTrace));
            }
        }

        private async Task<string> CreateComment(CreatePictureCommentCommand request, Comment comment, CancellationToken cancellationToken)
        {
            if (_touristAppContext.Pictures.Any(x => x.Id == request.CommentedEntityId))
            {
                //comment.CreatedBy = _touristAppContext.Users.Where(u => u.Id == request.AuthorId).Select(s => s.Email).FirstOrDefault();
                comment.StatusId = 1;
                comment.Created = _dateTime.Now;
                comment.PictureId = request.CommentedEntityId;

                _touristAppContext.Comments.Add(comment);

                await _touristAppContext.SaveChangesAsync(cancellationToken);
                return comment.Content;
            }
            else
            {
                return string.Format(Constants.ErrorMesseges.EntityDoesNotExists, nameof(Picture));
            }
        }
    }
}
