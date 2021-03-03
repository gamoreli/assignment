using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Serilog;

namespace Assignment.Infra.Pipeline.Validation
{
    /// <summary>
    ///     Handles the request validation and returns an exception in case of any failures
    /// </summary>
    /// <typeparam name="TRequest">Request</typeparam>
    /// <typeparam name="TResponse">Handler Response</typeparam>
    public class ValidationBehaviour<TRequest, TResponse>
        : IPipelineBehavior<TRequest, TResponse> where TRequest : IValidatableRequest<TResponse>
    {
        private readonly ILogger _logger;
        private readonly IValidator<TRequest> _validator;

        public ValidationBehaviour(ILogger logger, IValidator<TRequest> validator)
        {
            _logger = logger;
            _validator = validator;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken,
            RequestHandlerDelegate<TResponse> next)
        {
            _logger.Information(@"Message: Input validation on message {MessageName} started", typeof(TRequest).Name);

            var failures = (await _validator.ValidateAsync(request, cancellationToken)).Errors
                .Where(failure => failure != null).ToList();

            if (failures.Any())
            {
                _logger.Information(@"Message: Input validation on message {MessageName} failed",
                    typeof(TRequest).Name);

                throw new ValidationException("An error occurred validating the input model", failures);
            }

            _logger.Information(@"Message: Input validation on message {MessageName} succeeded", typeof(TRequest).Name);

            return await next();
        }
    }
}