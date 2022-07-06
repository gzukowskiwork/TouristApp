using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TouristAppBackend.Application.Common.Interfaces;

namespace TouristAppBackend.Application.ForecastPlaces.Commands.DeleteForecast
{
    public class DeleteForecastHandler : IRequestHandler<DeleteForecastCommand>
    {
        private readonly ITouristAppContext _touristAppContext;

        public DeleteForecastHandler(ITouristAppContext touristAppContext)
        {
            _touristAppContext = touristAppContext;
        }

        public async Task<Unit> Handle(DeleteForecastCommand request, CancellationToken cancellationToken)
        {
            var forecast = await _touristAppContext.Forecasts
                .Where(f => f.Id == request.ForecastId)
                .FirstOrDefaultAsync(cancellationToken);

            _touristAppContext.Forecasts.Remove(forecast);

            await _touristAppContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
