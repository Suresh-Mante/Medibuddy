namespace Medibuddy.Models
{
    public class Room
    {
        public int Id { get; set; }
        public int WardId { get; set; }
        public string Type { get; set; } = string.Empty;
        public decimal Rate { get; set; }
        public short CurrentBedCapacity { get; set; }
        public short MaxBedCapacity { get; set; } 
    }
}
