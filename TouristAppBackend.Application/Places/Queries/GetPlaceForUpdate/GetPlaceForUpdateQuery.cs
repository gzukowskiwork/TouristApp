using MediatR;

namespace TouristAppBackend.Application.Places.Queries.GetPlaceForUpdate
{
    public class GetPlaceForUpdateQuery : IRequest<GetPlaceForUpdateVm>
    {
        public int PlaceId { get; set; }
    }
}
