using System.Collections.Generic;
using Assignment.Core.ViewModels;
using Assignment.Infra.Pipeline.Logging;
using Assignment.Infra.Pipeline.Validation;

namespace Assignment.Features.GetUsersByQuery
{
    /// <summary>
    ///     Request
    /// </summary>
    public class GetUsersByQueryMessage : ILogRequest<QueryProjection>,
        IValidatableRequest<QueryProjection>
    {
        public GetUsersByQueryMessage(IEnumerable<OperationViewModel> operations) 
            => Operations = operations;
        public IEnumerable<OperationViewModel> Operations { get; }
    }
}