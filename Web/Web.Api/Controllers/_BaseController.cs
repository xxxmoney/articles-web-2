using Microsoft.AspNetCore.Mvc;

namespace Web.Api.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class BaseController : ControllerBase
    {
        /// <summary>
        /// Returns id of user - if user is logged in (by token).
        /// </summary>
        protected int? UserId => int.TryParse(User.Identity.Name, out int userId) ? userId : null;
    }
}
