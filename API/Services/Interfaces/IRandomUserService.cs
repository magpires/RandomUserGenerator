using API.Entities;
using API.ViewModel;

namespace API.Services.Interfaces
{
    public interface IRandomUserService
    {
        Task<ResponseViewModel<UserDetailsViewModel>> AddRandomUserAsync();
    }
}
