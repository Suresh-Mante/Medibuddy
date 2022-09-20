using Medibuddy.Models;

namespace Medibuddy.Repositories
{
    public interface IOPDPatientRepository
    {
        public Task<Response<OPDPatient>> Create(OPDPatient ward);
        public Task<Response<OPDPatient>> Get(int id);
        public Task<Response<OPDPatient>> Get();
        public Task<Response<OPDPatient>> Update(int id, OPDPatient ward);
        public Task<Response<OPDPatient>> Delete(int id);
        public Task<Response<OPDPatient>> Discharge(int id);
    }
}
