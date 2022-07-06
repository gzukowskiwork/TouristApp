namespace TouristAppBackend.Domain.Models.ApiResponse
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class OpenTripMapRadiusResponse
    {
        public string name { get; set; }
        public string osm { get; set; }
        public string xid { get; set; }
        public string wikidata { get; set; }
        public string kind { get; set; }
        public Point point { get; set; }
    }


}
