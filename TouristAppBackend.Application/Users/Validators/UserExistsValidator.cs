using System;
using System.Linq;
using TouristAppBackend.Application.Common.Interfaces;
using TouristAppBackend.Application.Common.Interfaces.Validators;
using TouristAppBackend.Common;

namespace TouristAppBackend.Application.Users.Validators
{
    public class UserExistsValidator : IUserExistsValidator
    {
        private readonly ITouristAppContext _touristAppContext;

        public UserExistsValidator(ITouristAppContext touristAppContext)
        {
            _touristAppContext = touristAppContext;
        }

        public void Validte<T>(T tclass)
        {
            throw new NotImplementedException();
        }

        public void Validate(int userId)
        {
            if(!_touristAppContext.Users.Any(u=>u.Id == userId))
            {
                throw new ArgumentOutOfRangeException(string.Format(Constants.ErrorMesseges.UserNotFound, userId));
            }
        }
    }
}
