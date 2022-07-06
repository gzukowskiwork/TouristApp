using AutoMapper;
using MediatR;
using TouristAppBackend.Application.Common.Mapping;
using TouristAppBackend.Domain.Models;

namespace TouristAppBackend.Application.Rate.Commands.UpdateRate
{
    public class UpdateRateCommand : IRequest, IMapFrom<Rating>
    {
        public int Id { get; set; }
        public int NewRank { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateRateCommand, Rating>()
                .ForMember(x=>x.Rank, map => map.MapFrom(r=>r.NewRank));
        }
    }
}
