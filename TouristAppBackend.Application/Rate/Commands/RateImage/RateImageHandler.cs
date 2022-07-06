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

namespace TouristAppBackend.Application.Rate.Commands.RateImage
{
    internal class RateImageHandler : IRequestHandler<RateImageCommand>
    {
        private readonly ITouristAppContext _touristAppContext;
        private readonly IMapper _mapper;

        public RateImageHandler(ITouristAppContext touristAppContext, IMapper mapper)
        {
            _touristAppContext = touristAppContext;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(RateImageCommand request, CancellationToken cancellationToken)
        {
            var image = await _touristAppContext.Pictures.Where(p => p.Id == request.PictureId).FirstOrDefaultAsync();

            if (image == null)
            {
                throw new ArgumentNullException(string.Format(Constants.ErrorMesseges.ImageNotFound, image.Id));
            }

            var rating = _mapper.Map<Rating>(request);

            try
            {
                image.Ratings.Append(rating);

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
