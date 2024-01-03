using JwtWebApi.Models.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JwtWebApi.Controllers
{
   
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly List<User> _users = new List<User>(); // Simulated user database

        // Simulated user authentication with a username and password
        [HttpPost("login")]
        public IActionResult Login(User user)
        {
            var existingUser = _users.FirstOrDefault(u => u.Username == user.Username && u.Password == user.Password);
            if (existingUser == null)
            {
                return Unauthorized();
            }

            // Generate and return JWT token on successful authentication
            var token = GenerateJwtToken(existingUser);
            return Ok(new { Token = token });
        }

        private string GenerateJwtToken(User user)
        {
            // Implement JWT token generation using libraries like System.IdentityModel.Tokens.Jwt
            // Example: create and return JWT token
            return "generated_jwt_token";
        }
    }

}
