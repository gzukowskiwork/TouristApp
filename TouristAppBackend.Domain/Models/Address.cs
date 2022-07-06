using TouristAppBackend.Domain.Common;

namespace TouristAppBackend.Domain.Models
{
    public class Address : AuditableEntity
    {

        public string CityName { get; set; } = string.Empty;

        public string StreetName { get; set; } = string.Empty;

        public string BuildingNumber { get; set; } = string.Empty;

        public int? UserId { get; set; }

        public User User { get; set; }

        public int? PlaceId { get; set; }

        public Place Place { get; set; }

    }
}
