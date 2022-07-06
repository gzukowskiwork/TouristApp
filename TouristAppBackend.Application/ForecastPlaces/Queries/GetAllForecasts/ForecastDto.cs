using AutoMapper;
using TouristAppBackend.Application.Common.Mapping;
using TouristAppBackend.Domain.Models;

namespace TouristAppBackend.Application.ForecastPlaces.Queries.GetAllForecasts
{
    public class ForecastDto : IMapFrom<Forecast>
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string ForecastName { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public double? Altitude { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Forecast, ForecastDto>()
                .ForMember(x => x.Longitude, map => map.MapFrom(c => c.Coordinate.Longitude))
                .ForMember(x => x.Latitude, map => map.MapFrom(c => c.Coordinate.Latitude))
                .ForMember(x => x.Altitude, map => map.MapFrom(c => c.Coordinate.Altitude));

        }
    }
}
