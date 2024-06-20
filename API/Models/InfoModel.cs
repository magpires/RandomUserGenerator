namespace API.Models
{
    public class InfoModel
    {
        public string Seed { get; set; } = string.Empty;
        public int Results { get; set; }
        public int Page { get; set; }
        public string Version { get; set; } = string.Empty;
    }
}
