using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Serilog;

namespace Assignment.Infra.Pipeline.Logging
{
    /// <summary>
    ///     Handles the the initial and final log for the request
    /// </summary>
    /// <typeparam name="TRequest">Request</typeparam>
    /// <typeparam name="TResponse">Handler Response</typeparam>
    public class LoggingBehaviour<TRequest, TResponse>
        : IPipelineBehavior<TRequest, TResponse> where TRequest : ILogRequest<TResponse>
    {
        private readonly ILogger _logger;

        public LoggingBehaviour(ILogger logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken,
            RequestHandlerDelegate<TResponse> next)
        {
            _logger.Information(@"Message: Handling message {@Message}", typeof(TRequest).Name);

            var response = await next();

            _logger.Information(@"Message: Message {@Message} handled successfully", typeof(TRequest).Name);

            return response;
        }
    }
}