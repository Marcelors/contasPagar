using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BILLSToPAY.API.Middleware
{
    public class GlobalExceptionHandlingFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var response = context.HttpContext.Response;

            response.StatusCode = 500;
            response.ContentType = "application/json";
            var message = context.Exception.InnerException == null
                ? context.Exception.Message
                : context.Exception.InnerException.Message;

            context.ExceptionHandled = true;
            context.Result = new JsonResult(new { message });

        }
    }
}
