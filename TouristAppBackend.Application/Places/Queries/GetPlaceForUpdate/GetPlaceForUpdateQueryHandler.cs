using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TouristAppBackend.Application.Common.Interfaces;
using TouristAppBackend.Domain.Models;

namespace TouristAppBackend.Application.Places.Queries.GetPlaceForUpdate
{
    public class GetPlaceForUpdateQueryHandler : IRequestHandler<GetPlaceForUpdateQuery, GetPlaceForUpdateVm>
    {
        private readonly ITouristAppContext _touristAppContext;
        private readonly IMapper _mapper;

        public GetPlaceForUpdateQueryHandler(ITouristAppContext touristAppContext, IMapper mapper)
        {
            _touristAppContext = touristAppContext;
            _mapper = mapper;
        }

        public async Task<GetPlaceForUpdateVm> Handle(GetPlaceForUpdateQuery request, CancellationToken cancellationToken)
        {
            Place place = await _touristAppContext.Places.Where(x => x.StatusId != 0)
                .Include(c => c.Coordinate)
                .Where(p => p.Id == request.PlaceId).FirstOrDefaultAsync(cancellationToken);

            GetPlaceForUpdateVm getPlaceForUpdateVm = _mapper.Map<GetPlaceForUpdateVm>(place);

            return getPlaceForUpdateVm;
        }
    }
}
