using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TouristAppBackend.Application.Common.Interfaces;
using TouristAppBackend.Domain.Models;

namespace TouristAppBackend.Application.ForecastPlaces.Commands.UpdateForecastPlace
{
    public class UpdateForecastHandler : IRequestHandler<UpdateForecastCommand>
    {
        private readonly ITouristAppContext _touristAppContext;
        private readonly IMapper _mapper;
        private readonly IDateTime _dateTime;

        public UpdateForecastHandler(ITouristAppContext touristAppContext, IMapper mapper, IDateTime dateTime)
        {
            _touristAppContext = touristAppContext;
            _mapper = mapper;
            _dateTime = dateTime;
        }

        public async Task<Unit> Handle(UpdateForecastCommand request, CancellationToken cancellationToken)
        {
            var forecast = _mapper.Map<Forecast>(request);


            var oldForecast = await _touristAppContext.Forecasts.Where(f => f.Id == forecast.Id).AsNoTracking().FirstOrDefaultAsync(cancellationToken);

            forecast.UserId = oldForecast.UserId;
            forecast.Created = oldForecast.Created;
            //forecast.CreatedBy = oldForecast.CreatedBy;
            forecast.UserId = oldForecast.UserId;
            forecast.Coordinate.Id = oldForecast.Coordinate.Id;
            //forecast.ModifiedBy = _touristAppContext.Users.Where(u => u.Id == forecast.Id).FirstOrDefault().Email;

            _touristAppContext.Forecasts.Update(forecast);

            await _touristAppContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
