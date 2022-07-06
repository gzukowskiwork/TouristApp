using MediatR;

namespace TouristAppBackend.Application.ForecastPlaces.Queries.GetForecastDetail
{
    public class GetForecastDetailQuery : IRequest<GetForecastDetailVm>
    {
        public int ForecastId { get; set; }
    }
}
