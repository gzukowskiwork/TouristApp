using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace TouristAppBackend.Application.Places.Queries.GetPlaceDetail
{
    public class GetPlaceDetailQuery: IRequest<PlaceDetailVm>
    {
        public int PlaceId { get; set; }
        public GetPlaceDetailQuery(int id)
        {
            PlaceId = id;
        }
    }
}
