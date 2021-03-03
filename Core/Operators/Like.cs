using System.Linq;
using Assignment.Core.Operators.Base;

namespace Assignment.Core.Operators
{
    /// <summary>
    ///     Returns Like formatted query
    /// </summary>
    public class Like : BaseOperator
    {
        public Like(string property, string[] values)
            : base(property, values)
        { }

        public override string ToString() 
            => $"{Property} LIKE ({Values.FirstOrDefault()})";
    }
}