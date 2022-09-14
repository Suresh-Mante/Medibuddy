using Medibuddy.Models;
using System.Data;
using System.Data.SqlClient;

namespace Medibuddy.DataAccess
{
    public class OPDTestDataAccess : IOPDTestDataAccess
    {

        private readonly IConfiguration _configuration;
        private SqlConnection connection;
        private SqlCommand command;

        public OPDTestDataAccess(IConfiguration configuration)
        {
            _configuration = configuration;
            connection = new SqlConnection(_configuration.GetConnectionString("DbConnectionString"));
            command = connection.CreateCommand();
        }

        public async Task<OPDTest> Create(OPDTest opdtest)
        {
            connection.Open();
            command = connection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = $"Insert into {nameof(OPDTest)}({nameof(OPDTest.OPDBillingID)},{nameof(OPDTest.TestID)})" +                 
                                      $" Values({opdtest.OPDBillingID},{opdtest.TestID})";
            await command.ExecuteNonQueryAsync();
            connection.Close();
            return opdtest;
        }

        public async Task<bool> Delete(int OPDBillingID)
        {
            connection.Open();
            command = connection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = $"Delete from {nameof(OPDTest)} where {nameof(OPDTest.OPDBillingID)} = {OPDBillingID}";
            await command.ExecuteNonQueryAsync();
            connection.Close();
            return true;
        }

        public async Task<IEnumerable<OPDTest>> Get()
        {
            List<OPDTest> opdtests = new List<OPDTest>();

            connection.Open();
            command = connection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = $"Select {nameof(OPDTest.OPDBillingID)},{nameof(OPDTest.TestID)}"+
                                  $" from {nameof(OPDTest)}";
                                  
            SqlDataReader reader = await command.ExecuteReaderAsync();
            while (reader.Read())
            {
                opdtests.Add(new OPDTest
                {
                    OPDBillingID = Convert.ToInt32(reader.GetValue(nameof(OPDTest.OPDBillingID))),
                    TestID = Convert.ToInt32(reader.GetValue(nameof(OPDTest.TestID)))

                });
            }
            reader.Close();
            reader.Dispose();
            connection.Close();
            return opdtests;
        }


        public async Task<IEnumerable<OPDTest>> Get(int OPDBillingID)
        {
            List<OPDTest> opdtests = new List<OPDTest>();

            connection.Open();
            command = connection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = $"Select {nameof(OPDTest.OPDBillingID)},{nameof(OPDTest.TestID)} from {nameof(OPDTest)} where {nameof(OPDTest.OPDBillingID)} = {OPDBillingID}";

            SqlDataReader reader = await command.ExecuteReaderAsync();
            while (reader.Read())
            {
                opdtests.Add(new OPDTest
                {
                    OPDBillingID = Convert.ToInt32(reader.GetValue(nameof(OPDTest.OPDBillingID))),
                    TestID = Convert.ToInt32(reader.GetValue(nameof(OPDTest.TestID)))

                });
            }
            reader.Close();
            reader.Dispose();
            connection.Close();
            return opdtests;
        }




        // For update Both OPDBillingID and TestID will be required to uniquely identify the row
        /*
        public async Task<OPDTest?> Update(int OPDBillingID, int TestID, OPDTest opdtest)
        {
            connection.Open();
            command = connection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = $"Update {nameof(OPDTest)} " +
                $"Set {nameof(OPDTest.OPDBillingID)} = {opdtest.OPDBillingID}, " +
                $"{nameof(OPDTest.TestID)} = {opdtest.TestID}" +
                $"Where {nameof(OPDTest.OPDBillingID)} = {OPDBillingID} AND {nameof(OPDTest.TestID)}={TestID}";

            await command.ExecuteNonQueryAsync();
            connection.Close();
            return opdtest;
        }
        */


        /*
        // return list of OPDTest with OPDBillingID = OPDBilllingID
        // list because, there could be many row with same OPDBillingID
        public async Task<OPDTest?> Get(int OPDBillingID,int TestID)
        {
            OPDTest? opdtest = null;
            connection.Open();
            command = connection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = $"Select {nameof(OPDTest.OPDBillingID)},{nameof(OPDTest.TestID)}" +
                                  $" from {nameof(OPDTest)}"+
                                  $"Where {nameof(OPDTest.OPDBillingID)} = {OPDBillingID} AND {nameof(OPDTest.TestID)}={TestID}";

            SqlDataReader reader = await command.ExecuteReaderAsync();
            while (reader.Read())
            {
                opdtest = new OPDTest 
                {
                    OPDBillingID = Convert.ToInt32(reader.GetValue(nameof(OPDTest.OPDBillingID))),
                    TestID = Convert.ToInt32(reader.GetValue(nameof(OPDTest.TestID)))
                };
            }
            reader.Close();
            reader.Dispose();
            connection.Close();
            return opdtest;
        }
        */
    }
}
