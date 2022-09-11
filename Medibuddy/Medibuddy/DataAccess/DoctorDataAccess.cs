using Medibuddy.Models;
using System.Data;
using System.Data.SqlClient;

namespace Medibuddy.DataAccess
{
    public class DoctorDataAccess : IDoctorDataAccess
    {

        private readonly IConfiguration _configuration;
        private SqlConnection connection;
        private SqlCommand command;

        public DoctorDataAccess(IConfiguration configuration)
        {
            _configuration = configuration;
            connection = new SqlConnection(_configuration.GetConnectionString("DbConnectionString"));
            command = connection.CreateCommand();
        }
        public Doctor Create(Doctor doctor)
        {
            throw new NotImplementedException();
        }

        public Doctor Delete(int ID)
        {
            throw new NotImplementedException();
        }

        public Doctor Get(int ID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Doctor> Get()
        {
            throw new NotImplementedException();
        }

        public Doctor Update(int ID, Doctor doctor)
        {
            throw new NotImplementedException();
        }
    }
}
