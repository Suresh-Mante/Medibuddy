using Medibuddy.Models;

namespace Medibuddy.Repositories
{
    public interface INurseRepository
    {
        public Task<Response<Nurse>> Create(Nurse nurse);
        public Task<Response<Nurse>> Get(int ID);
        public Task<Response<Nurse>> Get();
        public Task<Response<Nurse>> Update(int ID, Nurse nurse);
        public Task<Response<Nurse>> Delete(int ID);
    }
}
