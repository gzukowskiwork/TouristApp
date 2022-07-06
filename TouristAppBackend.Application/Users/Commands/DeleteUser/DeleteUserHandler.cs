using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TouristAppBackend.Application.Common.Interfaces;

namespace TouristAppBackend.Application.Users.Commands.DeleteUser
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserCommand>
    {
        private readonly ITouristAppContext _touristAppContext;

        public DeleteUserHandler(ITouristAppContext touristAppContext)
        {
            _touristAppContext = touristAppContext;
        }

        public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _touristAppContext.Users.Where(u => u.Id == request.UserId).FirstOrDefaultAsync(cancellationToken);

            _touristAppContext.Users.Remove(user);

            await _touristAppContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
