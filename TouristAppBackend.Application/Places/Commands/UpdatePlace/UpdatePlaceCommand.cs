using AutoMapper;
using MediatR;
using TouristAppBackend.Application.Common.Mapping;
using TouristAppBackend.Domain.Models;

namespace TouristAppBackend.Application.Places.Commands.UpdatePlace
{
    public class UpdatePlaceCommand : IRequest, IMapFrom<Place>
    {
        public int Id { get; set; }
        public string PlaceName { get; set; }
        public string Description { get; set; }
        public int VisitorId { get; set; }
        public bool IsPrivate { get; set; }
        public UpdateCoordinatesVm UpdateCoordinatesVm { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdatePlaceCommand, Place>()
                .ForMember(x => x.Coordinate, map => map.MapFrom(c => c.UpdateCoordinatesVm));
        }
    }
}
