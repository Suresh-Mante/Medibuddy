
using Medibuddy.Models;

namespace Medibuddy.DataAccess
{
    public interface IOPDPatientDataAccess
    {
        public Task<OPDPatient> Create(OPDPatient ward);
        public Task<OPDPatient?> Get(int id);
        public Task<IEnumerable<OPDPatient>> Get();
        public Task<OPDPatient?> Update(int id, OPDPatient ward);
        public Task<bool> Delete(int id);
    }
}
