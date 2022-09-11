using Medibuddy.Models;

namespace Medibuddy.Repositories
{
    public interface IPatientRepository
    {
        public Patient Create(Patient patient);
        public Patient Get(int PID);
        public IEnumerable<Patient> Get();
        public Patient Update(int PID, Patient patient);
        public Patient Delete(int PID);
    }
}
