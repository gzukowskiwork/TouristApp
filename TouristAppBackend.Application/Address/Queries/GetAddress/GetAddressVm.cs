using AutoMapper;
using TouristAppBackend.Application.Common.Mapping;

namespace TouristAppBackend.Application.Address.Queries.GetAddress
{
    public class GetAddressDetailsVm : IMapFrom<Domain.Models.Address>
    {
        public string CityName { get; set; }
        public string StreetName { get; set; }
        public string BuildingNumber { get; set; }
        public int? UserId { get; set; }
        public int? PlaceId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Models.Address, GetAddressDetailsVm>();
        }
    }
}
