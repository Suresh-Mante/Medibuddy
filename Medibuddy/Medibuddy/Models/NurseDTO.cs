using Medibuddy.Utils;
using Medibuddy.CustomValidationAttributes;
using System.ComponentModel.DataAnnotations;

namespace Medibuddy.Models
{
    public class NurseDTO
    {
        [Required(ErrorMessage = ErrorMessages.Required)]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = ErrorMessages.Required)]
        public string Mobile { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = ErrorMessages.Required)]
        public char Gender { get; set; }

        [NonNegativeDecimalNumber(ErrorMessage = ErrorMessages.RequiredPositiveNumber)]
        public decimal Salary { get; set; }
    }
}
