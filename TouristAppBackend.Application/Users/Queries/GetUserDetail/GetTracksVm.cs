using AutoMapper;
using TouristAppBackend.Application.Common.Mapping;
using TouristAppBackend.Domain.Models;

namespace TouristAppBackend.Application.Users.Queries.GetUserDetail
{
    public class GetTracksVm : IMapFrom<Track>
    {
        public string TrackName { get; set; }
        public bool IsPrivate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Track, GetTracksVm>();
        }

    }
}