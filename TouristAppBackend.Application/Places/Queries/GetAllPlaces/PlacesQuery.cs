using MediatR;
using System;
using TouristAppBackend.Application.Base;
using TouristAppBackend.Application.Common;

namespace TouristAppBackend.Application.Places.Queries.GetAllPlaces
{
    public class PlacesQuery : BaseSortingQuery, IRequest<PlacesVm>, ICanBeSortedAndSearched
    {
        public PlacesQuery(int quantity, string searchString, string ascDesc, DateTime? from, DateTime? to)
            : base(quantity, searchString, ascDesc, from, to)
        {
        }
    }
}
