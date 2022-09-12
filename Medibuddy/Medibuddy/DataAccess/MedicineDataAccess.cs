using Medibuddy.Models;
using System.Data.SqlClient;

namespace Medibuddy.DataAccess
{
    public class MedicineDataAccess : IMedicineDataAccess
    {
        private readonly IConfiguration _configuration;
        private SqlConnection connection;
        private SqlCommand command;

        public MedicineDataAccess(IConfiguration configuration)
        {
            _configuration = configuration;
            connection = new SqlConnection(_configuration.GetConnectionString("DbConnectionString"));
            command = connection.CreateCommand();
        }
        public Medicine Create(Medicine medicine)
        {
            //Write your implementation here
            throw new NotImplementedException();
        }

        public Medicine Delete(int Id)
        {
            //Write your implementation here
            throw new NotImplementedException();
        }

        public Medicine Get(int Id)
        {
            //Write your implementation here
            throw new NotImplementedException();
        }

        public IEnumerable<Medicine> Get()
        {
            //Write your implementation here
            throw new NotImplementedException();
        }

        public Medicine Update(int Id, Medicine medicine)
        {
            //Write your implementation here
            throw new NotImplementedException();
        }
    }
}
