using Medibuddy.Models;

namespace Medibuddy.DataAccess
{
    public interface IMedicineDataAccess
    {
        public Task<Medicine?> Create(Medicine medicine);
        public Task<Medicine?> Get(int Id);
        public Task<IEnumerable<Medicine>> Get();
        public Task<Medicine?> Update(int Id, Medicine medicine);
        public Task<bool> Delete(int Id);
    }
}