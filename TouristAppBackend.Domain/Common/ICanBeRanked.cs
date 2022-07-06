using System.Collections.Generic;
using TouristAppBackend.Domain.Models;

namespace TouristAppBackend.Domain.Common
{
    public interface ICanBeRanked
    {
        ICollection<Rating> Ratings { get; set; }
        public double AvarageRate { get; set; }
    }
}
