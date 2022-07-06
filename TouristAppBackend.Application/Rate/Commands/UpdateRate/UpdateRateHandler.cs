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

namespace TouristAppBackend.Application.Rate.Commands.UpdateRate
{
    public class UpdateRateHandler : IRequestHandler<UpdateRateCommand>
    {
        private readonly ITouristAppContext _touristAppContext;
        private readonly IMapper _mapper;

        public UpdateRateHandler(ITouristAppContext touristAppContext, IMapper mapper)
        {
            _touristAppContext = touristAppContext;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateRateCommand request, CancellationToken cancellationToken)
        {
            var rating = _mapper.Map<Rating>(request);
            var oldRating = await _touristAppContext.Ratings.Where(r => r.Id == rating.Id)
                .AsNoTracking()
                .FirstOrDefaultAsync(cancellationToken);

            if(oldRating == null)
            {
                throw new ArgumentNullException(string.Format(Constants.ErrorMesseges.RatingNotFound, rating.Id));
            }

            try
            {
                rating.PictureId = oldRating.PictureId;
                rating.PlaceId = oldRating.PlaceId;
                rating.TrackId = oldRating.TrackId;

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
