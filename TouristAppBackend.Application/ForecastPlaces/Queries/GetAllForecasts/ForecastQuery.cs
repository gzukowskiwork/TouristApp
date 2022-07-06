using MediatR;

namespace TouristAppBackend.Application.ForecastPlaces.Queries.GetAllForecasts
{
    public class ForecastQuery : IRequest<ForecastVm>
    {
    }
}
