using AutoMapper;
using MediatR;
using TouristAppBackend.Application.Common.Mapping;
using TouristAppBackend.Domain.Models;

namespace TouristAppBackend.Application.Users.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<int>, IMapFrom<User>
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool HasAddress { get; set; }
        public CreateAddressVM CreateAddressVM { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateUserCommand, User>()
                .ForMember(x => x.MyAddress, map => map.MapFrom(c => c.CreateAddressVM));
        }
    }
}
