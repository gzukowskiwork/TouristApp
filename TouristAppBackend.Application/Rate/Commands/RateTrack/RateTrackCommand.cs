using AutoMapper;
using MediatR;
using TouristAppBackend.Application.Common.Mapping;
using TouristAppBackend.Domain.Models;

namespace TouristAppBackend.Application.Rate.Commands.RateTrack
{
    public class RateTrackCommand : IRequest, IMapFrom<Rating>
    {
        public int TrackId { get; set; }
        public int Rank { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<RateTrackCommand, Rating>();
        }
    }
}
