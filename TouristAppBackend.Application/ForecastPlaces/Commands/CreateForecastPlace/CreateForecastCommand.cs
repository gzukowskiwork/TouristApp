using AutoMapper;
using MediatR;
using TouristAppBackend.Application.Common.Mapping;
using TouristAppBackend.Application.Places.Commands.CreatePlace;
using TouristAppBackend.Domain.Models;

namespace TouristAppBackend.Application.ForecastPlaces.Commands.CreateForecastPlace
{
    public class CreateForecastCommand : IRequest<int>, IMapFrom<Forecast>
    {
        public int UserId { get; set; }
        public string ForecastName { get; set; }
        public CreateCoordinatesVm CreateCoordinateVm { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateForecastCommand, Forecast>()
                .ForMember(x => x.Coordinate, map => map.MapFrom(c => c.CreateCoordinateVm));
        }
    }
}
