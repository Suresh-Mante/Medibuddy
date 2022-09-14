using Medibuddy.Models;

namespace Medibuddy.DataAccess
{
    public interface IOPDTestDataAccess
    {
        public Task<OPDTest> Create(OPDTest opdtest);
        public Task<IEnumerable<OPDTest>> Get(int OPDBillingID);
        public Task<IEnumerable<OPDTest>> Get();
        public Task<bool> Delete(int OPDBillingID);

    }
}
