using Medibuddy.CustomValidationAttributes;
using Medibuddy.Utils;
using System.ComponentModel.DataAnnotations;

namespace Medibuddy.Models
{
    public class DepartmentDTO
    {
        [Required]
        public string DepName { get; set; }
    }
}
