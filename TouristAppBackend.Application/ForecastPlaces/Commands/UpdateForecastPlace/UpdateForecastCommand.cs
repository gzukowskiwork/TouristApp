using AutoMapper;
using MediatR;
using TouristAppBackend.Application.Common.Mapping;
using TouristAppBackend.Application.Places.Commands.CreatePlace;
using TouristAppBackend.Domain.Models;

namespace TouristAppBackend.Application.ForecastPlaces.Commands.UpdateForecastPlace
{
    public class UpdateForecastCommand : IRequest, IMapFrom<Forecast>
    {
        public int Id { get; set; }
        public string ForecastName { get; set; }
        public CreateCoordinatesVm CreateCoordinateVm { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateForecastCommand, Forecast>()
                .ForMember(x => x.Coordinate, map => map.MapFrom(c => c.CreateCoordinateVm));
        }
    }
}
