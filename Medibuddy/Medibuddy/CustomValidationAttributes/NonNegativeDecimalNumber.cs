using System.ComponentModel.DataAnnotations;

namespace Medibuddy.CustomValidationAttributes
{
    public class NonNegativeDecimalNumber : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            return value != null && (decimal)value >= 0;
        }
    }
}
