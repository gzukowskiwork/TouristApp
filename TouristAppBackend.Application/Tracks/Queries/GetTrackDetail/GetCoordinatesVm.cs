using AutoMapper;
using TouristAppBackend.Application.Common.Mapping;
using TouristAppBackend.Domain.Models;

namespace TouristAppBackend.Application.Tracks.Queries.GetTrackDetail
{
    public class GetCoordinatesVm : IMapFrom<Coordinate>
    {
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public double? Altitude { get; set; }
        public int TrackPointId { get; set; }
        public int TrackId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Coordinate, GetCoordinatesVm>();
        }
    }
}
