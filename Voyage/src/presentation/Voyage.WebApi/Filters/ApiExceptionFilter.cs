using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Voyage.WebApi.Filters
{
    public class ApiExceptionFilter : ExceptionFilterAttribute
    {
        private readonly IDictionary<Type, Action<ExceptionContext>> _iDictionaryExceptionHandler;

        public ApiExceptionFilter()
        {
            // TODO
        }

        public override void OnException(
            ExceptionContext exceptionContext
        )
        {
            // TODO
        }

        private void HandleException(
            ExceptionContext exceptionContext
        )
        {
            // TODO
        }

        private void HandleNotFoundException(
            ExceptionContext exceptionContext
        )
        {
            // TODO
        }

        private void HandleUnknownException(
            ExceptionContext exceptionContext
        )
        {
            // TODO
        }

        private void HandleValidationException(
            ExceptionContext exceptionContext
        )
        {
            // TODO
        }
    }
}
