using Medibuddy.Models;
using System.Data.SqlClient;

namespace Medibuddy.DataAccess
{
    public class TestDataAccess : ITestDataAccess
    {
        private readonly IConfiguration _configuration;
        private SqlConnection connection;
        private SqlCommand command;

        public TestDataAccess(IConfiguration configuration)
        {
            _configuration = configuration;
            connection = new SqlConnection(_configuration.GetConnectionString("DbConnectionString"));
            command = connection.CreateCommand();
        }
        public Test Create(Test test)
        {
            //Write your implementation here
            throw new NotImplementedException();
        }

        public Test Delete(int Id)
        {
            //Write your implementation here
            throw new NotImplementedException();
        }

        public Test Get(int Id)
        {
            //Write your implementation here
            throw new NotImplementedException();
        }

        public IEnumerable<Test> Get()
        {
            //Write your implementation here
            throw new NotImplementedException();
        }

        public Test Update(int Id, Test test)
        {
            //Write your implementation here
            throw new NotImplementedException();
        }
    }
}
