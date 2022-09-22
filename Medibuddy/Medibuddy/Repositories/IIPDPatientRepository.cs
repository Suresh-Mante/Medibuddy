using Medibuddy.Models;

namespace Medibuddy.Repositories
{
    public interface IIPDPatientRepository  
    {
        public Task<Response<IPDPatient>> Create(IPDPatient ipdpatient);
        public Task<Response<IPDPatient>> Get(int id);
        public Task<Response<IPDPatient>> Get();
        public Task<Response<IPDPatient>> Update(int id, IPDPatient ipdpatient);
        public Task<Response<IPDPatient>> Delete(int id);
        public Task<Response<IPDPatient>> Discharge(int id);
    }
}
