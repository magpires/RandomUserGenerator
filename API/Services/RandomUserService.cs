using API.Context;
using API.Dtos;
using API.Entities;
using API.Models;
using API.Services.Interfaces;
using API.ViewModel;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;

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

        public async Task<ResponseViewModel<UserDetailsViewModel>> AddRandomUserAsync()
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
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();

                return new ResponseViewModel<UserDetailsViewModel>(200, user);
            }
            catch (Exception e)
            {
                List<string> errors = new List<string>{ e.Message };
                return new ResponseViewModel<UserDetailsViewModel>(500, errors);
            }
        }

        public async Task<ResponseViewModel<IEnumerable<UserViewModel>>> GetAsync()
        {
            try
            {
                var users = await _context.Users.OrderBy(x => x.FirstName).ToListAsync();
                return new ResponseViewModel<IEnumerable<UserViewModel>>(200, users.Select<User, UserViewModel>(x => x).AsEnumerable());
            }
            catch (Exception e)
            {
                List<string> errors = new List<string> { e.Message };
                return new ResponseViewModel<IEnumerable<UserViewModel>>(500, errors);
            }
        }

        public void MergeProperties(UserPutDto source, User destiny)
        {
            destiny.FirstName = string.IsNullOrEmpty(source.FirstName) ? destiny.FirstName : source.FirstName;
            destiny.LastName = string.IsNullOrEmpty(source.LastName) ? destiny.LastName : source.LastName;
            destiny.Email = string.IsNullOrEmpty(source.Email) ? destiny.Email : source.Email;
            destiny.Username = string.IsNullOrEmpty(source.Email) ? destiny.Email : source.Email;
        }

        public async Task<ResponseViewModel<UserDetailsViewModel>> PutAsync(int id, UserPutDto userPutDto)
        {
            try
            {
                List<string> errors = userPutDto.Validate();

                if (errors.Count > 0)
                    return new ResponseViewModel<UserDetailsViewModel>(400, errors);

                if (await _context.Users.AnyAsync(x => x.Email == userPutDto.Email))
                {
                    errors.Add("The email provided is already being used by another user");
                    return new ResponseViewModel<UserDetailsViewModel>(400, errors);
                }

                User? user = await _context.Users.FindAsync(id);

                if (user == null)
                {
                    errors.Add("User not found in database");
                    return new ResponseViewModel<UserDetailsViewModel>(404, errors);
                }

                MergeProperties(userPutDto, user);

                _context.Update(user);
                _context.SaveChanges();

                return new ResponseViewModel<UserDetailsViewModel>(200, user);
            }
            catch (Exception e)
            {
                List<string> errors = new List<string> { e.Message };
                return new ResponseViewModel<UserDetailsViewModel>(500, errors);
            }
        }
    }
}
