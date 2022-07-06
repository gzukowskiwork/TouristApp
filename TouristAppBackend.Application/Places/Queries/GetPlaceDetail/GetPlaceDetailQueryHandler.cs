using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TouristAppBackend.Application.Common.Interfaces;
using TouristAppBackend.Domain.Models;

namespace TouristAppBackend.Application.Places.Queries.GetPlaceDetail
{
    public class GetPlaceDetailQueryHandler : IRequestHandler<GetPlaceDetailQuery, PlaceDetailVm>
    {
        private readonly ITouristAppContext _touristAppContext;
        private readonly IMapper _mapper;
        private readonly IAvarageRank _avarageRank;
        private readonly ICurrentUserService _currentUserService;

        public GetPlaceDetailQueryHandler(
            ITouristAppContext touristAppContext,
            IMapper mapper,
            IAvarageRank avarageRank,
            ICurrentUserService currentUserService
            )
        {
            _touristAppContext = touristAppContext;
            _mapper = mapper;
            _avarageRank = avarageRank;
            _currentUserService = currentUserService;
        }

        public async Task<PlaceDetailVm> Handle(GetPlaceDetailQuery request, CancellationToken cancellationToken)
        {
            Place place = await _touristAppContext.Places.Where(x => x.StatusId != 0)
                .Include(u => u.Visitor).Where(x => x.StatusId != 0)
                .Include(i => i.PicturesOfPlace).Where(x => x.StatusId != 0)
                .Include(c => c.Coordinate).Where(x => x.StatusId != 0)
                .Include(cm => cm.Comments.Where(x => x.StatusId != 0))
                .ThenInclude(r => r.Replies.Where(x => x.StatusId != 0))
                .ThenInclude(r => r.Replies.Where(x => x.StatusId != 0))
                .ThenInclude(r => r.Replies.Where(x => x.StatusId != 0))
                .ThenInclude(r => r.Replies.Where(x => x.StatusId != 0))
                .ThenInclude(r => r.Replies.Where(x => x.StatusId != 0))
                .ThenInclude(r => r.Replies.Where(x => x.StatusId != 0))
                .Include(r => r.Ratings)
                .Include(r => r.PlaceAddress).Where(x => x.StatusId != 0)
                .Where(p => p.Id == request.PlaceId).FirstOrDefaultAsync(cancellationToken);

            if(place == null)
            {
                throw new ArgumentNullException();
            }

            if (place != null)
            {
                _avarageRank.CalculateAvarageRating(place);
            }

            if (!string.IsNullOrWhiteSpace(_currentUserService.Email) && (place.IsPrivate && place.CreatedBy != _currentUserService.Email))
            {
                throw new UnauthorizedAccessException();
            }

            var validPictures = place.PicturesOfPlace.ToList();

            for (int i = place.PicturesOfPlace.Count - 1; i >= 0; i--)
            {
                if (place.PicturesOfPlace.ToList()[i].IsPrivate 
                    && place.CreatedBy != _currentUserService.Email)
                {
                    validPictures.RemoveAt(i);
                }
            }

            place.PicturesOfPlace = validPictures;

            PlaceDetailVm placeDetailVm = _mapper.Map<PlaceDetailVm>(place);

            return placeDetailVm;
        }
    }
}
