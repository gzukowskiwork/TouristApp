using TouristAppBackend.Domain.Common;

namespace TouristAppBackend.Application.Common.Interfaces
{
    public interface IAvarageRank
    {
        void CalculateAvarageRating(ICanBeRanked canBeRanked);
    }
}
