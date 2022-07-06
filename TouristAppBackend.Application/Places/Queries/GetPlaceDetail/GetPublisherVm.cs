using AutoMapper;
using TouristAppBackend.Application.Common.Mapping;
using TouristAppBackend.Domain.Models;

namespace TouristAppBackend.Application.Places.Queries.GetPlaceDetail
{
    public class GetPublisherVm: IMapFrom<User>
    {
        public string PublisherFirstName { get; set; }
        public string PublisherLastName { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<User, GetPublisherVm>()
                .ForMember(x => x.PublisherFirstName, map => map.MapFrom(u => u.FirstName))
                .ForMember(x => x.PublisherLastName, map => map.MapFrom(u => u.LastName));
        }

    }
}