using Medibuddy.Models;
namespace Medibuddy.DataAccess
{
    public interface INurseDataAccess
    {
        public Task<Nurse> Create(Nurse nurse);
        public Task<Nurse> Get(int ID);
        public Task<IEnumerable<Nurse>> Get();
        public Task<Nurse> Update(int ID, Nurse nurse);
        public Task<bool> Delete(int ID);
    }
}
