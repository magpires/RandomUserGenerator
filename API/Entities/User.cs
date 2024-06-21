using API.Entities.Base;
using API.Models;
using System.Xml.Linq;

namespace API.Entities
{
    
    public class User : BaseEntity
    {
        protected User() { }

        public User(ResultModel resultModel)
        {
            FirstName = resultModel.Name.First;
            LastName = resultModel.Name.Last;
            Email = resultModel.Email;
            Username = resultModel.Login.Username;
            Password = BCrypt.Net.BCrypt.HashPassword(resultModel.Login.Password);
            Gender = resultModel.Gender;
            Phone = resultModel.Phone;
            Cell = resultModel.Cell;
            PictureLarge = resultModel.Picture.Large;
            PictureMedium = resultModel.Picture.Medium;
            PictureThumbnail = resultModel.Picture.Thumbnail;
            DateOfBirth = resultModel.Dob.Date;
            Age = resultModel.Dob.Age;
        }

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

        public static implicit operator User(ResultModel resultModel)
        {
            return new User(resultModel);
        }
    }
}
