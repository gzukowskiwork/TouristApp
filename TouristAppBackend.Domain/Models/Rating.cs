using TouristAppBackend.Domain.Common;

namespace TouristAppBackend.Domain.Models
{
    public class Rating
    {
        public int Id { get; set; }

        public int Rank { get; set; }

        public int? TrackId { get; set; }

        public Track Track { get; set; }

        public int? PictureId { get; set; }

        public Picture Picture { get; set; }

        public int? PlaceId { get; set; }

        public Place Place { get; set; }
    }
}
