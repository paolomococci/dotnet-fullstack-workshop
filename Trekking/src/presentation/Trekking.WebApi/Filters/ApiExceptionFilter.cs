using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Trekking.Application.Common.Exceptions;

namespace Trekking.WebApi.Filters
{
    public class ApiExceptionFilter : ExceptionFilterAttribute
    {
        private readonly IDictionary<Type, Action<ExceptionContext>> _iDictionaryExceptionHandler;

        public ApiExceptionFilter()
        {
            _iDictionaryExceptionHandler = new Dictionary<Type, Action<ExceptionContext>>
            {
                { typeof(ValidationException), HandleValidationException },
                { typeof(NotFoundException), HandleNotFoundException }
            };
        }

        public override void OnException(
            ExceptionContext exceptionContext
        )
        {
            HandleException(exceptionContext);

            base.OnException(exceptionContext);
        }

        private void HandleException(
            ExceptionContext exceptionContext
        )
        {
            Type type = exceptionContext.Exception.GetType();

            if (_iDictionaryExceptionHandler.ContainsKey(type))
            {
                _iDictionaryExceptionHandler[type]
                    .Invoke(exceptionContext);

                return;
            }

            HandleUnknownException(exceptionContext);
        }

        private void HandleNotFoundException(
            ExceptionContext exceptionContext
        )
        {
            var notFoundException = exceptionContext.Exception as NotFoundException;

            var problemDetails = new ProblemDetails()
            {
                Type = "https://tools.ietf.org/html/rfc7231#section-6.5.4",
                Title = "The requested resource was not found.",
                Detail = notFoundException.Message
            };

            exceptionContext.Result = new NotFoundObjectResult(problemDetails);

            exceptionContext.ExceptionHandled = true;
        }

        private void HandleUnknownException(
            ExceptionContext exceptionContext
        )
        {
            var problemDetails = new ProblemDetails
            {
                Status = StatusCodes.Status500InternalServerError,
                Title = "An internal server error occurred while processing your request.",
                Type = "https://tools.ietf.org/html/rfc7231#section-6.6.1"
            };

            exceptionContext.Result = new ObjectResult(problemDetails)
            {
                StatusCode = StatusCodes.Status500InternalServerError
            };

            exceptionContext.ExceptionHandled = true;
        }

        private void HandleValidationException(
            ExceptionContext exceptionContext
        )
        {
            var validationException = exceptionContext.Exception as ValidationException;

            var problemDetails = new ProblemDetails()
            {
                Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1",
                Detail = validationException.Message
            };

            exceptionContext.Result = new NotFoundObjectResult(problemDetails);

            exceptionContext.ExceptionHandled = true;
        }
    }
}
