using System;
using System.Collections.Generic;
using TouristAppBackend.Domain.Common;

namespace TouristAppBackend.Domain.Models
{
    public class Place : AuditableEntity, ICanBeRanked, IProperties
    {
        public DateTime Published { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public double AvarageRate { get; set; }

        public int VisitorId { get; set; }

        public User Visitor { get; set; }

        public bool IsPrivate { get; set; }

        public DateTime? VisitedAt { get; set; }

        public Address PlaceAddress { get; set; }

        public ICollection<Picture> PicturesOfPlace { get; set; } = new List<Picture>();

        public ICollection<Rating> Ratings { get; set; } = new List<Rating>();

        public ICollection<Comment> Comments { get; set; } = new List<Comment>();

        public Coordinate Coordinate { get; set; }
    }
}
