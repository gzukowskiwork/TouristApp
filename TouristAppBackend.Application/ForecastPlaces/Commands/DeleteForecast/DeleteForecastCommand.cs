using MediatR;

namespace TouristAppBackend.Application.ForecastPlaces.Commands.DeleteForecast
{
    public class DeleteForecastCommand : IRequest
    {
        public int ForecastId { get; set; }
    }
}
