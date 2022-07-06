using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using TouristAppBackend.Application.Common.Interfaces;

namespace TouristAppBackend.Service
{
    public class CurrentUserService : ICurrentUserService
    {
        public string Email { get; set; }
        public bool IsAuthenticated { get; set; }

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            var email = httpContextAccessor.HttpContext?.User.FindFirstValue("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress");

            Email = email;

            IsAuthenticated = !string.IsNullOrEmpty(email);
        }
    }
}
