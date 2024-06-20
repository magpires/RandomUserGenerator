namespace API.Models
{
    public class LoginModel
    {
        public string Uuid { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Salt { get; set; } = string.Empty;
        public string Md5 { get; set; } = string.Empty;
        public string Sha1 { get; set; } = string.Empty;
        public string Sha256 { get; set; } = string.Empty;
    }
}
