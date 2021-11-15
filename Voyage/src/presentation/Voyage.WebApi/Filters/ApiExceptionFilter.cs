using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Voyage.Application.Common.Exceptions;

namespace Voyage.WebApi.Filters
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
                // TODO
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
                Status = StatusCodes.Status500InternalServerError
                // TODO
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
            var exception = exceptionContext.Exception as ValidationException;

            var problemDetails = new ProblemDetails()
            {
                // TODO
                Detail = exception.Message
            };

            exceptionContext.Result = new NotFoundObjectResult(problemDetails);

            exceptionContext.ExceptionHandled = true;
        }
    }
}
