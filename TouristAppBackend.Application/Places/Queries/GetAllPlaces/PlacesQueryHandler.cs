using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TouristAppBackend.Application.Common.Interfaces;
using TouristAppBackend.Domain.Common;
using TouristAppBackend.Domain.Models;

namespace TouristAppBackend.Application.Places.Queries.GetAllPlaces
{
    class PlacesQueryHandler : IRequestHandler<PlacesQuery, PlacesVm>
    {
        private readonly ITouristAppContext _touristAppContext;
        private readonly IMapper _mapper;
        private readonly ISerachable<Place> _searchable;

        public PlacesQueryHandler(ITouristAppContext touristAppContext, IMapper mapper, ISerachable<Place> searchable)
        {
            _touristAppContext = touristAppContext;
            _mapper = mapper;
            _searchable = searchable;
        }

        public async Task<PlacesVm> Handle(PlacesQuery request, CancellationToken cancellationToken)
        {
            var places = _touristAppContext.Places.Where(p => p.Id > 0 && p.StatusId != 0);

            places = _searchable.SearchAndFilter(request, places);

            List<PlaceDto> placeDtos = await places
                .ProjectTo<PlaceDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            PlacesVm placesVm = new()
            {
                Places = placeDtos
            };

            return placesVm;
        }
    }
}
