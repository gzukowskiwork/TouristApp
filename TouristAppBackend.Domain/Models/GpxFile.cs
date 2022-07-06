using TouristAppBackend.Domain.Common;

namespace TouristAppBackend.Domain.Models
{
    public class GpxFile : AuditableEntity
    {
        public int? TrackId { get; set; }

        public Track Track { get; set; }

        public string FileName { get; set; }

        public string PathToFile { get; set; }
    }
}
