using System.Linq;
using Assignment.Core.Operators.Base;

namespace Assignment.Core.Operators
{
    /// <summary>
    ///     Returns Different formatted query
    /// </summary>
    public class Different : BaseOperator
    {
        public Different(string property, string[] values)
            : base(property, values)
        { }

        public override string ToString() 
            => $"{Property} <> {Values.FirstOrDefault()}";
    }
}