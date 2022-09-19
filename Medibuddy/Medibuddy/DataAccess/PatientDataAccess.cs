using Medibuddy.Models;
using System.Data;
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
        }

        public async Task<Patient> Create(Patient patient)
        {
            connection.Open();
            command = connection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = $"Insert into {nameof(Patient)}({nameof(Patient.FirstName)}, {nameof(Patient.MidName)}, {nameof(Patient.LastName)}, {nameof(Patient.Mobile)},{nameof(Patient.Email)},{nameof(Patient.Address)},{nameof(Patient.Gender)},{nameof(Patient.DOB)})" +
                                  $" Values('{patient.FirstName}', '{patient.MidName}', '{patient.LastName}', '{patient.Mobile}', '{patient.Email}', '{patient.Address}', '{patient.Gender}', '{patient.DOB:MM-dd-yyyy}')";

            await command.ExecuteNonQueryAsync();
            connection.Close();

            return patient;
        }

        public async Task<bool> Delete(int PID)
        {
            connection.Open();
            command = connection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = $"Delete from {nameof(Patient)} where {nameof(Patient.PID)} = {PID}";

            await command.ExecuteNonQueryAsync();
            connection.Close();

            return true;
        }

        public async Task<Patient?> Get(int PID)
        {
            Patient? patient = null;

            connection.Open();
            command = connection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = $"Select {nameof(Patient.PID)}, {nameof(Patient.FirstName)}, {nameof(Patient.MidName)}, {nameof(Patient.LastName)}, {nameof(Patient.Mobile)},{nameof(Patient.Email)},{nameof(Patient.Address)},{nameof(Patient.Gender)},{nameof(Patient.DOB)}" +
                                  $" from {nameof(Patient)} where {nameof(Patient.PID)} = {PID}";

            SqlDataReader reader = await command.ExecuteReaderAsync();
            while (reader.Read())
            {
                patient = new Patient
                {
                    PID = Convert.ToInt32(reader.GetValue(nameof(Patient.PID))),
                    FirstName = reader.GetString(nameof(Patient.FirstName)),
                    MidName = reader.GetString(nameof(Patient.MidName)),
                    LastName = reader.GetString(nameof(Patient.LastName)),
                    Mobile = reader.GetString(nameof(Patient.Mobile)),
                    Email = reader.GetString(nameof(Patient.Email)),
                    Address = reader.GetString(nameof(Patient.Address)),
                    Gender = reader.GetString(nameof(Patient.Gender))[0],
                    DOB= reader.GetDateTime(nameof(Patient.DOB))


                };
            }

            reader.Close();
            reader.Dispose();
            connection.Close();

            return patient;
        }

        public async Task<IEnumerable<Patient>> Get()
        {
            List<Patient> patients = new List<Patient>();

            connection.Open();
            command = connection.CreateCommand();
            command.CommandType = CommandType.Text; 
            command.CommandText = $"Select {nameof(Patient.PID)}, {nameof(Patient.FirstName)}, {nameof(Patient.MidName)}, {nameof(Patient.LastName)}, {nameof(Patient.Mobile)}, {nameof(Patient.Email)}, {nameof(Patient.Address)}, {nameof(Patient.Gender)}, {nameof(Patient.DOB)}" +
                                  $" from {nameof(Patient)}";

            SqlDataReader reader = await command.ExecuteReaderAsync();
            while (reader.Read())
            {
                patients.Add(new Patient
                {
                    PID = Convert.ToInt32(reader.GetValue(nameof(Patient.PID))),
                    FirstName = reader.GetString(nameof(Patient.FirstName)),
                    MidName = reader.GetString(nameof(Patient.MidName)),
                    LastName = reader.GetString(nameof(Patient.LastName)),
                    Mobile = reader.GetString(nameof(Patient.Mobile)),
                    Email = reader.GetString(nameof(Patient.Email)),
                    Address = reader.GetString(nameof(Patient.Address)),
                    Gender = reader.GetString(nameof(Patient.Gender))[0],
                    DOB = reader.GetDateTime(nameof(Patient.DOB))

                });
            }

            reader.Close();
            reader.Dispose();
            connection.Close();

            return patients;
        }

        public async Task<Patient?> Update(int PID, Patient patient)
        {
            connection.Open();
            command = connection.CreateCommand();
            command.CommandType = CommandType.Text; command.CommandText = $"Update {nameof(Patient)} " +
                $"Set {nameof(Patient.FirstName)} = '{patient.FirstName}', " +
                $"{nameof(Patient.MidName)} = '{patient.MidName}', " +
                $"{nameof(Patient.LastName)} = '{patient.LastName}', " +
                $"{nameof(Patient.Mobile)} = '{patient.Mobile}', " +
                $"{nameof(Patient.Email)} = '{patient.Email}', " +
                $"{nameof(Patient.Address)} = '{patient.Address}', " +
                $"{nameof(Patient.Gender)} = '{patient.Gender}', " +
                $"{nameof(Patient.DOB)} = '{patient.DOB:MM-dd-yyyy}' " +
                $"Where {nameof(Patient.PID)} = {PID}";

            await command.ExecuteNonQueryAsync();
            connection.Close();

            return patient;
        }
    }
}
