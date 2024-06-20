using API.Entities;

namespace API.Services.Interfaces
{
    public interface IRandomUserService
    {
        Task<User> GetRandomUserAsync()
    }
}
