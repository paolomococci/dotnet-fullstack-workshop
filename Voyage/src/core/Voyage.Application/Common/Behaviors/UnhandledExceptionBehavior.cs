using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Voyage.Application.Common.Behaviors
{
    public class UnhandledExceptionBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly ILogger<TRequest> _iLogger;

        public UnhandledExceptionBehavior(ILogger<TRequest> logger)
        {
            _iLogger = logger;
        }

        public async Task<TResponse> Handle(
                TRequest tRequest,
                CancellationToken cancellationToken,
                RequestHandlerDelegate<TResponse> next
            )
        {
            try
            {
                return await next();
            }
            catch (Exception exception)
            {
                var requestName = typeof(TRequest).Name;
                _iLogger.LogError(
                    exception,
                    "Voyage Request: Unhandled Exception for Request {Name} {@Request}",
                    requestName,
                    tRequest
                );
                throw;
            }
        }
    }
}
