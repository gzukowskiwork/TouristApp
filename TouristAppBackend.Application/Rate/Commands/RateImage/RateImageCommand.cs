using AutoMapper;
using MediatR;
using TouristAppBackend.Application.Common.Mapping;
using TouristAppBackend.Domain.Models;

namespace TouristAppBackend.Application.Rate.Commands.RateImage
{
    public class RateImageCommand : IRequest, IMapFrom<Rating>
    {
        public int PictureId { get; set; }
        public int Rank { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<RateImageCommand, Rating>();
        }
    }
}
