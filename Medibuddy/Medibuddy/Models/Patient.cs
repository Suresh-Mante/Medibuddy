namespace Medibuddy.Models
{
    public class Patient
    {

        public int PID { get; set; }
        public string FirstName { get; set; }
        public string MidName { get; set; }
        public string LastName { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public char Gender { get; set; }
        public DateOnly Date { get; set; }
    }
}
