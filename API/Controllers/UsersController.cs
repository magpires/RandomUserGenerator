using API.Context;
using API.Dtos;
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
        public async Task<ActionResult<User>> GetAsync()
        {
            var response = await _randomUserService.GetAsync();
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        public async Task<ActionResult<User>> AddRandomUserAsync()
        {
            var response = await _randomUserService.AddRandomUserAsync();
            return StatusCode(response.StatusCode, response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<User>> PutAsync(int id, UserPutDto userPutDto)
        {
            var response = await _randomUserService.PutAsync(id, userPutDto);
            return StatusCode(response.StatusCode, response);
        }
    }
}
