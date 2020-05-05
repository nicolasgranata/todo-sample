using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace TodoSample.WebApi.V1.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ApiController]
    public class ErrorController : ControllerBase
    {
        [Route("/error")]
        public IActionResult Error()
        {
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
            var errorMessage = context.Error.Message;

            Log.Logger.Error(errorMessage, context.Error);

            return Problem(detail: errorMessage, title: "An Unhandled Exception Occurred.");
        }
    }
}
