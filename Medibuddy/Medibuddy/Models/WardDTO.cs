using Medibuddy.Utils;
using Medibuddy.CustomValidationAttributes;
using System.ComponentModel.DataAnnotations;

namespace Medibuddy.Models
{
    public class WardDTO
    {
        [Required(ErrorMessage = ErrorMessages.Required)]
        [NonZeroAndNonNegativeNumber(ErrorMessage = ErrorMessages.RequiredPositiveNumber)]
        public int DepId { get; set; }

        [Required(ErrorMessage = ErrorMessages.Required)]
        [NonZeroAndNonNegativeNumber(ErrorMessage = ErrorMessages.RequiredPositiveNumber)]
        public int RoomSpecialCapacity { get; set; }

        [NonZeroAndNonNegativeNumber(ErrorMessage = ErrorMessages.RequiredPositiveNumber)]
        [Required(ErrorMessage = ErrorMessages.Required)]
        public int RoomSharedCapacity { get; set; }

        [NonZeroAndNonNegativeNumber(ErrorMessage = ErrorMessages.RequiredPositiveNumber)]
        [Required(ErrorMessage = ErrorMessages.Required)]
        public int RoomGeneralCapacity { get; set; }
    }
}
