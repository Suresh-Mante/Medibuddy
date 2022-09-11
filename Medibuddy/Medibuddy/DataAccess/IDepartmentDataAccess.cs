using Medibuddy.Models;

namespace Medibuddy.DataAccess
{
    public interface IDepartmentDataAccess
    {
        public Department Create(Department department);
        public Department Get(int DepID);
        public IEnumerable<Department> Get();
        public Department Update(int DepID, Department department);
        public Department Delete(int DepID);
    }
}
