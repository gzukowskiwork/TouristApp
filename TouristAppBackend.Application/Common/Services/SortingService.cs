using System;
using System.Linq;
using TouristAppBackend.Application.Common.Interfaces;
using TouristAppBackend.Domain.Common;

namespace TouristAppBackend.Application.Common.Services
{
    public class SortingService<T>: ISerachable<T> where T : IProperties
    {

        public IQueryable<T> SearchAndFilter(ICanBeSortedAndSearched request, IQueryable<T> entity)
        {
            entity = entity.Take(request.Quantity);

            if (!string.IsNullOrWhiteSpace(request.SearchString))
            {
                entity = entity.Where(p => p.Name.Contains(request.SearchString) || p.Description.Contains(request.SearchString));
            }

            switch (request.AscDesc)
            {
                case "name_desc":
                    entity = entity.OrderByDescending(p => p.Name);
                    break;
                case "date":
                    entity = entity.OrderBy(p => p.VisitedAt);
                    break;
                case "date_desc":
                    entity = entity.OrderByDescending(p => p.VisitedAt);
                    break;
                default:
                    entity = entity.OrderBy(p => p.Name);
                    break;
            }

            if(request.From != null || request.To != null)
            {
                if(request.From == null)
                {
                    request.From = entity.Min(x => x.VisitedAt);
                }
                if(request.To == null)
                {
                    request.To = DateTime.Now;
                }
                entity = entity.Where(x=>x.VisitedAt>=request.From && x.VisitedAt<=request.To);
            }

            return entity;
        }
    }
}