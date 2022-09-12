using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Medibuddy.Models
{
    public class Department
    {
        
        public int DepID { get; set; }
        
        public string DepName { get; set; }
    }
}
