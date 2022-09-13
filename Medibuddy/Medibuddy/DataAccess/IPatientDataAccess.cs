using Medibuddy.Models;

namespace Medibuddy.DataAccess
{
    public interface IPatientDataAccess
    {
        public Task<Patient> Create(Patient patient);
        public Task<Patient?> Get(int PID);
        public Task<IEnumerable<Patient>> Get();
        public Task<Patient?> Update(int PID, Patient patient);
        public Task<bool> Delete(int PID);

    }
}

