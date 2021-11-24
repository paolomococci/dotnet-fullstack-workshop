using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Biking.Application.Common.Behaviors
{
    public class PerformanceBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly Stopwatch _stopwatch;
        private readonly ILogger<TRequest> _iLogger;

        public PerformanceBehavior(
            ILogger<TRequest> logger
        )
        {
            _stopwatch = new Stopwatch();
            _iLogger = logger;
        }

        public async Task<TResponse> Handle(
            TRequest tRequest,
            CancellationToken cancellationToken,
            RequestHandlerDelegate<TResponse> next
        )
        {
            _stopwatch.Start();
            var response = await next();
            _stopwatch.Stop();

            var elapsedMilliseconds = _stopwatch.ElapsedMilliseconds;

            if (elapsedMilliseconds <= 500)
            {
                return response;
            }

            var requestName = typeof(TRequest).Name;
            _iLogger.LogWarning(
                "Biking Long Running Request: {Name} ({ElapsedMilliseconds} milliseconds) {@Request}",
                requestName,
                elapsedMilliseconds,
                tRequest
            );
            return response;
        }
    }
}

