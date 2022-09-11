using Medibuddy.Models;

namespace Medibuddy.DataAccess
{
    public interface IWardDataAccess
    {
        public Task<Ward> Create(Ward ward);
        public Task<Ward?> Get(int id);
        public Task<IEnumerable<Ward>> Get();
        public Task<Ward?> Update(int id, Ward ward);
        public Task<bool> Delete(int id);
    }
}
