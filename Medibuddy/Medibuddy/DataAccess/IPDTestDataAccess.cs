using Medibuddy.Models;
using System.Data;
using System.Data.SqlClient;

namespace Medibuddy.DataAccess
{
    public class IPDTestDataAccess : IIPDTestDataAccess
    {

        private readonly IConfiguration _configuration;
        private SqlConnection connection;
        private SqlCommand command;

        public IPDTestDataAccess(IConfiguration configuration)
        {
            _configuration = configuration;
            connection = new SqlConnection(_configuration.GetConnectionString("DbConnectionString"));
            command = connection.CreateCommand();
        }

        public async Task<IPDTest> Create(IPDTest ipdtest)
        {
            connection.Open();
            command = connection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = $"Insert into {nameof(IPDTest)}({nameof(IPDTest.IPDPatientID)},{nameof(IPDTest.TestID)})" +
                                      $" Values({ipdtest.IPDPatientID},{ipdtest.TestID})";
            await command.ExecuteNonQueryAsync();
            connection.Close();
            return ipdtest;
        }

        public async Task<bool> Delete(int IPDPatientID)
        {
            connection.Open();
            command = connection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = $"Delete from {nameof(IPDTest)} where {nameof(IPDTest.IPDPatientID)} = {IPDPatientID}";
            await command.ExecuteNonQueryAsync();
            connection.Close();
            return true;
        }

        public async Task<IEnumerable<IPDTest>> Get()
        {
            List<IPDTest> ipdtests = new List<IPDTest>();

            connection.Open();
            command = connection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = $"Select {nameof(IPDTest.IPDPatientID)},{nameof(IPDTest.TestID)}" +
                                  $" from {nameof(IPDTest)}";

            SqlDataReader reader = await command.ExecuteReaderAsync();
            while (reader.Read())
            {
                ipdtests.Add(new IPDTest
                {
                    IPDPatientID = Convert.ToInt32(reader.GetValue(nameof(IPDTest.IPDPatientID))),
                    TestID = Convert.ToInt32(reader.GetValue(nameof(IPDTest.TestID)))

                });
            }
            reader.Close();
            reader.Dispose();
            connection.Close();
            return ipdtests;
        }


        public async Task<IEnumerable<IPDTest>> Get(int IPDPatientID)
        {
            List<IPDTest> ipdtests = new List<IPDTest>();

            connection.Open();
            command = connection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = $"Select {nameof(IPDTest.IPDPatientID)},{nameof(IPDTest.TestID)} from {nameof(IPDTest)} where {nameof(IPDTest.IPDPatientID)} = {IPDPatientID}";

            SqlDataReader reader = await command.ExecuteReaderAsync();
            while (reader.Read())
            {
                ipdtests.Add(new IPDTest
                {
                    IPDPatientID = Convert.ToInt32(reader.GetValue(nameof(IPDTest.IPDPatientID))),
                    TestID = Convert.ToInt32(reader.GetValue(nameof(IPDTest.TestID)))

                });
            }
            reader.Close();
            reader.Dispose();
            connection.Close();
            return ipdtests;
        }
    }
}
