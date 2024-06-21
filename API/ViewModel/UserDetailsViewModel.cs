using API.Entities;

namespace API.ViewModel
{
    public class UserDetailsViewModel
    {
        public UserDetailsViewModel(User user)
        {
            FirstName = user.FirstName;
            LastName = user.LastName;
            Email = user.Email;
            Username = user.Username;
            Gender = user.Gender;
            Phone = user.Phone;
            Cell = user.Cell;
            PictureLarge = user.PictureLarge;
            PictureMedium = user.PictureMedium;
            PictureThumbnail = user.PictureThumbnail;
            DateOfBirth = user.DateOfBirth;
            Age = user.Age;
        }

        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Cell { get; set; } = string.Empty;
        public string PictureLarge { get; set; } = string.Empty;
        public string PictureMedium { get; set; } = string.Empty;
        public string PictureThumbnail { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public int Age { get; set; }

        public static implicit operator UserDetailsViewModel(User user)
        {
            return new UserDetailsViewModel(user);
        }
    }
}
