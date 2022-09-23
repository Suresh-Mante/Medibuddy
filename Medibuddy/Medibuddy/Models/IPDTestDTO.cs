using Medibuddy.Utils;
using Medibuddy.CustomValidationAttributes;
using System.ComponentModel.DataAnnotations;

namespace Medibuddy.Models
{
    public class IPDTestDTO
    {
        [NonZeroAndNonNegativeNumber(ErrorMessage = ErrorMessages.RequiredPositiveNumber)]
        [Required(ErrorMessage = ErrorMessages.Required)]
        public int IPDPatientID { get; set; }

        [NonZeroAndNonNegativeNumber(ErrorMessage = ErrorMessages.RequiredPositiveNumber)]
        [Required(ErrorMessage = ErrorMessages.Required)]
        public int TestID { get; set; }
    }
}
