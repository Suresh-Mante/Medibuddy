using Medibuddy.Models;

namespace Medibuddy.DataAccess
{
    public interface IIPDTestDataAccess
    {
        public Task<IPDTest> Create(IPDTest ipdtest);
        public Task<IEnumerable<IPDTest>> Get(int IPDPatientID);
        public Task<IEnumerable<IPDTest>> Get();
        public Task<bool> Delete(int IPDPatientID);
    }
}
