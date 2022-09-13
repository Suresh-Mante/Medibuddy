using Medibuddy.Models;

namespace Medibuddy.Repositories
{
    public interface IRoomRepository
    {
        public Task<Response<Room>> Create(Room ward);
        public Task<Response<Room>> Get(int id);
        public Task<Response<Room>> Get();
        public Task<Response<Room>> Update(int id, Room ward);
        public Task<Response<Room>> Delete(int id);
    }
}
