using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TouristAppBackend.Application.Common.Interfaces;
using TouristAppBackend.Domain.Models;

namespace TouristAppBackend.Application.Users.Queries.GetUserForUpdate
{
    public class GetUserDetailForUpdateQueryHandler : IRequestHandler<GetUserDetailForUpdataQuery, GetUserDetailForUpdateVm>
    {
        private readonly ITouristAppContext _touristAppContext;
        private IMapper _mapper;

        public GetUserDetailForUpdateQueryHandler(ITouristAppContext touristAppContext, IMapper mapper)
        {
            _touristAppContext = touristAppContext;
            _mapper = mapper;
        }

        public async Task<GetUserDetailForUpdateVm> Handle(GetUserDetailForUpdataQuery request, CancellationToken cancellationToken)
        {
            User user = await _touristAppContext.Users.Where(x => x.StatusId != 0)
                .Include(u => u.MyAddress)
                .Where(u => u.Id == request.UserId)
                .FirstOrDefaultAsync(cancellationToken);

            GetUserDetailForUpdateVm userDetailVm = _mapper.Map<GetUserDetailForUpdateVm>(user);

            return userDetailVm;
        }
    }
}
