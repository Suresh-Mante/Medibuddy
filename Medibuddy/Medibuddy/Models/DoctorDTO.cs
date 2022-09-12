using Medibuddy.Utils;
using Medibuddy.CustomValidationAttributes;
using System.ComponentModel.DataAnnotations;

namespace Medibuddy.Models
{
    public class DoctorDTO
    {
        [Required(ErrorMessage = ErrorMessages.Required)]
        public string Name { get; set; } = String.Empty;

        [Required(ErrorMessage = ErrorMessages.Required)]
        public string Type { get; set; } = String.Empty;

        [Required(ErrorMessage = ErrorMessages.Required)]
        public string Mobile { get; set; } = String.Empty;

        public string Email { get; set; } = String.Empty;

        [Required(ErrorMessage = ErrorMessages.Required)]
        public char Gender { get; set; }

       
        public decimal Fees { get; set; }

        public decimal Salary { get; set; }
    }
}
