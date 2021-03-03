using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using Assignment.Core;
using Assignment.Core.Models;
using MediatR;

namespace Assignment.Features.GetUsersByQuery
{
    /// <summary>
    ///     Handler - Executes queryBuilder to filter User and make Join with Post
    /// </summary>
    public class GetUsersByQueryHandler : IRequestHandler<GetUsersByQueryMessage, QueryProjection>
    {
        public Task<QueryProjection> Handle(GetUsersByQueryMessage message, CancellationToken cancellationToken)
        {
            var query = QueryBuilder.CreateSelect<User>()
                .WhereRaw(message.Operations)
                .JoinRaw<User, Post>();

            if (query != null)
                return Task.FromResult(new QueryProjection(query));
            
            throw new ValidationException("Something went wrong with your query");
        }
    }
}