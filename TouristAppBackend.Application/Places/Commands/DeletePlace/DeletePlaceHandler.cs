using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TouristAppBackend.Application.Common.Interfaces;

namespace TouristAppBackend.Application.Places.Commands.DeletePlace
{
    internal class DeletePlaceHandler : IRequestHandler<DeletePlaceCommand>
    {
        private readonly ITouristAppContext _touristAppContext;

        public DeletePlaceHandler(ITouristAppContext touristAppContext)
        {
            _touristAppContext = touristAppContext;
        }

        public async Task<Unit> Handle(DeletePlaceCommand request, CancellationToken cancellationToken)
        {
            var place = await _touristAppContext.Places.Where(p => p.Id == request.PlaceId).FirstOrDefaultAsync(cancellationToken);

            _touristAppContext.Places.Remove(place);

            await _touristAppContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
