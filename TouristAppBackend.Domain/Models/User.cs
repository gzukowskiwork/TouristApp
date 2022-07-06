using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TouristAppBackend.Domain.Common;

namespace TouristAppBackend.Domain.Models
{
    public class User : AuditableEntity
    {
        public string FirstName { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public string LastName { get; set; }

        public bool HasAddress { get; set; }

        public User Friend { get; set; }

        public ICollection<User> Friends { get; set; }

        public ICollection<Place> MyPlaces { get; set; }

        public ICollection<Comment> PostedComments { get; set; }

        public ICollection<Picture> MyPictures { get; set; }

        public ICollection<Forecast> MyForecastsPlaces { get; set; }

        public ICollection<Track> MyTracks { get; set; }

        public Address MyAddress { get; set; }
        
        //TODO Add avatar
    }
}
