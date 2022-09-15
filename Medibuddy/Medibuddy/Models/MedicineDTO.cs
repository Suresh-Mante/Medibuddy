using System.ComponentModel.DataAnnotations;

namespace Medibuddy.Models
{
    public class MedicineDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int Price { get; set; }
    }
}
