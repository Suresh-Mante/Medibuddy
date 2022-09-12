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
            connection.Open();
            command = connection.CreateCommand();
        }

        public async Task<Patient> Create(Patient patient)
        {
            command.CommandType = CommandType.Text;
            command.CommandText = $"Insert into {nameof(Patient)}({nameof(Patient.FirstName)}, {nameof(Patient.MidName)}, {nameof(Patient.LastName)}, {nameof(Patient.Mobile)},{nameof(Patient.Email)},{nameof(Patient.Address)},{nameof(Patient.Gender)},{nameof(Patient.DOB)})" +
                                  $" Values('{patient.FirstName}', '{patient.MidName}', '{patient.LastName}', '{patient.Mobile}', '{patient.Email}', '{patient.Address}', '{patient.Gender}', '{patient.DOB}')";

            await command.ExecuteNonQueryAsync();
            connection.Close();
            connection.Dispose();

            return patient;
        }

        public async Task<bool> Delete(int PID)
        {
            command.CommandType = CommandType.Text;
            command.CommandText = $"Delete from {nameof(Patient)} where {nameof(Patient.PID)} = {PID}";

            await command.ExecuteNonQueryAsync();
            connection.Close();
            connection.Dispose();

            return true;
        }

        public async Task<Patient?> Get(int PID)
        {
            Patient? patient = null;

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
                    Gender = reader.GetChar(nameof(Patient.Gender)),
                    DOB= reader.GetDateTime(nameof(Patient.DOB))


                };
            }

            connection.Close();
            connection.Dispose();

            return patient;
        }

        public async Task<IEnumerable<Patient>> Get()
        {
            List<Patient> patients = new List<Patient>();

            command.CommandType = CommandType.Text;
            command.CommandText = $"Select {nameof(Patient.PID)}, {nameof(Patient.FirstName)}, {nameof(Patient.MidName)}, {nameof(Patient.LastName)}, {nameof(Patient.Mobile)},{nameof(Patient.Email)},{nameof(Patient.Address)},{nameof(Patient.Gender)},{nameof(Patient.DOB)}" +
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
                    Gender = reader.GetChar(nameof(Patient.Gender)),
                    DOB = reader.GetDateTime(nameof(Patient.DOB))

                });
            }

            connection.Close();
            connection.Dispose();

            return patients;
        }

        public async Task<Patient?> Update(int PID, Patient patient)
        {
            command.CommandType = CommandType.Text;
            command.CommandText = $"Update {nameof(Patient)} " +
                $"Set {nameof(Patient.FirstName)} = '{patient.FirstName}', " +
                $"{nameof(Patient.MidName)} = '{patient.MidName}', " +
                $"{nameof(Patient.LastName)} = '{patient.LastName}', " +
                $"{nameof(Patient.Mobile)} = '{patient.Mobile}', " +
                $"{nameof(Patient.Email)} = '{patient.Email}', " +
                $"{nameof(Patient.Address)} = '{patient.Address}', " +
                $"{nameof(Patient.Gender)} = '{patient.Gender}', " +
                $"{nameof(Patient.DOB)} = '{patient.DOB}', " +
                $"Where {nameof(Patient.PID)} = {PID}";

            await command.ExecuteNonQueryAsync();
            connection.Close();
            connection.Dispose();

            return patient;
        }
    }
}
