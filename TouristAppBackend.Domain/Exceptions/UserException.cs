using System;

namespace TouristAppBackend.Domain.Exceptions
{
    public class UserException : RankException
    {
        public UserException(string user, Exception e) : base($"Something is wrong with \"{user}\"", e)
        {

        }
    }
}
