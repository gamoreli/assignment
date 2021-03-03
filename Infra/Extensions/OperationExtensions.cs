using System;
using Assignment.Core.Enums;

namespace Assignment.Infra.Extensions
{
    /// <summary>
    ///     Operation helper methods (extensions)
    /// </summary>
    public static class OperationExtensions
    {
        /// <summary>
        ///     Gets Operator Class e.g (In, Equal, Different, etc)
        /// </summary>
        /// <param name="operatorEnum">Operator</param>
        /// <param name="field">Field (Table)</param>
        /// <param name="values">Values (Table)</param>
        /// <returns></returns>
        public static object GetOperatorClass(this OperatorEnum operatorEnum, string field, params string[] values)
        {
            var type = Type.GetType($"Assignment.Core.Operators.{operatorEnum}, Assignment");

            return type != null ? Activator.CreateInstance(type, field, values) : null;
        }
    }
}