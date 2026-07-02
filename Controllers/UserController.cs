using Microsoft.AspNetCore.Mvc;

using CompetitionTrackerAPI.Interfaces;
using CompetitionTrackerAPI.DTOs;


namespace CompetitionTrackerAPI.Controllers{

    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(){
            var users = await _service.GetAllUsersAsync();

            return Ok(users);

        }

        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> GetUser(int id){
            var user = await _service.GetUserByIdAsync(id);

            if (user == null) return NotFound();

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserDto dto)
        {
            var createdUser = await _service.CreateUserAsync(dto);

            return CreatedAtAction(
                nameof(GetUser),
                new {id = createdUser.Id},
                createdUser
            );
        }
    }

}