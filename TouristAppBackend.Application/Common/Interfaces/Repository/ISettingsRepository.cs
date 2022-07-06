namespace TouristAppBackend.Application.Common.Interfaces.Repository
{
    public interface ISettingsRepository
    {
        string GetByCode(string code);
    }
}
