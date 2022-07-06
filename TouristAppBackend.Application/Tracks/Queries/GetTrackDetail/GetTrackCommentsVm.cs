using AutoMapper;
using System.Collections.Generic;
using TouristAppBackend.Application.Common.Mapping;
using TouristAppBackend.Domain.Models;

namespace TouristAppBackend.Application.Tracks.Queries.GetTrackDetail
{
    public class GetTrackCommentsVm : IMapFrom<Comment>
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int AuthorId { get; set; }
        public int? ReplyId { get; set; }
        public virtual ICollection<GetTrackCommentsVm> Replies { get; set; }
        public GetAuthorOfCommentTrackVm GetAuthorOfCommentVm { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Comment, GetTrackCommentsVm>()
                .ForMember(x => x.GetAuthorOfCommentVm, map => map.MapFrom(a => a.Author));
        }
    }
}