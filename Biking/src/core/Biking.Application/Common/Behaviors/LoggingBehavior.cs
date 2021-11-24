using System.Threading;
using System.Threading.Tasks;
using MediatR.Pipeline;
using Microsoft.Extensions.Logging;

namespace Biking.Application.Common.Behaviors
{
    public class LoggingBehavior<TRequest> : IRequestPreProcessor<TRequest>
    {
        private readonly ILogger _iLogger;

        public async Task Process(
            TRequest tRequest,
            CancellationToken cancellationToken
        )
        {
            await Task.Run(() =>
            {
                var requestName = typeof(TRequest).Name;
                _iLogger.LogInformation(
                    "Biking Request: {@Request}",
                    requestName,
                    tRequest
                );
            });
        }
    }
}
