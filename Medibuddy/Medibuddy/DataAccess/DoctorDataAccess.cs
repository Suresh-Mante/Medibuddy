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

        public async Task<Doctor> Create(Doctor doctor)
        {
            connection.Open();
            command = connection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = $"Insert into {nameof(Doctor)}({nameof(Doctor.Name)}, {nameof(Doctor.Type)}, {nameof(Doctor.Mobile)}, {nameof(Doctor.Email)}"+
                                      $"{nameof(Doctor.Gender)}, {nameof(Doctor.Fees)},{nameof(Doctor.Salary)})" +
                                      $" Values({doctor.Name}, {doctor.Type}, {doctor.Mobile}, {doctor.Email},{doctor.Gender},{doctor.Fees},{doctor.Salary})";
            await command.ExecuteNonQueryAsync();
            connection.Close();
            return doctor;

        }

        public async Task<bool> Delete(int ID)
        {
            connection.Open();
            command = connection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = $"Delete from {nameof(Doctor)} where {nameof(Doctor.ID)} = {ID}";
            await command.ExecuteNonQueryAsync();
            connection.Close();
            return true;
        }

        public async Task<Doctor?> Get(int ID)
        {
            Doctor? doctor = null;

            connection.Open();
            command = connection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = $"Select {nameof(Doctor.ID)}, {nameof(Doctor.Name)}, {nameof(Doctor.Type)} , {nameof(Doctor.Mobile)}" +
                                  $"{nameof(Doctor.Email)}, {nameof(Doctor.Gender)}, {nameof(Doctor.Fees)}, {nameof(Doctor.Salary)}" +
                                  $" from {nameof(Doctor)} where {nameof(Doctor.ID)} = {ID}";

            SqlDataReader reader = await command.ExecuteReaderAsync();
            while (reader.Read())
            {
                doctor = new Doctor
                {
                    ID = Convert.ToInt32(reader.GetValue(nameof(Doctor.ID))),
                    Name = Convert.ToString(reader.GetValue(nameof(Doctor.Name))),
                    Type = Convert.ToString(reader.GetValue(nameof(Doctor.Type))),
                    Mobile = Convert.ToString(reader.GetValue(nameof(Doctor.Mobile))),
                    Email = Convert.ToString(reader.GetValue(nameof(Doctor.Email))),
                    Gender = Convert.ToChar(reader.GetValue(nameof(Doctor.Gender))),
                    Fees = Convert.ToInt32(reader.GetValue(nameof(Doctor.Fees))),
                    Salary = Convert.ToInt32(reader.GetValue(nameof(Doctor.Salary)))
                };
            }
            reader.Close();
            reader.Dispose();
            connection.Close();
            return doctor;
        }

        public async Task<IEnumerable<Doctor>> Get()
        {
            List<Doctor> doctors = new List<Doctor>();

            connection.Open();
            command.CommandType = CommandType.Text;
            command.CommandText = $"Select {nameof(Doctor.ID)}, {nameof(Doctor.Name)}, {nameof(Doctor.Type)} , {nameof(Doctor.Mobile)}" +
                                  $"{nameof(Doctor.Email)}, {nameof(Doctor.Gender)}, {nameof(Doctor.Fees)}, {nameof(Doctor.Salary)}" +
                                  $" from {nameof(Doctor)}";

            SqlDataReader reader = await command.ExecuteReaderAsync();
            while (reader.Read())
            {
                doctors.Add(new Doctor
                {
                    ID = Convert.ToInt32(reader.GetValue(nameof(Doctor.ID))),
                    Name = Convert.ToString(reader.GetValue(nameof(Doctor.Name))),
                    Type = Convert.ToString(reader.GetValue(nameof(Doctor.Type))),
                    Mobile = Convert.ToString(reader.GetValue(nameof(Doctor.Mobile))),
                    Email = Convert.ToString(reader.GetValue(nameof(Doctor.Email))),
                    Gender = Convert.ToChar(reader.GetValue(nameof(Doctor.Gender))),
                    Fees = Convert.ToInt32(reader.GetValue(nameof(Doctor.Fees))),
                    Salary = Convert.ToInt32(reader.GetValue(nameof(Doctor.Salary)))

                });
            }
            reader.Close();
            reader.Dispose();
            connection.Close();
            return doctors;
        }

        public async Task<Doctor?> Update(int ID, Doctor doctor)
        {
            connection.Open();
            command.CommandType = CommandType.Text;
            command.CommandText = $"Update {nameof(Doctor)} " +
                $"Set {nameof(Doctor.ID)} = {doctor.ID}, " +
                $"{nameof(Doctor.Name)} = '{doctor.Name}', " +
                $"{nameof(Doctor.Type)} = {doctor.Type}, " +
                $"{nameof(Doctor.Mobile)} = {doctor.Mobile}, " +
                $"{nameof(Doctor.Email)} = {doctor.Email} " +
                $"{nameof(Doctor.Fees)}= {doctor.Fees}"+
                $"{nameof(Doctor.Salary)}={doctor.Salary}"+
                $"Where {nameof(Doctor.ID)} = {ID}";

            await command.ExecuteNonQueryAsync();
            connection.Close();

            return doctor;
        }
    }
}
