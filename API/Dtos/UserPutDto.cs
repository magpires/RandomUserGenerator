using API.Entities;
using API.ViewModel;

namespace API.Dtos
{
    public class UserPutDto
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;

        public List<string> Validate()
        {
            List<string> errors = new List<string>();

            if (string.IsNullOrEmpty(FirstName))
                errors.Add("First name is required");

            if (string.IsNullOrEmpty(LastName))
                errors.Add("Last name is required");

            if (string.IsNullOrEmpty(Email))
                errors.Add("Email is required");

            if (string.IsNullOrEmpty(Username))
                errors.Add("Username name is required");

            return errors;
        }
    }
}
