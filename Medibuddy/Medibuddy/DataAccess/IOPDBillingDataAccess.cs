using Medibuddy.Models;

namespace Medibuddy.DataAccess
{
    public interface IOPDBillingDataAccess
    {
        public Task<OPDBilling> Create(OPDBilling opdbilling);
        public Task<OPDBilling?> Get(int id);
        public Task<IEnumerable<OPDBilling>> Get();
        public Task<OPDBilling?> Update(int id, OPDBilling opdbilling);
        public Task<bool> Delete(int id);
    }
}
