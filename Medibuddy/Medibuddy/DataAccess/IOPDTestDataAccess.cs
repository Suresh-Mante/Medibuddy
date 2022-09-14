using Medibuddy.Models;

namespace Medibuddy.DataAccess
{
    public interface IOPDTestDataAccess
    {
        public Task<OPDTest> Create(OPDTest opdtest);
        public Task<OPDTest?> Get(int OPDBillingID,int TestID);
        public Task<IEnumerable<OPDTest>> Get();
        public Task<OPDTest?> Update(int OPDBillingID,int TestID, OPDTest opdtest);
        public Task<bool> Delete(int OPDBillingID,int TestID);
    }
}
