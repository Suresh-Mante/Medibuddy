using Medibuddy.Models;
using System.Data;
using System.Data.SqlClient;

namespace Medibuddy.DataAccess
{
    public class OPDPatientDataAccess : IOPDPatientDataAccess
    {
        private readonly IConfiguration _configuration;
        private SqlConnection connection;
        private SqlCommand command;

        public OPDPatientDataAccess(IConfiguration configuration)
        {
            _configuration = configuration;
            connection = new SqlConnection(_configuration.GetConnectionString("DbConnectionString"));
        }

        public async Task<OPDPatient> Create(OPDPatient OPDPatient)
        {
            connection.Open();
            command = connection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = $"Insert into {nameof(OPDPatient)}({nameof(OPDPatient.PID)}, {nameof(OPDPatient.DocId)}, " +
                                  $"{nameof(OPDPatient.VisitDate)}, {nameof(OPDPatient.OPDBillingID)})" +
                                  $" Values({OPDPatient.PID}, {OPDPatient.DocId}, '{OPDPatient.VisitDate:MM-dd-yyyy}', {OPDPatient.OPDBillingID})";

            await command.ExecuteNonQueryAsync();
            connection.Close();

            return OPDPatient;
        }

        public async Task<bool> Delete(int id)
        {
            connection.Open();
            command = connection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = $"Delete from {nameof(OPDPatient)} where {nameof(OPDPatient.ID)} = {id}";

            await command.ExecuteNonQueryAsync();
            connection.Close();

            return true;
        }

        public async Task<OPDPatient?> Get(int id)
        {
            OPDPatient? OPDPatient = null;

            connection.Open();
            command = connection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = $"Select {nameof(OPDPatient.ID)}, {nameof(OPDPatient.PID)}, {nameof(OPDPatient.DocId)}, " +
                                  $"{nameof(OPDPatient.VisitDate)}, {nameof(OPDPatient.OPDBillingID)}" +
                                  $" from {nameof(OPDPatient)} where {nameof(OPDPatient.ID)} = {id}";

            SqlDataReader reader = await command.ExecuteReaderAsync();
            while (reader.Read())
            {
                OPDPatient = new OPDPatient
                {
                    ID = Convert.ToInt32(reader.GetValue(nameof(OPDPatient.ID))),
                    PID = Convert.ToInt32(reader.GetValue(nameof(OPDPatient.PID))),
                    DocId = Convert.ToInt32(reader.GetValue(nameof(OPDPatient.DocId))),
                    VisitDate = Convert.ToDateTime(reader.GetValue(nameof(OPDPatient.VisitDate))),
                    OPDBillingID = Convert.ToInt32(reader.GetValue(nameof(OPDPatient.OPDBillingID)))
                };
            }
            reader.Close();
            reader.Dispose();
            connection.Close();

            return OPDPatient;
        }

        public async Task<IEnumerable<OPDPatient>> Get()
        {
            List<OPDPatient> OPDPatients = new List<OPDPatient>();

            connection.Open();
            command = connection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = $"Select {nameof(OPDPatient.ID)}, {nameof(OPDPatient.PID)}, {nameof(OPDPatient.DocId)}, " +
                                  $"{nameof(OPDPatient.VisitDate)}, {nameof(OPDPatient.OPDBillingID)}" +
                                  $" from {nameof(OPDPatient)}";

            SqlDataReader reader = await command.ExecuteReaderAsync();
            while (reader.Read())
            {
                OPDPatients.Add(new OPDPatient
                {
                    ID = Convert.ToInt32(reader.GetValue(nameof(OPDPatient.ID))),
                    PID = Convert.ToInt32(reader.GetValue(nameof(OPDPatient.PID))),
                    DocId = Convert.ToInt32(reader.GetValue(nameof(OPDPatient.DocId))),
                    VisitDate = Convert.ToDateTime(reader.GetValue(nameof(OPDPatient.VisitDate))),
                    OPDBillingID = Convert.ToInt32(reader.GetValue(nameof(OPDPatient.OPDBillingID)))
                });
            }

            reader.Close();
            reader.Dispose();
            connection.Close();


            return OPDPatients;
        }

        public async Task<OPDPatient?> Update(int id, OPDPatient OPDPatient)
        {
            connection.Open();
            command = connection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = $"Update {nameof(OPDPatient)} " +
                $"Set {nameof(OPDPatient.PID)} = {OPDPatient.PID}, " +
                $"{nameof(OPDPatient.DocId)} = {OPDPatient.DocId}, " +
                $"{nameof(OPDPatient.VisitDate)} = '{OPDPatient.VisitDate:MM-dd-yyyy}', " +
                $"{nameof(OPDPatient.OPDBillingID)} = {OPDPatient.OPDBillingID} " +
                $"Where {nameof(OPDPatient.ID)} = {id}";

            await command.ExecuteNonQueryAsync();
            connection.Close();


            return OPDPatient;
        }
    }
}
