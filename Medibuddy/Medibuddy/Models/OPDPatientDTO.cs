using Medibuddy.CustomValidationAttributes;
using Medibuddy.Utils;
using System.ComponentModel.DataAnnotations;

namespace Medibuddy.Models
{
    public class OPDPatientDTO
    {
        [Required(ErrorMessage = ErrorMessages.Required)]
        [NonZeroAndNonNegativeNumber(ErrorMessage = ErrorMessages.RequiredPositiveNumber)]
        public int PID { get; set; }

        [Required(ErrorMessage = ErrorMessages.Required)]
        [NonZeroAndNonNegativeNumber(ErrorMessage = ErrorMessages.RequiredPositiveNumber)]
        public int DocId { get; set; }

        [Required(ErrorMessage = ErrorMessages.Required)]
        public DateTime VisitDate { get; set; }

        [Required(ErrorMessage = ErrorMessages.Required)]
        [NonZeroAndNonNegativeNumber(ErrorMessage = ErrorMessages.RequiredPositiveNumber)]
        public int OPDBillingID { get; set; }

        [Required(ErrorMessage = ErrorMessages.Required)]
        public bool Discharged { get; set; } = false;
    }
}
