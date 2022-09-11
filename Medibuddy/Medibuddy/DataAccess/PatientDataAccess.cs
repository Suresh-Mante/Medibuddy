using Medibuddy.Models;
using System.Data.SqlClient;

namespace Medibuddy.DataAccess
{
    public class PatientDataAccess: IPatientDataAccess
    {
        private readonly IConfiguration _configuration;
        private SqlConnection connection;
        private SqlCommand command;

        public PatientDataAccess(IConfiguration configuration)
        {
            _configuration = configuration;
            connection = new SqlConnection(_configuration.GetConnectionString("DbConnectionString"));
            command = connection.CreateCommand();
        }
        public Patient Create(Patient patient)
        {
            //Write your implementation here
            throw new NotImplementedException();
        }

        public Patient Delete(int PID)
        {
            //Write your implementation here
            throw new NotImplementedException();
        }

        public Patient Get(int PID)
        {
            //Write your implementation here
            throw new NotImplementedException();
        }

        public IEnumerable<Patient> Get()
        {
            //Write your implementation here
            throw new NotImplementedException();
        }

        public Patient Update(int PID, Patient patient)
        {
            //Write your implementation here
            throw new NotImplementedException();
        }
    }
}
