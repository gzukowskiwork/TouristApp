using MediatR;

namespace TouristAppBackend.Application.Places.Commands.DeletePlace
{
    public class DeletePlaceCommand: IRequest
    {
        public int PlaceId { get; set; }
    }
}
