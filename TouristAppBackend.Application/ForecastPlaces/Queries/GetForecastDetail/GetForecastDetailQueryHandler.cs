using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TouristAppBackend.Application.Common.Interfaces;
using TouristAppBackend.Domain.Models;

namespace TouristAppBackend.Application.ForecastPlaces.Queries.GetForecastDetail
{
    public class GetForecastDetailQueryHandler : IRequestHandler<GetForecastDetailQuery, GetForecastDetailVm>
    {
        private readonly ITouristAppContext _touristAppContext;
        private readonly IMapper _mapper;

        public GetForecastDetailQueryHandler(ITouristAppContext touristAppContext, IMapper mapper)
        {
            _touristAppContext = touristAppContext;
            _mapper = mapper;
        }

        public async Task<GetForecastDetailVm> Handle(GetForecastDetailQuery request, CancellationToken cancellationToken)
        {
            Forecast forecast = await _touristAppContext.Forecasts.Where(x => x.StatusId != 0)
                .Include(c => c.Coordinate).Where(f => f.Id == request.ForecastId).FirstOrDefaultAsync(cancellationToken);

            GetForecastDetailVm getForecastDetailVm = _mapper.Map<GetForecastDetailVm>(forecast);

            return getForecastDetailVm;
        }
    }
}
