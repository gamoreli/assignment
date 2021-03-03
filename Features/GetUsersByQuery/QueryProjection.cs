namespace Assignment.Features.GetUsersByQuery
{
    /// <summary>
    ///     Handler Response
    /// </summary>
    public class QueryProjection
    {
        public QueryProjection(string query) 
            => Query = query;

        public string Query { get; }
    }
}