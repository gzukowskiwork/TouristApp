using AutoMapper;
using TouristAppBackend.Application.Common.Mapping;
using TouristAppBackend.Domain.Models;

namespace TouristAppBackend.Application.Places.Commands.CreatePlace
{
    public class CreateCoordinatesVm : IMapFrom<Coordinate>
    {
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public double? Altitude { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateCoordinatesVm, Coordinate>();
        }
    }
}
