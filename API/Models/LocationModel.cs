namespace API.Models
{
    public class LocationModel
    {
        public StreetModel Street { get; set; } = new StreetModel();
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string Postcode { get; set; } = string.Empty;
        public CoordinatesModel Coordinates { get; set; } = new CoordinatesModel();
        public TimezoneModel Timezone { get; set; } = new TimezoneModel();

    }
}
