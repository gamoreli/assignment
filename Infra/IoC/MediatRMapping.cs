using Assignment.Infra.Pipeline.Logging;
using Assignment.Infra.Pipeline.Validation;
using Lamar;
using MediatR;
using MediatR.Pipeline;

namespace Assignment.Infra.IoC
{
    /// <summary>
    ///     Map Dependency Injection for the MediatR 
    /// </summary>
    public class MediatRMapping : ServiceRegistry
    {
        public MediatRMapping()
        {
            Scan(scanner =>
            {
                scanner.AssemblyContainingType<Program>();
                scanner.ConnectImplementationsToTypesClosing(typeof(IRequestHandler<,>));
                scanner.ConnectImplementationsToTypesClosing(typeof(INotificationHandler<>));
            });

            For(typeof(IPipelineBehavior<,>)).Add(typeof(RequestPreProcessorBehavior<,>));
            For(typeof(IPipelineBehavior<,>)).Add(typeof(RequestPostProcessorBehavior<,>));

            For(typeof(IPipelineBehavior<,>)).Add(typeof(LoggingBehaviour<,>));
            For(typeof(IPipelineBehavior<,>)).Add(typeof(ValidationBehaviour<,>));

            For<IMediator>().Use<Mediator>().Transient();

            For<ServiceFactory>().Use(ctx => ctx.GetInstance);
        }
    }
}