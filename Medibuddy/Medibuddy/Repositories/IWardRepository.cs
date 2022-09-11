using Medibuddy.Models;

namespace Medibuddy.Repositories
{
    public interface IWardRepository
    {
        public Task<Response<Ward>> Create(Ward ward);
        public Task<Response<Ward>> Get(int id);
        public Task<Response<Ward>> Get();
        public Task<Response<Ward>> Update(int id, Ward ward);
        public Task<Response<Ward>> Delete(int id);
    }
}
