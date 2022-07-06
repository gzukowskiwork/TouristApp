using AutoMapper;
using TouristAppBackend.Application.Common.Mapping;
using TouristAppBackend.Domain.Models;

namespace TouristAppBackend.Application.Tracks.Queries.GetAllTracks
{
    public class TrackDto : IMapFrom<Track>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsPrivate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Track, TrackDto>();
        }
    }
}
