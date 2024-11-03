using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIGoldenData.Services;

namespace WebAPIGoldenData.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly TokenService _tokneService;

        public AuthController(TokenService tokenService)
        {
            _tokneService = tokenService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel login)
        {
            if (login.Username == "admin" && login.Password == "gd123")
            {
                var token = _tokneService.GenerateToken(login.Username);
                return Ok(new { token });
            }

            return Unauthorized();
        }
    }

        public class LoginModel
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }
    
}
