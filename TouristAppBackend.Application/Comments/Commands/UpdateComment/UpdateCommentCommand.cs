using AutoMapper;
using MediatR;
using TouristAppBackend.Application.Common.Mapping;
using TouristAppBackend.Domain.Models;

namespace TouristAppBackend.Application.Comments.Commands.UpdateComment
{
    public class UpdateCommentCommand : IRequest, IMapFrom<Comment>
    {
        public int Id { get; set; }
        public string Content { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateCommentCommand, Comment>();
        }
    }
}
