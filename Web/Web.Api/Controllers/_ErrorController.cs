using Azure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Net;
using Web.Api.ViewModels;
using Web.Business.Exceptions;

namespace Web.Api.Controllers
{
    [AllowAnonymous]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorController : ControllerBase
    {
        private readonly Logger.ILogger logger;

        public ErrorController(Logger.ILogger logger)
        {
            this.logger = logger;
        }

        [Route("error")]
        public Error Error()
        {
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
            var exception = context.Error;
            var code = HttpStatusCode.InternalServerError;

            // Check for bad request or not found exception.
            if (exception is BadRequestException || exception is NotFoundException)
            {
                code = HttpStatusCode.BadRequest;
                this.logger.Warn(exception, "Bad request.");
            }
            // Check for fatal exception.
            else if (exception is FatalException)
            {
                this.logger.Fatal(exception.ToString());
            }
            // Else just log the exception as error.
            else
            {
                this.logger.Error(exception, "Error.");
            }

            Response.StatusCode = (int)code;

            return new Error(exception);
        }
    }
}
