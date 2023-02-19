using Microsoft.AspNetCore.Mvc;

namespace Web.Api.Controllers
{
    public class TestController : BaseController
    {
        // Logger test
        private readonly Serilog.ILogger logger;

        public TestController(Serilog.ILogger logger)
        {
            this.logger = logger;
        }

        [HttpGet(nameof(TestLog))]
        public IActionResult TestLog()
        {
            this.logger.Information("Test");

            return Ok();
        }
    }
}
