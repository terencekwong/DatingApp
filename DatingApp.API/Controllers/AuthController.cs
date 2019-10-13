using System.Security.Claims;
using System.Threading.Tasks;
using DatingApp.API.Data;
using DatingApp.API.Dtos;
using DatingApp.API.Modules;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace DatingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repo;
        public AuthController(IAuthRepository repo)
        {
            _repo = repo;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto)
        {
            userForRegisterDto.username = userForRegisterDto.username.ToLower();

            if(await _repo.UserExist(userForRegisterDto.username))
                return BadRequest("Username already exists");

            var userToCreate = new User 
            {
                Username = userForRegisterDto.username
            };

            var createdUser = await _repo.Register(userToCreate, userForRegisterDto.password);

            return StatusCode(201);
        }

        // [HttpPost("login")]
        // public async Task<IActionResult> Login(UserForLoginDto userForLoginDto)
        // {
        //     var userFromRepo = await _repo.Login(userForLoginDto.Username, userForLoginDto.Password);

        //     if(userFromRepo == null)
        //         return Unauthorized();

        //     var claims = new[] 
        //     {
        //         new Claim(ClaimTypes.NameIdentifier, userFromRepo.Id.ToString()),
        //         new Claim(ClaimTypes.Name, userFromRepo.Username)
        //     };
        // }
    }
}