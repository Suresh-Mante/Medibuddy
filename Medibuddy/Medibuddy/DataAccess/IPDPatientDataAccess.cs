using Medibuddy.Models;
using System.Data;
using System.Data.SqlClient;

namespace Medibuddy.DataAccess
{
    public class IPDPatientDataAccess : IIPDPatientDataAccess
    {
        private readonly IConfiguration _configuration;
        private SqlConnection connection;
        private SqlCommand command;

        public IPDPatientDataAccess(IConfiguration configuration)
        {
            _configuration = configuration;
            connection = new SqlConnection(_configuration.GetConnectionString("DbConnectionString"));
        }
        public async Task<IPDPatient> Create(IPDPatient IPDPatient)
        {
            connection.Open();
            command = connection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = $"Insert into {nameof(IPDPatient)}({nameof(IPDPatient.PID)}, {nameof(IPDPatient.DocId)},{nameof(IPDPatient.NurseID)}," +
                                  $"{nameof(IPDPatient.EntryDate)},{nameof(IPDPatient.ExitDate)},{nameof(IPDPatient.RoomID)},{nameof(IPDPatient.Discharged)})" +
                                  $" Values({IPDPatient.PID}, {IPDPatient.DocId}, {IPDPatient.NurseID},'{IPDPatient.EntryDate:MM-dd-yyyy}','{IPDPatient.ExitDate:MM-dd-yyyy}',{IPDPatient.RoomID}" +
                                  $", '{IPDPatient.Discharged}')";

            await command.ExecuteNonQueryAsync();
            connection.Close();
            return IPDPatient;
        }

        public async Task<bool> Delete(int id)
        {
            connection.Open();
            command = connection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = $"Delete from {nameof(IPDPatient)} where {nameof(IPDPatient.ID)} = {id}";
            await command.ExecuteNonQueryAsync();
            connection.Close();
            return true;
        }

        public async Task<IPDPatient?> Get(int id)
        {
            IPDPatient? IPDPatient = null;
            connection.Open();
            command = connection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = $"Select {nameof(IPDPatient.ID)}, {nameof(IPDPatient.PID)}, {nameof(IPDPatient.DocId)}, {nameof(IPDPatient.NurseID)}," +
                                  $"{nameof(IPDPatient.EntryDate)},{nameof(IPDPatient.ExitDate)},{nameof(IPDPatient.RoomID)},{nameof(IPDPatient.Discharged)}" +
                                  $" from {nameof(IPDPatient)} where {nameof(IPDPatient.ID)} = {id}";

            SqlDataReader reader = await command.ExecuteReaderAsync();
            while (reader.Read())
            {
                IPDPatient = new IPDPatient
                {
                    ID = Convert.ToInt32(reader.GetValue(nameof(IPDPatient.ID))),
                    PID = Convert.ToInt32(reader.GetValue(nameof(IPDPatient.PID))),
                    DocId = Convert.ToInt32(reader.GetValue(nameof(IPDPatient.DocId))),
                    NurseID = Convert.ToInt32(reader.GetValue(nameof(IPDPatient.NurseID))),
                    EntryDate = Convert.ToDateTime(reader.GetValue(nameof(IPDPatient.EntryDate))),
                    ExitDate = Convert.ToDateTime(reader.GetValue(nameof(IPDPatient.ExitDate))),
                    RoomID = Convert.ToInt32(reader.GetValue(nameof(IPDPatient.RoomID))),
                    Discharged = Convert.ToBoolean(reader.GetValue(nameof(IPDPatient.Discharged)))
                };
            }
            reader.Close();
            reader.Dispose();
            connection.Close();
            return IPDPatient;
        }

        public async Task<IEnumerable<IPDPatient>> Get()
        {
            List<IPDPatient> IPDPatients = new List<IPDPatient>();

            connection.Open();
            command = connection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = $"Select {nameof(IPDPatient.ID)}, {nameof(IPDPatient.PID)}, {nameof(IPDPatient.DocId)}, {nameof(IPDPatient.NurseID)}," +
                                  $"{nameof(IPDPatient.EntryDate)},{nameof(IPDPatient.ExitDate)},{nameof(IPDPatient.RoomID)},{nameof(IPDPatient.Discharged)}" +
                                  $" from {nameof(IPDPatient)}";

            SqlDataReader reader = await command.ExecuteReaderAsync();
            while (reader.Read())
            {
                IPDPatients.Add(new IPDPatient
                {
                    ID = Convert.ToInt32(reader.GetValue(nameof(IPDPatient.ID))),
                    PID = Convert.ToInt32(reader.GetValue(nameof(IPDPatient.PID))),
                    DocId = Convert.ToInt32(reader.GetValue(nameof(IPDPatient.DocId))),
                    NurseID = Convert.ToInt32(reader.GetValue(nameof(IPDPatient.NurseID))),
                    EntryDate = Convert.ToDateTime(reader.GetValue(nameof(IPDPatient.EntryDate))),
                    ExitDate = Convert.ToDateTime(reader.GetValue(nameof(IPDPatient.ExitDate))),
                    RoomID = Convert.ToInt32(reader.GetValue(nameof(IPDPatient.RoomID))),
                    Discharged = Convert.ToBoolean(reader.GetValue(nameof(IPDPatient.Discharged)))
                });
            }
            reader.Close();
            reader.Dispose();
            connection.Close();
            return IPDPatients;
        }

        public async Task<IPDPatient?> Update(int id, IPDPatient IPDPatient)
        {
            connection.Open();
            command = connection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = $"Update {nameof(IPDPatient)} " +
                $"Set {nameof(IPDPatient.PID)} = {IPDPatient.PID}, " +
                $"{nameof(IPDPatient.DocId)} = {IPDPatient.DocId}, " +
                $"{nameof(IPDPatient.NurseID)} = {IPDPatient.NurseID}," +
                $"{nameof(IPDPatient.EntryDate)} = '{IPDPatient.EntryDate:MM-dd-yyyy}', " +
                $"{nameof(IPDPatient.ExitDate)} = '{IPDPatient.ExitDate:MM-dd-yyyy}', " +
                $"{nameof(IPDPatient.Discharged)} = '{IPDPatient.Discharged}' " +
                $"Where {nameof(IPDPatient.ID)} = {id}";
            await command.ExecuteNonQueryAsync();
            connection.Close();
            return IPDPatient;
        }
    }
}
