using AutoMapper;
using TouristAppBackend.Application.Common.Mapping;
using TouristAppBackend.Domain.Models;

namespace TouristAppBackend.Application.Users.Queries.GetUserDetail
{
    public class GetPlacesVm : IMapFrom<Place>
    {
        public string PlaceName { get; set; }
        public bool IsPrivate { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public double? Altitude { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Place, GetPlacesVm>()
                .ForMember(x => x.Longitude, map => map.MapFrom(p => p.Coordinate.Longitude))
                .ForMember(x => x.Latitude, map => map.MapFrom(p => p.Coordinate.Latitude))
                .ForMember(x => x.Altitude, map => map.MapFrom(p => p.Coordinate.Altitude));

        }
    }
}