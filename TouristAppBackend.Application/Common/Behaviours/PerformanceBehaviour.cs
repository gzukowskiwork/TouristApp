using MediatR;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace TouristAppBackend.Application.Common.Behaviours
{
    public class PerformanceBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly ILogger _logger;
        private readonly Stopwatch _timer;

        public PerformanceBehaviour(ILogger<TRequest> logger)
        {
            _timer = new Stopwatch();
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            _timer.Start();

            var response = await next();

            _timer.Stop();

            var elsped = _timer.ElapsedMilliseconds;

            if (elsped > 500)
            {
                string requestName = typeof(TRequest).Name;

                _logger.LogInformation("TaskApp Request: {Name} ({elsped} miliseconds) {@Request}", requestName, elsped, request);
            }

            return response;
        }
    }
}
