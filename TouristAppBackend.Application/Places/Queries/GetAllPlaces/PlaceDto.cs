using AutoMapper;
using System;
using TouristAppBackend.Application.Common.Mapping;
using TouristAppBackend.Domain.Models;

namespace TouristAppBackend.Application.Places.Queries.GetAllPlaces
{
    public class PlaceDto : IMapFrom<Place>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsPrivate { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public double? Altitude { get; set; }
        public DateTime VisitedAt { get; set; }


        public void Mapping(Profile profile)
        {
            profile.CreateMap<Place, PlaceDto>()
                .ForMember(x => x.Id, map => map.MapFrom(ss => ss.Id))
                .ForMember(x => x.Name, map => map.MapFrom(ss => ss.Name))
                .ForMember(x => x.Description, map => map.MapFrom(ss => ss.Description))
                .ForMember(x => x.IsPrivate, map => map.MapFrom(ss => ss.IsPrivate))
                .ForMember(x => x.Longitude, map => map.MapFrom(ss => ss.Coordinate.Longitude))
                .ForMember(x => x.Latitude, map => map.MapFrom(ss => ss.Coordinate.Latitude))
                .ForMember(x => x.Altitude, map => map.MapFrom(ss => ss.Coordinate.Altitude));
        }
    }
}
