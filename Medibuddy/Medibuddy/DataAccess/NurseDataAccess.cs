using Medibuddy.Models;
using System.Data;
using System.Data.SqlClient;

namespace Medibuddy.DataAccess
{
    public class NurseDataAccess : INurseDataAccess
    {

        private readonly IConfiguration _configuration;
        private SqlConnection connection;
        private SqlCommand command;

        public NurseDataAccess(IConfiguration configuration)
        {
            _configuration = configuration;
            connection = new SqlConnection(_configuration.GetConnectionString("DbConnectionString"));
            command = connection.CreateCommand();
        }

        public async Task<Nurse> Create(Nurse nurse)
        {

            connection.Open();
            command = connection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = $"Insert into {nameof(Nurse)}({nameof(Nurse.Name)},{nameof(Nurse.Mobile)}, {nameof(Nurse.Email)}" +
                                      $",{nameof(Nurse.Gender)},{nameof(Nurse.Salary)})" +
                                      $" Values('{nurse.Name}', '{nurse.Mobile}', '{nurse.Email}','{nurse.Gender}',{nurse.Salary})";
            await command.ExecuteNonQueryAsync();
            connection.Close();
            return nurse;
        }

        public async Task<bool> Delete(int ID)
        {
            connection.Open();
            command = connection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = $"Delete from {nameof(Nurse)} where {nameof(Nurse.ID)} = {ID}";
            await command.ExecuteNonQueryAsync();
            connection.Close();
            return true;
        }

        public async Task<Nurse> Get(int ID)
        {
            Nurse? nurse = null;

            connection.Open();
            command = connection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = $"Select {nameof(Nurse.ID)}, {nameof(Nurse.Name)},{nameof(Nurse.Mobile)}" +
                                  $",{nameof(Nurse.Email)}, {nameof(Nurse.Gender)},{nameof(Doctor.Salary)}" +
                                  $" from {nameof(Nurse)} where {nameof(Nurse.ID)} = {ID}";

            SqlDataReader reader = await command.ExecuteReaderAsync();
            while (reader.Read())
            {
                nurse = new Nurse
                {
                    ID = Convert.ToInt32(reader.GetValue(nameof(Nurse.ID))),
                    Name = Convert.ToString(reader.GetValue(nameof(Nurse.Name))),
                    Mobile = Convert.ToString(reader.GetValue(nameof(Nurse.Mobile))),
                    Email = Convert.ToString(reader.GetValue(nameof(Nurse.Email))),
                    Gender = Convert.ToChar(reader.GetValue(nameof(Nurse.Gender))),
                    Salary = Convert.ToInt32(reader.GetValue(nameof(Nurse.Salary)))
                };
            }
            reader.Close();
            reader.Dispose();
            connection.Close();
            return nurse;
        }

        public async Task<IEnumerable<Nurse>> Get()
        {
            List<Nurse> nurses = new List<Nurse>();

            connection.Open();
            command.CommandType = CommandType.Text;
            command.CommandText = $"Select {nameof(Nurse.ID)}, {nameof(Nurse.Name)},{nameof(Nurse.Mobile)}" +
                                  $",{nameof(Nurse.Email)}, {nameof(Nurse.Gender)},{nameof(Doctor.Salary)}" +
                                  $" from {nameof(Nurse)}";

            SqlDataReader reader = await command.ExecuteReaderAsync();
            while (reader.Read())
            {
                nurses.Add(new Nurse
                {
                    ID = Convert.ToInt32(reader.GetValue(nameof(Nurse.ID))),
                    Name = Convert.ToString(reader.GetValue(nameof(Nurse.Name))),
                    Mobile = Convert.ToString(reader.GetValue(nameof(Nurse.Mobile))),
                    Email = Convert.ToString(reader.GetValue(nameof(Nurse.Email))),
                    Gender = Convert.ToChar(reader.GetValue(nameof(Nurse.Gender))),
                    Salary = Convert.ToInt32(reader.GetValue(nameof(Nurse.Salary)))
                });
            }
            reader.Close();
            reader.Dispose();
            connection.Close();
            return nurses;
        }

        public async Task<Nurse> Update(int ID, Nurse nurse)
        {
            connection.Open();
            command.CommandType = CommandType.Text;
            command.CommandText = $"Update {nameof(Nurse)} " +
                $"Set {nameof(Nurse.Name)} = '{nurse.Name}', " +
                $"{nameof(Nurse.Mobile)} = '{nurse.Mobile}', " +
                $"{nameof(Nurse.Email)} = '{nurse.Email}', " +
                $"{nameof(Nurse.Gender)} = '{nurse.Gender}', " +
                $"{nameof(Nurse.Salary)}={nurse.Salary}" +
                $"Where {nameof(Nurse.ID)} = {ID}";

            await command.ExecuteNonQueryAsync();
            connection.Close();
            return nurse;
        }
    }
}
