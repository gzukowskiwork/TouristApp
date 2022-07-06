using AutoMapper;
using TouristAppBackend.Application.Common.Mapping;
using TouristAppBackend.Domain.Models;

namespace TouristAppBackend.Application.Places.Queries.GetPlaceDetail
{
    public class GetAuthorOfCommentVm : IMapFrom<User>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<User, GetAuthorOfCommentVm>();
        }
    }
}
