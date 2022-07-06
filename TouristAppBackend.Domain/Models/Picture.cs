using System;
using System.Collections.Generic;
using TouristAppBackend.Domain.Common;

namespace TouristAppBackend.Domain.Models
{
    public class Picture : AuditableEntity, ICanBeRanked
    {
        public string PathToImage { get; set; }

        public string PhotoName { get; set; }

        public string Description { get; set; }

        public bool IsPrivate { get; set; }

        public double AvarageRate { get; set; }

        public DateTime Taken { get; set; }

        public Coordinate Coordinate { get; set; }

        public int AuthorId { get; set; }

        public User Author { get; set; }

        public int? PhotoOfPlaceId { get; set; }

        public int? PhotoOfTrackId { get; set; }

        public Place PhotoOfPlace { get; set; }

        public Track PhotoOnTrack { get; set; }

        public ICollection<Comment> Comments { get; set; } = new List<Comment>();

        public ICollection<Rating> Ratings { get; set; } = new List<Rating>();
    }
}
