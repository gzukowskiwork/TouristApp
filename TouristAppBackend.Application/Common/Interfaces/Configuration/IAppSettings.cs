namespace TouristAppBackend.Application.Common.Interfaces.Configuration
{
    public interface IAppSettings
    {
        long AcceptedFileSize { get; }
        string OpenWeatherMapApiKey { get; }
        string OpenTripMapApiKey { get; }
        string BaseAddress { get; }
        string Language { get; }
    }
}
