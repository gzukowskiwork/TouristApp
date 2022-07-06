using AutoMapper;
using TouristAppBackend.Application.Common.Mapping;
using TouristAppBackend.Domain.Models;

namespace TouristAppBackend.Application.Places.Queries.GetPlaceForUpdate
{
    public class GetCoordinatesForPlaceUpdateVm : IMapFrom<Coordinate>
    {
        public int Id { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public double? Altitude { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Coordinate, GetCoordinatesForPlaceUpdateVm>();
        }
    }
}
