using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TouristAppBackend.Application.Common.Interfaces;
using TouristAppBackend.Domain.Models;

namespace TouristAppBackend.Application.Users.Commands.CreateUser
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly ITouristAppContext _touristAppContext;
        private readonly IMapper _mapper;
        private readonly IDateTime _dateTime;

        public CreateUserHandler(ITouristAppContext touristAppContext, IMapper mapper, IDateTime dateTime)
        {
            _touristAppContext = touristAppContext;
            _mapper = mapper;
            _dateTime = dateTime;
        }

        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            if (!request.HasAddress)
            {
                request.CreateAddressVM = null;
            }
            var user = _mapper.Map<User>(request);
            user.CreatedBy = request.Email;
            user.Created = _dateTime.Now;
            user.StatusId = 1;

            _touristAppContext.Users.Add(user);

            await _touristAppContext.SaveChangesAsync(cancellationToken);

            return user.Id;
        }
    }
}
