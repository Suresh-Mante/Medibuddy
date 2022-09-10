using Medibuddy.Models;
using System.Data;
using System.Data.SqlClient;

namespace Medibuddy.DataAccess
{
    public class WardDataAccess : IWardDataAccess
    {
        private readonly IConfiguration _configuration;
        private SqlConnection connection;
        private SqlCommand command;

        public WardDataAccess(IConfiguration configuration)
        {
            _configuration = configuration;
            connection = new SqlConnection(_configuration.GetConnectionString("DbConnectionString"));
            command = connection.CreateCommand();
        }

        public Ward Create(Ward ward)
        {
            //Write your implementation here
            throw new NotImplementedException();
        }

        public Ward Delete(int id)
        {
            //Write your implementation here
            throw new NotImplementedException();
        }

        public Ward Get(int id)
        {
            //Write your implementation here
            throw new NotImplementedException();
        }

        public IEnumerable<Ward> Get()
        {
            //Write your implementation here
            throw new NotImplementedException();
        }

        public Ward Update(int id, Ward ward)
        {
            //Write your implementation here
            throw new NotImplementedException();
        }
    }
}
