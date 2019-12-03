using Library.Core.Settings;
using Library.Models.Inputs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        private readonly JwtConfiguration jwtConfiguration;

        public UserController(IUserService userService,
            JwtConfiguration _jwtConfiguration)
        {
            _userService = userService;
            jwtConfiguration = _jwtConfiguration;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]InUser model)
        {
            string secretKey = jwtConfiguration.SecretKey;
            return Ok(secretKey);
            /*var user = _userService.Authenticate(model.Username);
            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(user);*/
        }

        [Authorize(Roles = "user")]
        [HttpGet]
        public IActionResult GetAll()
        {            
            return Ok("All users ....");
        }
    }
}
