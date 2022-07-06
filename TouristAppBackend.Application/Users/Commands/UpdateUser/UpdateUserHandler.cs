using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TouristAppBackend.Application.Common.Interfaces;
using TouristAppBackend.Domain.Models;

namespace TouristAppBackend.Application.Users.Commands.UpdateUser
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand>
    {
        private readonly ITouristAppContext _touristAppContext;
        private readonly IMapper _mapper;

        public UpdateUserHandler(ITouristAppContext touristAppContext, IMapper mapper)
        {
            _touristAppContext = touristAppContext;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            if (!request.HasAddress)
            {
                request.GetAddressVm = null;
            }

            var oldUser = await _touristAppContext.Users.Where(x=>x.Id == request.Id).AsNoTracking().FirstOrDefaultAsync();

            var user = _mapper.Map<User>(request);
            user.ModifiedBy = request.Email;
            user.CreatedBy = oldUser.Email;
            user.Created = oldUser.Created;

            _touristAppContext.Users.Update(user);

            await _touristAppContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
