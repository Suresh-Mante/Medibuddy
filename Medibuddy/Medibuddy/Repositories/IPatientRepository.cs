using Medibuddy.Models;

namespace Medibuddy.Repositories
{
    public interface IPatientRepository
    {
        public Task<Response<Patient>> Create(Patient patient);
        public Task<Response<Patient>> Get(int PID);
        public Task<Response<Patient>> Get();
        public Task<Response<Patient>> Update(int PID, Patient patient);
        public Task<Response<Patient>> Delete(int PID);
    }
}
