using Medibuddy.Models;

namespace Medibuddy.Repositories
{
    public interface IOPDBillingRepository
    {
        public Task<Response<OPDBilling>> Create(OPDBilling opdbilling);
        public Task<Response<OPDBilling>> Get(int id);
        public Task<Response<OPDBilling>> Get();
        public Task<Response<OPDBilling>> Update(int id, OPDBilling opdbilling);
        public Task<Response<OPDBilling>> Delete(int id);
    }
}
