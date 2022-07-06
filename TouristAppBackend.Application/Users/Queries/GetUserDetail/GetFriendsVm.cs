using AutoMapper;
using TouristAppBackend.Application.Common.Mapping;
using TouristAppBackend.Domain.Models;

namespace TouristAppBackend.Application.Users.Queries.GetUserDetail
{
    public class GetFriendsVm : IMapFrom<User>
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<User, GetFriendsVm>();
        }
    }
}
