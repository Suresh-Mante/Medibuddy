using System.Data.SqlClient;
using System.Data;
using Medibuddy.Models;

namespace Medibuddy.DataAccess
{
    public class OPDBillingDataAccess: IOPDBillingDataAccess
    {
        private readonly IConfiguration _configuration;
        private SqlConnection connection;
        private SqlCommand command;

        public OPDBillingDataAccess(IConfiguration configuration)
        {
            _configuration = configuration;
            connection = new SqlConnection(_configuration.GetConnectionString("DbConnectionString"));
        }

        public async Task<OPDBilling> Create(OPDBilling OPDBilling)
        {
            connection.Open();
            command = connection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = $"Insert into {nameof(OPDBilling)}({nameof(OPDBilling.PID)}, {nameof(OPDBilling.DocId)})" +
                                  $" Values({OPDBilling.PID}, {OPDBilling.DocId})";

            await command.ExecuteNonQueryAsync();
            connection.Close();

            return OPDBilling;
        }

        public async Task<bool> Delete(int id)
        {
            connection.Open();
            command = connection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = $"Delete from {nameof(OPDBilling)} where {nameof(OPDBilling.ID)} = {id}";

            await command.ExecuteNonQueryAsync();
            connection.Close();

            return true;
        }

        public async Task<OPDBilling?> Get(int id)
        {
            OPDBilling? OPDBilling = null;

            connection.Open();
            command = connection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = $"Select {nameof(OPDBilling.ID)}, {nameof(OPDBilling.PID)}, {nameof(OPDBilling.DocId)} " +
                                  $" from {nameof(OPDBilling)} where {nameof(OPDBilling.ID)} = {id}";

            SqlDataReader reader = await command.ExecuteReaderAsync();
            while (reader.Read())
            {
                OPDBilling = new OPDBilling
                {
                    ID = Convert.ToInt32(reader.GetValue(nameof(OPDBilling.ID))),
                    PID = Convert.ToInt32(reader.GetValue(nameof(OPDBilling.PID))),
                    DocId = Convert.ToInt32(reader.GetValue(nameof(OPDBilling.DocId)))
                };
            }
            reader.Close();
            reader.Dispose();
            connection.Close();

            return OPDBilling;
        }

        public async Task<IEnumerable<OPDBilling>> Get()
        {
            List<OPDBilling> OPDBillings = new List<OPDBilling>();

            connection.Open();
            command = connection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = $"Select {nameof(OPDBilling.ID)}, {nameof(OPDBilling.PID)}, {nameof(OPDBilling.DocId)} " +
                                  $" from {nameof(OPDBilling)}";

            SqlDataReader reader = await command.ExecuteReaderAsync();
            while (reader.Read())
            {
                OPDBillings.Add(new OPDBilling
                {
                    ID = Convert.ToInt32(reader.GetValue(nameof(OPDBilling.ID))),
                    PID = Convert.ToInt32(reader.GetValue(nameof(OPDBilling.PID))),
                    DocId = Convert.ToInt32(reader.GetValue(nameof(OPDBilling.DocId)))
                });
            }

            reader.Close();
            reader.Dispose();
            connection.Close();


            return OPDBillings;
        }

        public async Task<OPDBilling?> Update(int id, OPDBilling OPDBilling)
        {
            connection.Open();
            command = connection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = $"Update {nameof(OPDBilling)} " +
                $"Set {nameof(OPDBilling.PID)} = {OPDBilling.PID}, " +
                $"{nameof(OPDBilling.DocId)} = {OPDBilling.DocId} " +
                $"Where {nameof(OPDBilling.ID)} = {id}";

            await command.ExecuteNonQueryAsync();
            connection.Close();


            return OPDBilling;
        }
    }
}
