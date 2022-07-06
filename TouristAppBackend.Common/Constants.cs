namespace TouristAppBackend.Common
{
    public static class Constants
    {
        public static class ErrorMesseges
        {
            public static readonly string DeleteCommandCannotBeNull = "Delete command cannot be null {0}.";
            public static readonly string UpdateCommandCannotBeNull = "Update command cannot be null {0}.";
            public static readonly string CreateCommandCannotBeNull = "Create command cannot be null {0}.";
            public static readonly string RequestCannotBeNull = "Request cannot be null {0}";

            public static readonly string EntityDoesNotExists = "{0} does not exists.";
            public static readonly string CommentDoesNotExists = "Comment with Id {0} does not exists, exception in action {1}.";
            public static readonly string AddressDoesNotExists = "Address with Id {0} does not exists";
            public static readonly string AddressesAreEmpty = "There are no addresses";

            public static readonly string SomethingWentWrong = "Something went wrong. Message: {0},\r\n StackTrace{1}";

            public static readonly string FileToLarge = "File {0} is to large. Accepted file size : {1}";
            public static readonly string UnsupportedFileFormat = "File {0} is in unsupported file format";

            public static readonly string FileCannotBeNull = "File cannot be null";
            public static readonly string TrackNotFound = "Track with Id: {0} was not found";
            public static readonly string PlaceNotFound = "Place with Id: {0} was not found";
            public static readonly string ImageNotFound = "Place with Id: {0} was not found";
            public static readonly string RatingNotFound = "Rating with Id: {0} was not found";
            public static readonly string TrackCanotBeNull = "Track cannot be null";
            public static readonly string UserNotFound = "User with Id: {0} was not found";
        }
    }
}
