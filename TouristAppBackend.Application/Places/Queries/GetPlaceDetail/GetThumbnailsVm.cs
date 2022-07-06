using AutoMapper;
using TouristAppBackend.Application.Common.Mapping;
using TouristAppBackend.Domain.Models;

namespace TouristAppBackend.Application.Places.Queries.GetPlaceDetail
{
    public class GetThumbnailsVm : IMapFrom<Picture>
    {
        public string PathToImage { get; set; }
        public string PhotoName { get; set; }
        public bool IsPrivate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Picture, GetThumbnailsVm>();
        }

    }
}