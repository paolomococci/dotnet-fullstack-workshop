using System.Threading;
using System.Threading.Tasks;
using MediatR.Pipeline;
using Microsoft.Extensions.Logging;

namespace Cruises.Application.Common.Behaviors
{
  public class LoggingBehavior<TRequest>
    : IRequestPreProcessor<TRequest>
  {
    private readonly ILogger _iLogger;

    public LoggingBehavior(ILogger<TRequest> logger)
    {
      _iLogger = logger;
    }

    public async Task Process(
        TRequest tRequest,
        CancellationToken cancellationToken
    )
    {
      await Task.Run(() =>
      {
        var requestName = typeof(TRequest).Name;
        _iLogger.LogInformation(
          "Trekking Request: {@Request}",
          requestName,
          tRequest
        );
      });
    }
  }
}
