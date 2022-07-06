using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TouristAppBackend.Application.Common.Interfaces;

namespace TouristAppBackend.Application.Users.Queries.GetAllUsers
{
    public class UsersQueryHandler : IRequestHandler<UsersQuery, UsersVm>
    {
        private readonly ITouristAppContext _touristAppContext;
        private readonly IMapper _mapper;

        public UsersQueryHandler(ITouristAppContext touristAppContext, IMapper mapper)
        {
            _touristAppContext = touristAppContext;
            _mapper = mapper;
        }

        public async Task<UsersVm> Handle(UsersQuery request, CancellationToken cancellationToken)
        {
            var users = _touristAppContext.Users.Where(u => u.Id > 0 && u.StatusId != 0);

            List<UsersDto> userDtos = await users.ProjectTo<UsersDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);

            UsersVm userVm = new UsersVm
            {
                UserDtos = userDtos
            };

            return userVm;
        }
    }
}
