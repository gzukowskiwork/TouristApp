using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TouristAppBackend.Application.Common.Interfaces;
using TouristAppBackend.Domain.Models;

namespace TouristAppBackend.Application.Users.Queries.GetUserDetail
{
    public class GetUserDetailQueryHandler : IRequestHandler<GetUserDetailQuery, UserDetailVm>
    {
        private readonly ITouristAppContext _touristAppContext;
        private IMapper _mapper;

        public GetUserDetailQueryHandler(ITouristAppContext touristAppContext, IMapper mapper)
        {
            _mapper = mapper;
            _touristAppContext = touristAppContext;
        }

        public async Task<UserDetailVm> Handle(GetUserDetailQuery request, CancellationToken cancellationToken)
        {
            User user = await _touristAppContext.Users.Where(x => x.StatusId != 0)
                .Include(u => u.Friends.Where(f => f.StatusId != 0))
                .Include(u => u.MyForecastsPlaces.Where(f => f.StatusId != 0)).ThenInclude(c => c.Coordinate)
                .Include(u => u.MyAddress)
                .Include(u => u.MyTracks.Where(t=>t.StatusId != 0))
                .Include(u => u.MyPlaces.Where(p=>p.StatusId != 0)).ThenInclude(c=>c.Coordinate)
                .Where(u => u.Id == request.UserId)
                .FirstOrDefaultAsync(cancellationToken);

            UserDetailVm userDetailVm = _mapper.Map<UserDetailVm>(user);

            return userDetailVm;
        }
    }
}
