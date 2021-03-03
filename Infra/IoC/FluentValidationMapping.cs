using FluentValidation;
using Lamar;

namespace Assignment.Infra.IoC
{
    /// <summary>
    ///     Map Dependency Injection for the FluentValidation 
    /// </summary>
    public class FluentValidationMapping : ServiceRegistry
    {
        public FluentValidationMapping()
        {
            AssemblyScanner.FindValidatorsInAssemblyContaining<Program>().ForEach(pair =>
            {
                For(pair.InterfaceType).Use(pair.ValidatorType);
            });
        }
    }
}