using AutoMapper;
using TouristAppBackend.Application.Common.Mapping;
using TouristAppBackend.Domain.Models;

namespace TouristAppBackend.Application.Users.Queries.GetUserForUpdate
{
    public class GetUserDetailForUpdateVm : IMapFrom<User>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool HasAddress { get; set; }
        public GetAddressForUserUpdateVm GetAddressVm { get; set; }


        public void Mapping(Profile profile)
        {
            profile.CreateMap<User, GetUserDetailForUpdateVm>()
                .ForMember(x => x.GetAddressVm, map => map.MapFrom(u => u.MyAddress));
        }
    }
}
