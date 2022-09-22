using Medibuddy.CustomValidationAttributes;
using Medibuddy.Utils;
using System.ComponentModel.DataAnnotations;

namespace Medibuddy.Models
{
    public class IPDPatientDTO
    {
        [Required(ErrorMessage = ErrorMessages.Required)]
        [NonZeroAndNonNegativeNumber(ErrorMessage = ErrorMessages.RequiredPositiveNumber)]
        public int PID { get; set; }

        [Required(ErrorMessage = ErrorMessages.Required)]
        [NonZeroAndNonNegativeNumber(ErrorMessage = ErrorMessages.RequiredPositiveNumber)]
        public int DocId { get; set; }

        [Required(ErrorMessage = ErrorMessages.Required)]
        [NonZeroAndNonNegativeNumber(ErrorMessage = ErrorMessages.RequiredPositiveNumber)]
        public int NurseID { get; set; }

        [Required(ErrorMessage = ErrorMessages.Required)]
        public DateTime EntryDate { get; set; }

        [Required(ErrorMessage = ErrorMessages.Required)]
        public DateTime ExitDate { get; set; }

        [Required(ErrorMessage = ErrorMessages.Required)]
        [NonZeroAndNonNegativeNumber(ErrorMessage = ErrorMessages.RequiredPositiveNumber)]
        public int RoomID { get; set; }

        [Required(ErrorMessage = ErrorMessages.Required)]
        public bool Discharged { get; set; } = false;
    }
}
