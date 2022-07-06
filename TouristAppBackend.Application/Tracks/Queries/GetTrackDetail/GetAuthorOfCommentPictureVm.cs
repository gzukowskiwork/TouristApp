using AutoMapper;
using TouristAppBackend.Application.Common.Mapping;
using TouristAppBackend.Domain.Models;

namespace TouristAppBackend.Application.Tracks.Queries.GetTrackDetail
{
    public class GetAuthorOfCommentPictureVm : IMapFrom<User>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<User, GetAuthorOfCommentPictureVm>();
        }
    }
}