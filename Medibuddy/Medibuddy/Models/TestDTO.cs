using System.ComponentModel.DataAnnotations; 
namespace Medibuddy.Models
{
    public class TestDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int Price { get; set; }
    }
}
