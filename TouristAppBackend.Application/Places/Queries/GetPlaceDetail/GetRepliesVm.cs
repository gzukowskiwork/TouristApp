using AutoMapper;
using System.Collections.Generic;
using TouristAppBackend.Application.Common.Mapping;
using TouristAppBackend.Domain.Models;

namespace TouristAppBackend.Application.Places.Queries.GetPlaceDetail
{
    public class GetRepliesVm: IMapFrom<Comment>
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int AuthorId { get; set; }
        public ICollection<GetRepliesVm> Replies { get; set; }
        public GetAuthorOfCommentVm GetAuthorOfCommentVm { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Comment, GetRepliesVm>()
                .ForMember(x => x.GetAuthorOfCommentVm, map => map.MapFrom(a => a.Author));
        }
    }
}