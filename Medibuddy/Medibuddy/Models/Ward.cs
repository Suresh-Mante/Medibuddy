namespace Medibuddy.Models
{
    public class Ward
    {
        public int Id { get; set; }
        public int DepId { get; set; }
        public int RoomSpecialCapacity { get; set; }
        public int RoomSharedCapacity { get; set; }
        public int RoomGeneralCapacity { get; set; }
    }
}
