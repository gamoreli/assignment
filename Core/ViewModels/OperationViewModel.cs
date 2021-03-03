using Assignment.Core.Enums;

namespace Assignment.Core.ViewModels
{
    /// <summary>
    ///     ViewModel with input data
    /// </summary>
    public class OperationViewModel
    {
        public OperatorEnum Operator { get; set; }
        public string FieldName { get; set; }
        public string[] FieldValues { get; set; }
    }
}