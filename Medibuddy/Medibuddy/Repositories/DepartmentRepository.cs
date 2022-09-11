using Medibuddy.DataAccess;
using Medibuddy.Models;

namespace Medibuddy.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly IDepartmentDataAccess _departmentDataAccess;

        public DepartmentRepository(IDepartmentDataAccess departmentDataAccess)
        {
            _departmentDataAccess = departmentDataAccess;
        }
        public Department Create(Department department)
        {
            //Write your implementation here
            throw new NotImplementedException();
        }

        public Department Delete(int DepID)
        {
            //Write your implementation here
            throw new NotImplementedException();
        }

        public Department Get(int DepID)
        {
            //Write your implementation here
            throw new NotImplementedException();
        }

        public IEnumerable<Department> Get()
        {
            //Write your implementation here
            throw new NotImplementedException();
        }

        public Department Update(int DepID, Department department)
        {
            //Write your implementation here
            throw new NotImplementedException();
        }
    }
}
