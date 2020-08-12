using CloudTrader.Mines.Service.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace CloudTrader.Mines.Api.Controllers
{
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorController : ControllerBase
    {
        [Route("/error")]
        public ObjectResult Error()
        {
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
            var exception = context?.Error;
            var code = 500;

            if (exception is MineNotFoundException) code = 404;

            Response.StatusCode = code;

            return Problem(detail: exception.Message, statusCode: code);
        }
    }
}
