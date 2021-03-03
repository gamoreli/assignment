using Assignment.Core.ViewModels;
using FluentValidation;

namespace Assignment.Features.GetUsersByQuery
{
    /// <summary>
    ///     Validates the request
    /// </summary>
    public class GetUsersByQueryValidator : AbstractValidator<GetUsersByQueryMessage>
    {
        public GetUsersByQueryValidator()
        {
            RuleForEach(message => message.Operations)
                .SetValidator(new OperationValidator());
        }
    }

    /// <summary>
    ///     Validates the Operation
    /// </summary>
    public class OperationValidator : AbstractValidator<OperationViewModel>
    {
        public OperationValidator()
        {
            RuleFor(message => message.Operator)
                .IsInEnum()
                .WithMessage("Operator is not implemented");
        }
    }
}