using Medibuddy.Models;

namespace Medibuddy.Repositories
{
    public interface IMedicineRepository
    {
        public Task<Response<Medicine>> Create(Medicine medicine);
        public Task<Response<Medicine>> Get(int Id);
        public Task<Response<Medicine>> Get();
        public Task<Response<Medicine>> Update(int Id, Medicine medicine);
        public Task<Response<Medicine>> Delete(int Id);
    }
}
