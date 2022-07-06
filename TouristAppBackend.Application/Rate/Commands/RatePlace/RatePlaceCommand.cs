using AutoMapper;
using MediatR;
using TouristAppBackend.Application.Common.Mapping;
using TouristAppBackend.Domain.Models;

namespace TouristAppBackend.Application.Rate.Commands.RatePlace
{
    public class RatePlaceCommand : IRequest, IMapFrom<Rating>
    {
        public int PlaceId { get; set; }
        public int Rank { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<RatePlaceCommand, Rating>();
        }
    }
}
