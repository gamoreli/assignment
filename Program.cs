using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment.Core;
using Assignment.Core.ViewModels;
using Assignment.Features.GetUsersByQuery;
using Assignment.Infra.IoC;
using FluentValidation;
using Lamar;
using Lamar.Microsoft.DependencyInjection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace Assignment
{
    internal class Program
    {
        /// <summary>
        ///     Application
        /// </summary>
        /// <returns>Void</returns>
        private static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args)
                .Build();

            using (var scope = host.Services.CreateScope())
            {
                var mediator = scope.ServiceProvider.GetService<IMediator>();

                try
                {
                    var operations = JsonBuilder
                        .Deserialize<IEnumerable<OperationViewModel>>("Example.json");

                    var getUsersByQuery = new GetUsersByQueryMessage(operations);

                    var response = await mediator.Send(getUsersByQuery);
                    
                    Console.WriteLine($"Query: {response.Query}");
                }
                catch (ValidationException validationException)
                {
                    HandleValidationError(validationException);
                }
                catch (Exception exception)
                {
                    Console.WriteLine($"Error: {exception.InnerException}");
                }
            }

            await host.RunAsync();
        }

        /// <summary>
        ///     Writes validation errors (FluentValidation)
        /// </summary>
        /// <param name="validationException">Fluent Validation Exception</param>
        private static void HandleValidationError(ValidationException validationException)
        {
            var errors = validationException.Errors
                .GroupBy(objectProperties => objectProperties.PropertyName)
                .ToDictionary(objectProperty => objectProperty.Key,
                    element =>
                        string.Join(", ", element.Select(error => error.ErrorMessage).ToArray()));

            foreach (var (key, value) in errors) Console.WriteLine($"{key}: {value}");
        }

        /// <summary>
        ///     Builds the application, setting up services and log
        /// </summary>
        /// <returns>Builder</returns>
        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            var builder = new HostBuilder()
                .UseServiceProviderFactory<ServiceRegistry>(new LamarServiceProviderFactory())
                .UseLamar()
                .UseSerilog()
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddLamar(ServiceRegistry.For(registry =>
                    {
                        registry.IncludeRegistry<MediatRMapping>();
                        registry.IncludeRegistry<FluentValidationMapping>();
                    }));

                    services.AddSingleton((ILogger) new LoggerConfiguration()
                        .WriteTo.Console()
                        .CreateLogger());
                })
                .UseConsoleLifetime();

            return builder;
        }
    }
}