using MediatR;
using System;
using TouristAppBackend.Application.Base;
using TouristAppBackend.Application.Common;

namespace TouristAppBackend.Application.Tracks.Queries.GetAllTracks
{
    public class TrackQuery : BaseSortingQuery, IRequest<TrackVm>, ICanBeSortedAndSearched
    {
        public TrackQuery(int quantity, string searchString, string ascDesc, DateTime? from, DateTime? to)
            : base(quantity, searchString, ascDesc, from, to)
        {
        }
    }
}
