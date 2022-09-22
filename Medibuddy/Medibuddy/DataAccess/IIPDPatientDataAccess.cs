using Medibuddy.Models;


namespace Medibuddy.DataAccess
{
    public interface IIPDPatientDataAccess
    {
        public Task<IPDPatient> Create(IPDPatient ward);
        public Task<IPDPatient?> Get(int id);
        public Task<IEnumerable<IPDPatient>> Get();
        public Task<IPDPatient?> Update(int id, IPDPatient ward);
        public Task<bool> Delete(int id);
    }
}
