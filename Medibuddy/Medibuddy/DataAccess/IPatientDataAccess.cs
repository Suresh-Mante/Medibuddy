using Medibuddy.Models;

namespace Medibuddy.DataAccess
{
    public interface IPatientDataAccess
    {
        public Patient Create(Patient patient);
        public Patient Get(int PID);
        public IEnumerable<Patient> Get();
        public Patient Update(int PID, Patient patient);
        public Patient Delete(int PID);
    }
}
