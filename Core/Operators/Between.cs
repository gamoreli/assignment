using Assignment.Core.Operators.Base;

namespace Assignment.Core.Operators
{
    /// <summary>
    ///     Returns Between formatted query
    /// </summary>
    public class Between : BaseOperator
    {
        public Between(string property, string[] values) : base(property, values)
        { }

        public override string ToString() 
            => $"{Property} BETWEEN {Values[0]} AND {Values[1]}";
    }
}