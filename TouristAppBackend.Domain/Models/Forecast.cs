using TouristAppBackend.Domain.Common;

namespace TouristAppBackend.Domain.Models
{
    public class Forecast : AuditableEntity
    {
        public string ForecastName { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public Coordinate Coordinate { get; set; }
    }
}
