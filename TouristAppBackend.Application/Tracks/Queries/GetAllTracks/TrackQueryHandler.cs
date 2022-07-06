using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TouristAppBackend.Application.Common.Interfaces;
using TouristAppBackend.Domain.Models;

namespace TouristAppBackend.Application.Tracks.Queries.GetAllTracks
{
    public class TrackQueryHandler : IRequestHandler<TrackQuery, TrackVm>
    {
        private readonly ITouristAppContext _touristAppContext;
        private readonly IMapper _mapper;
        private readonly ISerachable<Track> _serachable;

        public TrackQueryHandler(ITouristAppContext touristAppContext, IMapper mapper, ISerachable<Track> searchable)
        {
            _touristAppContext = touristAppContext;
            _mapper = mapper;
            _serachable = searchable;
        }

        public async Task<TrackVm> Handle(TrackQuery request, CancellationToken cancellationToken)
        {
            var tracks = _touristAppContext.Tracks.Where(x => x.StatusId != 0 && x.Id >0);

            tracks = _serachable.SearchAndFilter(request, tracks);

            List<TrackDto> trackDtos = await tracks
                .ProjectTo<TrackDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            TrackVm tracksVm = new()
            {
                Tracks = trackDtos
            };

            return tracksVm;
        }
    }
}
