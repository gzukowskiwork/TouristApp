using AutoMapper;
using System.Collections.Generic;
using TouristAppBackend.Application.Common.Mapping;
using TouristAppBackend.Domain.Models;

namespace TouristAppBackend.Application.Users.Queries.GetUserDetail
{
    public class UserDetailVm : IMapFrom<User>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public GetAddressVm GetAddressVm { get; set; }
        public ICollection<GetPlacesVm> GetPlacesVm { get; set; }
        public ICollection<GetFriendsVm> GetFriendsVm { get; set; }
        public ICollection<GetForecastsVm> GetForecastsVm { get; set; }
        public ICollection<GetTracksVm> GetTracksVm { get; set; }


        public void Mapping(Profile profile)
        {
            profile.CreateMap<User, UserDetailVm>()
                .ForMember(x => x.GetAddressVm, map => map.MapFrom(u => u.MyAddress))
                .ForMember(x => x.GetPlacesVm, map => map.MapFrom(u => u.MyPlaces))
                .ForMember(x => x.GetFriendsVm, map => map.MapFrom(u => u.Friends))
                .ForMember(x => x.GetForecastsVm, map => map.MapFrom(u => u.MyForecastsPlaces))
                .ForMember(x => x.GetTracksVm, map => map.MapFrom(u => u.MyTracks));
        }
    }
}
