using Medibuddy.Models;

namespace Medibuddy.Repositories
{
    public interface IIPDTestRepository
    {

        public Task<Response<IPDTest>> Create(IPDTest ipdtest);
        public Task<Response<IPDTest>> Get(int IPDPatientID);
        public Task<Response<IPDTest>> Get();
        public Task<Response<IPDTest>> Delete(int IPDPatientID);
    }
}
