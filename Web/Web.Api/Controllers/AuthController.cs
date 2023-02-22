using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.Business.Exceptions;
using Web.Business.Operations;

namespace Web.Api.Controllers
{
    [Authorize]
    public class AuthController : BaseController
    {
        private readonly Logger.ILogger logger;
        private readonly IUserOperation userOperation;

        public AuthController(Logger.ILogger logger, IUserOperation userOperation)
        {
            this.logger = logger;
            this.userOperation = userOperation;
        }

        [AllowAnonymous]
        [HttpPost(nameof(Login))]
        public async Task<IActionResult> Login([FromBody] Business.Dtos.Login login)
        {
            var user = await userOperation.LoginAsync(login);

            return Ok(user);
        }

        [AllowAnonymous]
        [HttpPost(nameof(Register))]
        public async Task<IActionResult> Register([FromBody] Business.Dtos.Register register)
        {
            await userOperation.RegisterAsync(register);

            return Ok();
        }

        [HttpGet(nameof(VerifyAuthenticated))]
        public IActionResult VerifyAuthenticated()
        {
            return Ok();
        }

    }
}
