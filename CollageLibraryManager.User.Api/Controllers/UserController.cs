using CollageLibraryManager.User.Api.Manager;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CollageLibraryManager.User.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        [HttpPost("login")]
        public ActionResult<LoginResponse> Login([FromBody]LoginRequest request, [FromServices]IUserManager userManager)
        {
            var response = userManager.Login(request.UserId, request.password);
            return response;
        }
    }
}
