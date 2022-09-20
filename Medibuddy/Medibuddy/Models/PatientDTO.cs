using System.ComponentModel.DataAnnotations;

namespace Medibuddy.Models
{
    public class PatientDTO
    {
        [Required]
        public string FirstName { get; set; }
        public string MidName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Mobile { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public char Gender { get; set; }
        [Required]
        public DateTime DOB { get; set; }
    }
}
