using CloudTrader.Mines.Service.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudTrader.Mines.Api.Exceptions
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            switch (context.Exception)
            {
                case MineAlreadyExistsException exception:
                    context.Result = new ConflictObjectResult(exception.Message);
                    break;
                case MineNotFoundException exception:
                    context.Result = new NotFoundObjectResult(exception.Message);
                    break;
                default:
                    context.Result = new StatusCodeResult(500);
                    break;
            }
        }
    }
}
