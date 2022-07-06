using AutoMapper;
using MediatR;
using System;
using TouristAppBackend.Application.Common.Mapping;
using TouristAppBackend.Domain.Models;

namespace TouristAppBackend.Application.Places.Commands.CreatePlace
{
    public class CreatePlaceCommand : IRequest<int>, IMapFrom<Place>
    {
        public int VisitorId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsPrivate { get; set; }
        public DateTime? VisitedAt { get; set; }
        public CreateCoordinatesVm CreateCoordinatesVm { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreatePlaceCommand, Place>()
                .ForMember(x=>x.Coordinate, map=>map.MapFrom(c=>c.CreateCoordinatesVm));
        }
    }
}
