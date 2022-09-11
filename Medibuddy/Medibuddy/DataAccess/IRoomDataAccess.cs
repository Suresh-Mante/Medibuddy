using Medibuddy.Models;

namespace Medibuddy.DataAccess
{
    public interface IRoomDataAccess
    {
        public Task<Room> Create(Room ward);
        public Task<Room?> Get(int id);
        public Task<IEnumerable<Room>> Get();
        public Task<Room?> Update(int id, Room ward);
        public Task<bool> Delete(int id);
    }
}
