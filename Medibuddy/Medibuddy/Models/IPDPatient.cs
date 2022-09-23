namespace Medibuddy.Models
{
    public class IPDPatient
    {
        public int ID { get; set; }
        public int PID { get; set; }
        public int DocId { get; set; }
        public int NurseID { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime ExitDate { get; set; }
        public int RoomID { get; set; }
        public bool Discharged { get; set; }
    }
}
