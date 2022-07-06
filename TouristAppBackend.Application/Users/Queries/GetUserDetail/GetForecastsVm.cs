using AutoMapper;
using TouristAppBackend.Application.Common.Mapping;
using TouristAppBackend.Domain.Models;

namespace TouristAppBackend.Application.Users.Queries.GetUserDetail
{
    public class GetForecastsVm : IMapFrom<Forecast>
    {
        public string ForecastName { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Forecast, GetForecastsVm>()
                .ForMember(x => x.Longitude, map => map.MapFrom(p => p.Coordinate.Longitude))
                .ForMember(x => x.Latitude, map => map.MapFrom(p => p.Coordinate.Latitude));
        }
    }
}
