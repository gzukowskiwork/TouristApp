using MediatR;

namespace TouristAppBackend.Application.Users.Queries.GetUserForUpdate
{
    public class GetUserDetailForUpdataQuery : IRequest<GetUserDetailForUpdateVm>
    {
        public int UserId { get; set; }
    }
}
