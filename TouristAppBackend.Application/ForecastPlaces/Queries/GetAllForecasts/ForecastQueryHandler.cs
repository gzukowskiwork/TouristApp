using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TouristAppBackend.Application.Common.Interfaces;

namespace TouristAppBackend.Application.ForecastPlaces.Queries.GetAllForecasts
{
    public class ForecastQueryHandler : IRequestHandler<ForecastQuery, ForecastVm>
    {
        private readonly ITouristAppContext _touristAppContext;
        private readonly IMapper _mapper;

        public ForecastQueryHandler(ITouristAppContext touristAppContext, IMapper mapper)
        {
            _touristAppContext = touristAppContext;
            _mapper = mapper;
        }

        public async Task<ForecastVm> Handle(ForecastQuery request, CancellationToken cancellationToken)
        {
            var forecasts = _touristAppContext.Forecasts.Where(f => f.StatusId != 0 && f.Id > 0);

            List<ForecastDto> forecastDtos = await forecasts
                .ProjectTo<ForecastDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            ForecastVm forecastsVm = new ForecastVm
            {
                Forecasts = forecastDtos
            };

            return forecastsVm;
        }
    }
}
