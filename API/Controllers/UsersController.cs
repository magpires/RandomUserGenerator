using API.Context;
using API.Entities;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly RandomUserService _randomUserService;

        public UsersController(RandomUserService randomUserService)
        {
            _randomUserService = randomUserService;
        }

        [HttpGet]
        public async Task<ActionResult<User>> Get()
        {
            var response = await _randomUserService.Get();
            return StatusCode(200, response);
        }

        [HttpPost]
        public async Task<ActionResult<User>> AddRandomUser()
        {
            var response = await _randomUserService.GetRandomUserAsync();
            return StatusCode(200, response);
        }
    }
}
