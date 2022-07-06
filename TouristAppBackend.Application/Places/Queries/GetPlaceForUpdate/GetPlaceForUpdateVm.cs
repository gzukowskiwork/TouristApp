using AutoMapper;
using System;
using TouristAppBackend.Application.Common.Mapping;
using TouristAppBackend.Domain.Models;

namespace TouristAppBackend.Application.Places.Queries.GetPlaceForUpdate
{
    public class GetPlaceForUpdateVm : IMapFrom<Place>
    {
        public int Id { get; set; }
        public string PlaceName { get; set; }
        public string Description { get; set; }
        public int VisitorId { get; set; }
        public bool IsPrivate { get; set; }
        public DateTime? VisitedAt { get; set; }
        public string CreatedBy { get; set; }
        public GetCoordinatesForPlaceUpdateVm GetCoordinatesForPlaceUpdateVm { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Place, GetPlaceForUpdateVm>()
                .ForMember(x => x.GetCoordinatesForPlaceUpdateVm, map => map.MapFrom(c => c.Coordinate));
        }
    }
}
