using AutoMapper;
using MediatR;
using TouristAppBackend.Application.Common.Mapping;
using TouristAppBackend.Domain.Models;

namespace TouristAppBackend.Application.Users.Commands.UpdateUser
{
    public class UpdateUserCommand : IRequest, IMapFrom<User>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool HasAddress { get; set; }
        public UpdateAddressVm GetAddressVm { get; set; }


        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateUserCommand, User>()
                .ForMember(x => x.MyAddress, map => map.MapFrom(u => u.GetAddressVm));
        }
    }
}