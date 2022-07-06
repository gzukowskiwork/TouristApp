using AutoMapper;
using System.Collections.Generic;
using TouristAppBackend.Application.Common.Mapping;
using TouristAppBackend.Domain.Models;

namespace TouristAppBackend.Application.Tracks.Queries.GetTrackDetail
{
    public class GetPictureCommentsVm: IMapFrom<Comment>
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int AuthorId { get; set; }
        public int? ReplyId { get; set; }
        public virtual ICollection<GetPictureCommentsVm> Replies { get; set; }
        public GetAuthorOfCommentPictureVm GetAuthorOfCommentVm { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Comment, GetPictureCommentsVm>()
                .ForMember(x => x.GetAuthorOfCommentVm, map => map.MapFrom(a => a.Author));
        }
    }
}