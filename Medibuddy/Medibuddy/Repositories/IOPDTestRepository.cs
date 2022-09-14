using Medibuddy.Models;

namespace Medibuddy.Repositories
{
    public interface IOPDTestRepository
    {
        public Task<Response<OPDTest>> Create(OPDTest opdtest);
        public Task<Response<OPDTest>> Get(int OPDBillingID);
        public Task<Response<OPDTest>> Get();
        public Task<Response<OPDTest>> Delete(int OPDBillingID);

    }
}
