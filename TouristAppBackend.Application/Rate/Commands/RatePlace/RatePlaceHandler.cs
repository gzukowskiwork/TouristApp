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

namespace TouristAppBackend.Application.Rate.Commands.RatePlace
{
    public class RatePlaceHandler : IRequestHandler<RatePlaceCommand>
    {
        private readonly ITouristAppContext _touristAppContext;
        private readonly IMapper _mapper;

        public RatePlaceHandler(ITouristAppContext touristAppContext, IMapper mapper)
        {
            _touristAppContext = touristAppContext;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(RatePlaceCommand request, CancellationToken cancellationToken)
        {
            var place = await _touristAppContext.Places.Where(p => p.Id == request.PlaceId).FirstOrDefaultAsync();

            if (place == null)
            {
                throw new ArgumentNullException(string.Format(Constants.ErrorMesseges.PlaceNotFound, place.Id));
            }

            var rating = _mapper.Map<Rating>(request);

            try
            {
                place.Ratings.Append(rating);

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
