using System.Linq;
using Assignment.Core.Operators.Base;

namespace Assignment.Core.Operators
{
    /// <summary>
    ///     Returns LowerThanOrEqual formatted query
    /// </summary>
    public class LowerThanOrEqual : BaseOperator
    {
        public LowerThanOrEqual(string property, string[] values) : base(property, values)
        { }

        public override string ToString() 
            => $"{Property} <= {Values.FirstOrDefault()}";
    }
}