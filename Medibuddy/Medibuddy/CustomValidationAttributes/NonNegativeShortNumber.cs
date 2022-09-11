using System.ComponentModel.DataAnnotations;

namespace Medibuddy.CustomValidationAttributes
{
    public class NonNegativeShortNumber : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            return value != null && (short)value >= 0;
        }
    }
}
