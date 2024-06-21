using API.Entities;

namespace API.ViewModel
{
    public class UserViewModel
    {
        public UserViewModel(User user)
        {
            Id = user.Id;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Email = user.Email;
            Username = user.Username;
        }

        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;

        public static implicit operator UserViewModel(User user)
        {
            return new UserViewModel(user);
        }
    }
}
