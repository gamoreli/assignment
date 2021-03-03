using System.Linq;
using Assignment.Core.Operators.Base;

namespace Assignment.Core.Operators
{
    /// <summary>
    ///     Returns GreaterThanOrEqual formatted query
    /// </summary>
    public class GreaterThanOrEqual : BaseOperator
    {
        public GreaterThanOrEqual(string property, string[] values) : base(property, values)
        { }

        public override string ToString() 
            => $"{Property} >= {Values.FirstOrDefault()}";
    }
}