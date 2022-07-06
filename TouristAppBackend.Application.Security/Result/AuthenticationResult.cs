using System.Collections.Generic;

namespace TouristAppBackend.Application.Security.Result
{
    public class AuthenticationResult
    {
        public string Token { get; set; }
        public bool Success { get; set; }
        public IEnumerable<string> Errorssage { get; set; }
    }
}
