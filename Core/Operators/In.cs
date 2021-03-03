using System.Linq;
using Assignment.Core.Operators.Base;

namespace Assignment.Core.Operators
{
    /// <summary>
    ///     Returns In formatted query
    /// </summary>
    public class In : BaseOperator
    {
        public In(string property, string[] values)
            : base(property, values)
        { }

        public override string ToString() 
            => $"{Property} IN ({string.Join(", ", Values.Select(value => value.ToString()).ToArray())})";
    }
}