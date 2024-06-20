using API.Entities.Base;
using System.Xml.Linq;

namespace API.Entities
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Cell { get; set; } = string.Empty;
        public string PictureLarge { get; set; } = string.Empty;
        public string PictureMedium { get; set; } = string.Empty;
        public string PictureThumbnail { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public int Age { get; set; }
    }
}
