using System;
using System.Collections.Generic;
using TouristAppBackend.Domain.Common;

namespace TouristAppBackend.Domain.Models
{
    public class Track : AuditableEntity, ICanBeRanked, IProperties
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsPrivate { get; set; }

        public int AuthorId { get; set; }

        public User Author { get; set; }

        public double AvarageRate { get; set; }

        public GpxFile GpxFile { get; set; }

        public DateTime? VisitedAt { get; set; }

        public ICollection<Comment> Comments { get; set; } = new List<Comment>();

        public ICollection<Rating> Ratings { get; set; } = new List<Rating>();

        public ICollection<Coordinate> Coordinates { get; set; } = new List<Coordinate>();

        public ICollection<Picture> Pictures { get; set; } = new List<Picture>();
    }
}
