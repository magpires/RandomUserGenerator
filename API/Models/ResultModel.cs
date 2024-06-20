namespace API.Models
{
    public class ResultModel
    {
        public string Gender { get; set; } = string.Empty;
        public NameModel Name { get; set; } = new NameModel();
        public LocationModel Location { get; set; } = new LocationModel();
        public string Email { get; set; } = string.Empty;
        public LoginModel Login { get; set; } = new LoginModel();
        public DobModel Dob { get; set; } = new DobModel();
        public RegisteredModel Registered { get; set; } = new RegisteredModel();
        public string Phone { get; set; } = string.Empty;
        public string Cell { get; set; } = string.Empty;
        public IdModel Id { get; set; } = new IdModel();
        public PictureModel Picture { get; set; } = new PictureModel();
        public string Nat { get; set; } = string.Empty;
    }
}
