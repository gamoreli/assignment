using MediatR;

namespace Assignment.Infra.Pipeline.Validation
{
    /// <summary>
    ///     Decorates the request that must be validate
    /// </summary>
    /// <typeparam name="TResponse">Handler Response</typeparam>
    public interface IValidatableRequest<out TResponse> : IRequest<TResponse>
    { }
}