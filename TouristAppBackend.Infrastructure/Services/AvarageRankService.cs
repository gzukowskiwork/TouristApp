using TouristAppBackend.Application.Common.Interfaces;
using TouristAppBackend.Domain.Common;

namespace TouristAppBackend.Infrastructure.Services
{
    public class AvarageRankService : IAvarageRank
    {
        public void CalculateAvarageRating(ICanBeRanked canBeRanked)
        {
            double totalRank = 0;
            foreach (var rating in canBeRanked.Ratings)
            {
                totalRank += rating.Rank;
            }
            canBeRanked.AvarageRate = 0;
            if (canBeRanked.Ratings.Count != 0)
            {
                canBeRanked.AvarageRate = totalRank / canBeRanked.Ratings.Count;
            }
        }
    }
}
