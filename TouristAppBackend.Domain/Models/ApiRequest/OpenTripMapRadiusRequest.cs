namespace TouristAppBackend.Domain.Models.ApiRequest
{
    public class OpenTripMapRadiusRequest
    {
        public string Language { get; set; }
        public double Radius { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
    }
}
