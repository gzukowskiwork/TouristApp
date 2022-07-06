using MediatR;

namespace TouristAppBackend.Application.Users.Queries.GetUserDetail
{
    public class GetUserDetailQuery : IRequest<UserDetailVm>
    {
        public int UserId { get; set; }
    }
}
