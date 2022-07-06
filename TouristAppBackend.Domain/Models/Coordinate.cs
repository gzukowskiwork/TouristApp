using TouristAppBackend.Domain.Common;

namespace TouristAppBackend.Domain.Models
{
    public class Coordinate : AuditableEntity
    {
        public double Longitude { get; set; }

        public double Latitude { get; set; }

        public double? Altitude { get; set; }
        
        public int TrackPointId { get; set; }

        public int? PlaceId { get; set; }

        public Place Place { get; set; }

        public int? TrackId { get; set; }

        public Track Track { get; set; }

        public int? BasedOnGpxFileId { get; set; }

        public int? PictureId { get; set; }

        public Picture Picture { get; set; }

        public int? ForecastId { get; set; }

        public Forecast Forecast { get; set; }
    }
}
