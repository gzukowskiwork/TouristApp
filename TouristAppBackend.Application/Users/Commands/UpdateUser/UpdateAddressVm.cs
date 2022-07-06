using AutoMapper;
using TouristAppBackend.Application.Common.Mapping;

namespace TouristAppBackend.Application.Users.Commands.UpdateUser
{
    public class UpdateAddressVm : IMapFrom<Domain.Models.Address>
    {
        public int Id { get; set; }
        public string CityName { get; set; }
        public string StreetName { get; set; }
        public string BuildingNumber { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateAddressVm, Domain.Models.Address>();
        }
    }
}
