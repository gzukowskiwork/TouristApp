using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TouristAppBackend.Application.Common.Interfaces;
using TouristAppBackend.Domain.Models;

namespace TouristAppBackend.Application.Identity.Command
{
    public class RegisterHandler : IRequestHandler<RegisterCommand, string>
    {
        private readonly IUserContext _userContext;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;

        public RegisterHandler(IUserContext userContext, IMapper mapper, UserManager<AppUser> userManager)
        {
            _userContext = userContext;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<string> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<AppUser>(request);
            user.UserName = request.Email;
            var result = await _userManager.CreateAsync(user, request.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {

                }

            }
            await _userManager.AddToRoleAsync(user, "RegisteredUser");
            return "Ok";
        }
    }
}
