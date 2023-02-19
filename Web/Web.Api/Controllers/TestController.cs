using Microsoft.AspNetCore.Mvc;

namespace Web.Api.Controllers
{
    public class TestController : BaseController
    {
        private readonly Logger.ILogger logger;
        
        public TestController(Logger.ILogger logger)
        {
            this.logger = logger;
        }

        [HttpGet(nameof(TestLog))]
        public IActionResult TestLog()
        {
            this.logger.Info("Test");

            return Ok();
        }
    }
}
