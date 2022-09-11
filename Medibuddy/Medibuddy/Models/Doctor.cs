namespace Medibuddy.Models
{
    public class Doctor
    {
        public int ID { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Type { get; set; } = String.Empty;
        public string Mobile { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;
        public char Gender { get; set; }
        public decimal Fees { get; set; }
        public decimal Salary { get; set; }
    }
}
