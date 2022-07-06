using AutoMapper;
using TouristAppBackend.Application.Common.Mapping;

namespace TouristAppBackend.Application.Users.Queries.GetUserDetail
{
    public class GetAddressVm: IMapFrom<Domain.Models.Address>
    {
        public string CityName { get; set; }
        public string StreetName { get; set; }
        public string BuildingNumber { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Models.Address, GetAddressVm>();
        }
    }
}