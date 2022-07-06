using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TouristAppBackend.Application.Common.Interfaces;
using TouristAppBackend.Common;
using TouristAppBackend.Domain.Models;

namespace TouristAppBackend.Application.Tracks.Queries.GetTrackDetail
{
    public class GetTrackDetailQueryHandler : IRequestHandler<GetTrackDetailQuery, GetTrackDetailVm>
    {
        private readonly ITouristAppContext _touristAppContext;
        private readonly IMapper _mapper;
        private readonly IAvarageRank _avarageRank;
        private readonly ICurrentUserService _currentUserService;

        public GetTrackDetailQueryHandler(
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

        public async Task<GetTrackDetailVm> Handle(GetTrackDetailQuery request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new ArgumentNullException(string.Format(Constants.ErrorMesseges.RequestCannotBeNull, nameof(request)));
            }
            
            Track track = await _touristAppContext.Tracks.Where(x => x.StatusId != 0)
                .Where(x => x.Id == request.TrackId)
                .Include(c => c.Coordinates.Where(s => s.StatusId != 0).OrderBy(x => x.TrackPointId)).AsSplitQuery()
                .Include(cm=>cm.Comments.Where(s=>s.StatusId != 0)).ThenInclude(a=>a.Author)
                .Include(r=>r.Ratings)
                .FirstOrDefaultAsync(cancellationToken);

            if (track == null)
            {
                throw new ArgumentOutOfRangeException(string.Format(Constants.ErrorMesseges.TrackNotFound, request.TrackId));
            }

            if (track.IsPrivate && track.CreatedBy != _currentUserService.Email)
            {
                throw new UnauthorizedAccessException();
            }

            var pictures = await _touristAppContext.Pictures.Where(x => x.StatusId != 0)
                .Where(x => x.PhotoOfTrackId == request.TrackId)
                .Include(r => r.Ratings)
                .Include(cm => cm.Comments).ThenInclude(a => a.Author).ToListAsync(cancellationToken);
            
            var validPictures = pictures;

            for(int i = pictures.Count -1; i>=0; i--)
            {
                if (pictures[i].IsPrivate && track.CreatedBy != _currentUserService.Email)
                {
                    validPictures.RemoveAt(i);
                }
            }

            track.Pictures = validPictures;
            
            _avarageRank.CalculateAvarageRating(track);

            foreach (var picture in track.Pictures)
            {
                _avarageRank.CalculateAvarageRating(picture);
            }

            GetTrackDetailVm getTrackDetailVm = _mapper.Map<GetTrackDetailVm>(track);

            return getTrackDetailVm;
        }
    }
}
