using AutoMapper;
using System.Collections.Generic;
using TouristAppBackend.Application.Common.Mapping;
using TouristAppBackend.Domain.Models;

namespace TouristAppBackend.Application.Places.Queries.GetPlaceDetail
{
    public class PlaceDetailVm : IMapFrom<Place>
    {
        public int Id { get; set; }
        public string PlaceName { get; set; }
        public string Description { get; set; }
        public double AvarageRate { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public double? Altitude { get; set; }
        public GetPublisherVm PublisherVm { get; set; }
        public GetPlaceAddressVm AddressVm { get; set; }
        public ICollection<GetPlaceRatingVm> PlaceRatingVms { get; set; }
        public ICollection<GetPlaceCommentsVm> CommentsVms { get; set; }
        public ICollection<GetThumbnailsVm> ThumbnailsVms { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Place, PlaceDetailVm>()
                .ForMember(x => x.Id, map => map.MapFrom(p => p.Id))
                .ForMember(x => x.PlaceName, map => map.MapFrom(p => p.Name))
                .ForMember(x => x.Description, map => map.MapFrom(p => p.Description))
                .ForMember(x => x.Longitude, map => map.MapFrom(p => p.Coordinate.Longitude))
                .ForMember(x => x.Latitude, map => map.MapFrom(p => p.Coordinate.Latitude))
                .ForMember(x => x.Altitude, map => map.MapFrom(p => p.Coordinate.Altitude))
                .ForMember(x => x.CommentsVms, map => map.MapFrom(p => p.Comments))
                .ForMember(x => x.PlaceRatingVms, map => map.MapFrom(p => p.Ratings))
                .ForMember(x => x.PublisherVm, map => map.MapFrom(p => p.Visitor))
                .ForMember(x => x.ThumbnailsVms, map => map.MapFrom(p => p.PicturesOfPlace))
                .ForMember(x=>x.AddressVm, map =>map.MapFrom(p=>p.PlaceAddress));
        }
    }
}
