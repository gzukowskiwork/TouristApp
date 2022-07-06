using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TouristAppBackend.Domain.Common;

namespace TouristAppBackend.Application.Common.Interfaces
{
    public interface ISerachable<T> where T : IProperties
    {
        IQueryable<T> SearchAndFilter(ICanBeSortedAndSearched request, IQueryable<T> entity);
    }
}
