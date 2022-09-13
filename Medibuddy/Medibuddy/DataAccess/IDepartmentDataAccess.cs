using Medibuddy.Models;

namespace Medibuddy.DataAccess
{
    public interface IDepartmentDataAccess
    {
        public Task<Department> Create(Department department);
        public Task<Department?> Get(int DepID);
        public Task<IEnumerable<Department>> Get();
        public Task<Department?> Update(int DepID, Department department);
        public Task<bool> Delete(int DepID);
    }
}
