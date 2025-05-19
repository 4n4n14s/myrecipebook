using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MyRecipeBook.Communcation.Response;
using MyRecipeBook.Exceptions;
using MyRecipeBook.Exceptions.ExceptionsBase;
using System;

namespace MyRecipeBook.API.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
      

        public void OnException(ExceptionContext context)
        {
            if (context.Exception is MyRecipeBookExceptions)
            {
                HandleProjectException(context);
            }
            else
            {
                ThrowUnknowException(context);
            }
        }
        private void HandleProjectException(ExceptionContext context)
        {
            if (context.Exception is ErrorOnValidationException)
            {

                var exception = context.Exception as ErrorOnValidationException;
                context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
                context.Result = new BadRequestObjectResult(new ResponseErrorJson(exception.ErrorMesseges ));
            };
            
        }
        private void ThrowUnknowException(ExceptionContext context)
        {
            context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Result = new ObjectResult(new ResponseErrorJson(ResourceMessegesExceptions.Unknow_error));

        }
    }
    
    
}
