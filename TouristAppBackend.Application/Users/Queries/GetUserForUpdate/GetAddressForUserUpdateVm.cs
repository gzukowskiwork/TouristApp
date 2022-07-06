using AutoMapper;
using TouristAppBackend.Application.Common.Mapping;
using TouristAppBackend.Domain.Models;

namespace TouristAppBackend.Application.Users.Queries.GetUserForUpdate
{
    public class GetAddressForUserUpdateVm : IMapFrom<Domain.Models.Address>
    {
        public int Id { get; set; }
        public string CityName { get; set; }
        public string StreetName { get; set; }
        public string BuildingNumber { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Models.Address, GetAddressForUserUpdateVm>();
        }
    }
}