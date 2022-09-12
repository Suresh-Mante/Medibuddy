using Medibuddy.Models;
using System.Data;
using System.Data.SqlClient;

namespace Medibuddy.DataAccess
{
    public class NurseDataAccess : INurseDataAccess
    {

        private readonly IConfiguration _configuration;
        private SqlConnection connection;
        private SqlCommand command;

        public NurseDataAccess(IConfiguration configuration)
        {
            _configuration = configuration;
            connection = new SqlConnection(_configuration.GetConnectionString("DbConnectionString"));
            command = connection.CreateCommand();
        }

        public Nurse Create(Nurse nurse)
        {
            throw new NotImplementedException();
        }

        public Nurse Delete(int ID)
        {
            throw new NotImplementedException();
        }

        public Nurse Get(int ID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Nurse> Get()
        {
            throw new NotImplementedException();
        }

        public Nurse Update(int ID, Nurse nurse)
        {
            throw new NotImplementedException();
        }
    }
}
