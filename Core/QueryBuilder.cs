using System.Collections.Generic;
using Assignment.Core.Enums;
using Assignment.Core.ViewModels;
using Assignment.Infra.Extensions;

namespace Assignment.Core
{
    /// <summary>
    ///     Builds the query
    /// </summary>
    public static class QueryBuilder
    {
        /// <summary>
        ///     Creates SELECT statement typed
        /// </summary>
        /// <typeparam name="T">Entity</typeparam>
        /// <returns>Query formatted as string</returns>
        public static string CreateSelect<T>() 
            => $"SELECT FROM {typeof(T).Name} ";
        
        /// <summary>
        ///     Adds Where statement to the query
        /// </summary>
        /// <param name="query">Query previously created</param>
        /// <param name="operations">(In, Equal, Different, etc)</param>
        /// <returns>Query formatted as string</returns>
        public static string WhereRaw(this string query, IEnumerable<OperationViewModel> operations) 
            => $"{query} WHERE {AddOperations(operations)} ";

        /// <summary>
        ///     Adds Join statement to the query
        /// </summary>
        /// <param name="query">Query previously created</param>
        /// <typeparam name="TBaseEntity">Base entity</typeparam>
        /// <typeparam name="TJoinEntity">Entity to be joined</typeparam>
        /// <returns>Query formatted as string</returns>
        public static string JoinRaw<TBaseEntity, TJoinEntity>(this string query)
        {
            var operations = new List<OperationViewModel>
            {
                new OperationViewModel
                {
                    Operator = OperatorEnum.Equal,
                    FieldName = $"{typeof(TJoinEntity).Name}.{typeof(TBaseEntity).Name}Id",
                    FieldValues = new[] {$"{typeof(TBaseEntity).Name}.Id"}
                }
            };
            
            return $"{query} INNER JOIN {typeof(TJoinEntity).Name} ON {AddOperations(operations)}";
            return null;
        }

        /// <summary>
        ///     Adds operators to the query
        /// </summary>
        /// <param name="operations">(In, Equal, Different, etc)</param>
        /// <returns>Built operator as string</returns>
        private static string AddOperations(IEnumerable<OperationViewModel> operations)
        {
            var query = "";

            foreach (var operation in operations.Detailed())
            {
                var queryToBeAdded = operation.Value.Operator
                    .GetOperatorClass(operation.Value.FieldName, operation.Value.FieldValues);

                if (queryToBeAdded != null)
                {
                    query += queryToBeAdded;

                    if (!operation.IsLast)
                        query += " AND ";
                }
            }

            return query;
        }
    }
}