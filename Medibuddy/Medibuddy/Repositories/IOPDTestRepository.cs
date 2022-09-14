using Medibuddy.Models;

namespace Medibuddy.Repositories
{
    public interface IOPDTestRepository
    {
        public Task<Response<OPDTest>> Create(OPDTest opdtest);
        public Task<Response<OPDTest>> Get(int OPDBillingID,int TestID);
        public Task<Response<OPDTest>> Get();
        public Task<Response<OPDTest>> Update(int OPDBillingID, int TestID, OPDTest opdtest);
        public Task<Response<OPDTest>> Delete(int OPDBillingID, int TestID);
    }
}
