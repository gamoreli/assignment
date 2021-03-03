using MediatR;

namespace Assignment.Infra.Pipeline.Logging
{
    /// <summary>
    ///     Decorates the request that must be logged
    /// </summary>
    /// <typeparam name="TResponse">Handler Response</typeparam>
    public interface ILogRequest<out TResponse> : IRequest<TResponse>
    { }
}