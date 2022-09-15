using Medibuddy.CustomValidationAttributes;
using Medibuddy.Utils;
using System.ComponentModel.DataAnnotations;

namespace Medibuddy.Models
{
    public class OPDBillingDTO
    {
        [Required(ErrorMessage = ErrorMessages.Required)]
        [NonZeroAndNonNegativeNumber(ErrorMessage = ErrorMessages.RequiredPositiveNumber)]
        public int PID { get; set; }

        [Required(ErrorMessage = ErrorMessages.Required)]
        [NonZeroAndNonNegativeNumber(ErrorMessage = ErrorMessages.RequiredPositiveNumber)]
        public int DocId { get; set; }

    }
}