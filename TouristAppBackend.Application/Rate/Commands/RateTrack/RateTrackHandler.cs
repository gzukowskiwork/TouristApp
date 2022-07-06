using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TouristAppBackend.Application.Common.Interfaces;
using TouristAppBackend.Common;
using TouristAppBackend.Domain.Models;

namespace TouristAppBackend.Application.Rate.Commands.RateTrack
{
    public class RateTrackHandler : IRequestHandler<RateTrackCommand>
    {
        private readonly ITouristAppContext _touristAppContext;
        private readonly IMapper _mapper;

        public RateTrackHandler(ITouristAppContext touristAppContext, IMapper mapper)
        {
            _touristAppContext = touristAppContext;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(RateTrackCommand request, CancellationToken cancellationToken)
        {
            var track = await _touristAppContext.Tracks.Where(p => p.Id == request.TrackId).FirstOrDefaultAsync();

            if (track == null)
            {
                throw new ArgumentNullException(string.Format(Constants.ErrorMesseges.TrackNotFound, track.Id));
            }

            var rating = _mapper.Map<Rating>(request);

            try
            {
                track.Ratings.Append(rating);

                _touristAppContext.Ratings.Update(rating);

                await _touristAppContext.SaveChangesAsync(cancellationToken);
            }
            catch (Exception e)
            {
                throw new ArgumentException(string.Format(Constants.ErrorMesseges.SomethingWentWrong, e.Message, e.StackTrace));
            }
            return Unit.Value;
        }
    }
}
