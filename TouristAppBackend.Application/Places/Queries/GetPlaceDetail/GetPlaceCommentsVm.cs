using AutoMapper;
using System.Collections.Generic;
using TouristAppBackend.Application.Common.Mapping;
using TouristAppBackend.Domain.Models;

namespace TouristAppBackend.Application.Places.Queries.GetPlaceDetail
{
    public class GetPlaceCommentsVm : IMapFrom<Comment>
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int AuthorId { get; set; }
        public int? ReplyId { get; set; }
        public virtual ICollection<GetPlaceCommentsVm> Replies { get; set; }
        public GetAuthorOfCommentVm GetAuthorOfCommentVm { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Comment, GetPlaceCommentsVm>()
                .ForMember(x => x.GetAuthorOfCommentVm, map => map.MapFrom(a => a.Author));
        }
    }
}
