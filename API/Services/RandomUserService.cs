using API.Entities;
using API.Models;
using API.Services.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace API.Services
{
    public class RandomUserService : IRandomUserService
    {
        private readonly HttpClient _httpClient;

        public RandomUserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<User> GetRandomUserAsync()
        {
            string response = await _httpClient.GetStringAsync("https://randomuser.me/api/");
            RandomUserResponseModel? randomUserResponse = JsonConvert.DeserializeObject<RandomUserResponseModel>(response);
            ResultModel userResult = randomUserResponse.Results.First();

            var user = new User
            {
                FirstName = userResult.Name.First,
                LastName = userResult.Name.Last,
                Email = userResult.Email,
                Username = userResult.Login.Username,
                Password = userResult.Login.Password
            };

            // Você pode mapear mais campos se necessário

            return user;
        }
    }
}
