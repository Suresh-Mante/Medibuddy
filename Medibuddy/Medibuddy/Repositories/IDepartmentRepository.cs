using Medibuddy.Models;

namespace Medibuddy.Repositories
{
    public interface IDepartmentRepository
    {
        public Task<Response<Department>> Create(Department department);
        public Task<Response<Department>> Get(int DepID);
        public Task<Response<Department>> Get();
        public Task<Response<Department>> Update(int DepID, Department department);
        public Task<Response<Department>> Delete(int DepID);
    }
}
