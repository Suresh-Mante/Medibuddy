using Medibuddy.Models;
using Medibuddy.Repositories;
using System.Data.SqlClient;

namespace Medibuddy.DataAccess
{
    public class DepartmentDataAccess : IDepartmentDataAccess
    {
        private readonly IConfiguration _configuration;
        private SqlConnection connection;
        private SqlCommand command;

        public DepartmentDataAccess(IConfiguration configuration)
        {
            _configuration = configuration;
            connection = new SqlConnection(_configuration.GetConnectionString("DbConnectionString"));
            command = connection.CreateCommand();
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
