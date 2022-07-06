using AutoMapper;
using MediatR;
using TouristAppBackend.Application.Common.Mapping;
using TouristAppBackend.Domain.Models;

namespace TouristAppBackend.Application.Comments.Commands.Create
{
    public class CreateCommentCommand : IRequest<string>, IMapFrom<Comment>
    {
        public int CommentedEntityId { get; set; }
        public string Content { get; set; }
        public int AuthorId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateCommentCommand, Comment>();
        }

    }
}
