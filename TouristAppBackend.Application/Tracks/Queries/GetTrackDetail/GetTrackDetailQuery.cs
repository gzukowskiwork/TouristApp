using MediatR;

namespace TouristAppBackend.Application.Tracks.Queries.GetTrackDetail
{
    public class GetTrackDetailQuery : IRequest<GetTrackDetailVm>
    {
        public int TrackId { get; set; }
    }
}
