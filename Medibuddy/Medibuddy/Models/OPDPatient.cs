namespace Medibuddy.Models
{
    public class OPDPatient
    {
        public int ID { get; set; }
        public int PID { get; set; }
        public int DocId { get; set; }
        public DateTime VisitDate { get; set; }
        public int OPDBillingID { get; set; }
        public bool Discharged { get; set; }
    }
}
