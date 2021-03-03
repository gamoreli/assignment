namespace Assignment.Core.Operators.Base
{
    /// <summary>
    ///     Base Operator with property and values
    /// </summary>
    public class BaseOperator
    {
        protected BaseOperator(string property, string[] values)
        {
            Property = property;
            Values = values;
        }

        protected string Property { get; }
        protected string[] Values { get; }
    }
}