using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TouristAppBackend.Application.Common.Interfaces;
using TouristAppBackend.Domain.Models;

namespace TouristAppBackend.Application.Places.Commands.UpdatePlace
{
    public class UpdatePlaceHandler : IRequestHandler<UpdatePlaceCommand>
    {
        private readonly ITouristAppContext _touristAppContext;
        private readonly IMapper _mapper;

        public UpdatePlaceHandler(ITouristAppContext touristAppContext, IMapper mapper)
        {
            _touristAppContext = touristAppContext;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdatePlaceCommand request, CancellationToken cancellationToken)
        {
            var place = _mapper.Map<Place>(request);

            var oldPlace = await _touristAppContext.Places.Where(p => p.Id == place.Id).AsNoTracking().FirstOrDefaultAsync(cancellationToken);

            place.Created = oldPlace.Created;
            //place.CreatedBy = await _touristAppContext.Users.Where(u => u.Id == place.VisitorId).Select(s => s.Email).FirstOrDefaultAsync(cancellationToken);
            place.VisitedAt = oldPlace.VisitedAt;
            //place.ModifiedBy = oldPlace.CreatedBy;
            place.Published = oldPlace.Published;
            place.Coordinate.Created = place.Created;
            //place.Coordinate.CreatedBy = oldPlace.CreatedBy;
            //place.Coordinate.ModifiedBy = oldPlace.CreatedBy;

            _touristAppContext.Places.Update(place);

            await _touristAppContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
