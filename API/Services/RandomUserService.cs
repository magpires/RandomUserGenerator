using API.Context;
using API.Entities;
using API.Models;
using API.Services.Interfaces;
using API.ViewModel;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace API.Services
{
    public class RandomUserService : IRandomUserService
    {
        private readonly HttpClient _httpClient;
        private readonly RandomUserGeneratorContext _context;

        public RandomUserService(HttpClient httpClient, RandomUserGeneratorContext context)
        {
            _httpClient = httpClient;
            _context = context;
        }

        public async Task<ResponseViewModel<UserDetailsViewModel>> GetRandomUserAsync()
        {
            try
            {
                string response = await _httpClient.GetStringAsync("https://randomuser.me/api/");
                RandomUserResponseModel randomUserResponseModel = JsonConvert.DeserializeObject<RandomUserResponseModel>(response) ?? new RandomUserResponseModel();

                if (string.IsNullOrEmpty(randomUserResponseModel.Error) == false)
                {
                    List<string> errors = new List<string> { randomUserResponseModel.Error };
                    return new ResponseViewModel<UserDetailsViewModel>(400, errors);
                }

                ResultModel resultModel = randomUserResponseModel.Results.First();
                User user = resultModel;
                _context.Users.Add(user);
                _context.SaveChanges();

                return new ResponseViewModel<UserDetailsViewModel>(200, user);
            }
            catch (Exception e)
            {
                List<string> errors = new List<string>{ e.Message };
                return new ResponseViewModel<UserDetailsViewModel>(400, errors);
            }
        }
    }
}
