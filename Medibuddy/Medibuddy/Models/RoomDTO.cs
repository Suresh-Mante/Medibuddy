using Medibuddy.Utils;
using Medibuddy.CustomValidationAttributes;
using System.ComponentModel.DataAnnotations;

namespace Medibuddy.Models
{
    public class RoomDTO
    {
        [Required(ErrorMessage = ErrorMessages.Required)]
        [NonZeroAndNonNegativeNumber(ErrorMessage = ErrorMessages.RequiredPositiveNumber)]
        public int WardId { get; set; }

        [Required(ErrorMessage = ErrorMessages.Required)]
        public string Type { get; set; } = string.Empty;

        [Required(ErrorMessage = ErrorMessages.Required)]
        [NonNegativeDecimalNumber(ErrorMessage = ErrorMessages.RequiredNonNegativeNumber)]
        public decimal Rate { get; set; }

        [NonNegativeShortNumber(ErrorMessage = ErrorMessages.RequiredNonNegativeNumber)]
        [Required(ErrorMessage = ErrorMessages.Required)]
        public short CurrentBedCapacity { get; set; }

        [NonNegativeShortNumber(ErrorMessage = ErrorMessages.RequiredNonNegativeNumber)]
        [Required(ErrorMessage = ErrorMessages.Required)]
        public short MaxBedCapacity { get; set; }
    }
}
