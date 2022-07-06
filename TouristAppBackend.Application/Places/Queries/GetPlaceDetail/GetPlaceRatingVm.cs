using AutoMapper;
using TouristAppBackend.Application.Common.Mapping;
using TouristAppBackend.Domain.Models;

namespace TouristAppBackend.Application.Places.Queries.GetPlaceDetail
{
    public class GetPlaceRatingVm : IMapFrom<Rating>
    {
        public int Rank { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Rating, GetPlaceRatingVm>();
        }
    }
}
