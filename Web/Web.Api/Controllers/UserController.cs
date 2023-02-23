using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.Business.Operations;

namespace Web.Api.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUserOperation userOperation;

        public UserController(IUserOperation userOperation)
        {
            this.userOperation = userOperation;
        }

        [AllowAnonymous]
        [HttpGet(nameof(GetById))]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            return Ok(await this.userOperation.GetUserByIdAsync(id));
        }
    }
}
