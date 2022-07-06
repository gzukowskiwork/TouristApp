namespace TouristAppBackend.Application.Common.Interfaces.Validators
{
    public interface IUserExistsValidator : IBaseValidator
    {
        void Validate(int userId);
    }
}
