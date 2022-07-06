using System.Collections.Generic;
using TouristAppBackend.Domain.Common;

namespace TouristAppBackend.Domain.Models
{
    public class Comment : AuditableEntity
    {
        public string Content { get; set; }

        public int AuthorId { get; set; }

        public User Author { get; set; }

        public int? TrackId { get; set; }

        public Track CommentedTrack { get; set; }

        public int? PlaceId { get; set; }

        public Place CommentedPlace { get; set; }

        public int? PictureId { get; set; }

        public Picture CommentedPicture { get; set; }

        public int? ReplyId { get; set; }

        public virtual ICollection<Comment> Replies { get; set; } = new List<Comment>();
    }
}
