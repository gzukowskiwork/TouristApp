using AutoMapper;
using TouristAppBackend.Application.Common.Mapping;

namespace TouristAppBackend.Application.Address.Queries.GetAllAddresses
{
    public class GetAllAddressesDto : IMapFrom<Domain.Models.Address>
    {
        public int Id { get; set; }
        public string CityName { get; set; }
        public string StreetName { get; set; }
        public string BuildingNumber { get; set; }
        public int? UserId { get; set; }
        public int? PlaceId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Models.Address, GetAllAddressesDto>();
        }
    }
}
