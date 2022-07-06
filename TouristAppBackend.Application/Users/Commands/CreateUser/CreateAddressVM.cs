using AutoMapper;
using TouristAppBackend.Application.Common.Mapping;

namespace TouristAppBackend.Application.Users.Commands.CreateUser
{
    public class CreateAddressVM : IMapFrom<Domain.Models.Address>
    {
        public string CityName { get; set; }
        public string StreetName { get; set; }
        public string BuildingNumber { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateAddressVM, Domain.Models.Address>();
        }
    }
}
