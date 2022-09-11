using System.ComponentModel.DataAnnotations;

namespace Medibuddy.CustomValidationAttributes
{
    public class NonZeroAndNonNegativeNumberAttribute: ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            return value != null && (int)value > 0;
        }
    }
}
