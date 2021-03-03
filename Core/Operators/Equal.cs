using System.Linq;
using Assignment.Core.Operators.Base;

namespace Assignment.Core.Operators
{
    /// <summary>
    ///     Returns Equal formatted query
    /// </summary>
    public class Equal : BaseOperator
    {
        public Equal(string property, string[] values)
            : base(property, values)
        { }

        public override string ToString() 
            => $"{Property} = {Values.FirstOrDefault()}";
    }
}