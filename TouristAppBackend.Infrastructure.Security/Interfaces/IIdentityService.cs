using System.Threading.Tasks;
using TouristAppBackend.Application.Security.Result;

namespace TouristAppBackend.Infrastructure.Security.Interfaces
{
    public interface IIdentityService
    {
        Task<AuthenticationResult> RegisterAsync(string email, string password);
        Task<AuthenticationResult> LoginAsync(string email, string password);
    }
}
