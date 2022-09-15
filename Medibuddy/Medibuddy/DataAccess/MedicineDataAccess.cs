using Medibuddy.Models;
using System.Data;
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
            //command = connection.CreateCommand();
        }
        public async Task<Medicine> Create(Medicine medicine)
        {
            connection.Open();
            command = connection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = $"Insert into {nameof(Medicine)}({nameof(Medicine.Name)}, {nameof(Medicine.Price)})" +
                                  $" Values('{medicine.Name}', '{medicine.Price}')";

            await command.ExecuteNonQueryAsync();
            connection.Close();

            return medicine;
        }

        public async Task<bool> Delete(int Id)
        {
            connection.Open();
            command = connection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = $"Delete from {nameof(Medicine)} where {nameof(Medicine.Id)} = {Id}";

            await command.ExecuteNonQueryAsync();
            connection.Close();

            return true;
        }

        public async Task<Medicine?> Get(int Id)
        {
            Medicine? medicine = null;

            connection.Open();
            command = connection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = $"Select {nameof(Medicine.Id)}, {nameof(Medicine.Name)}, {nameof(Medicine.Price)}" +
                                  $" from {nameof(Medicine)} where {nameof(Medicine.Id)} = {Id}";

            SqlDataReader reader = await command.ExecuteReaderAsync();
            while (reader.Read())
            {
                medicine = new Medicine
                {
                    Id = Convert.ToInt32(reader.GetValue(nameof(Medicine.Id))),
                    Name = reader.GetString(nameof(Medicine.Name)),
                    Price = Convert.ToInt32(reader.GetValue(nameof(Medicine.Price)))
                };
            }

            reader.Close();
            reader.Dispose();
            connection.Close();

            return medicine;
        }

        public async Task<IEnumerable<Medicine>> Get()
        {
            List<Medicine> medicines = new List<Medicine>();
            connection.Open();
            command = connection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = $"Select {nameof(Medicine.Id)}, {nameof(Medicine.Name)}, {nameof(Medicine.Price)}" +
                                  $" from {nameof(Medicine)}";

            SqlDataReader reader = await command.ExecuteReaderAsync();
            while (reader.Read())
            {
                medicines.Add(new Medicine
                {
                    Id = Convert.ToInt32(reader.GetValue(nameof(Medicine.Id))),
                    Name = reader.GetString(nameof(Medicine.Name)),
                    Price = Convert.ToInt32(reader.GetValue(nameof(Medicine.Price)))
                });
            }

            reader.Close();
            reader.Dispose();
            connection.Close();
            return medicines;
        }

        public async Task<Medicine?> Update(int Id, Medicine medicine)
        {
            connection.Open();
            command = connection.CreateCommand();
            command.CommandType = CommandType.Text; command.CommandText = $"Update {nameof(Medicine)} " +
                $"Set {nameof(Medicine.Name)} = '{medicine.Name}', " +
                $"{nameof(Medicine.Price)} = {medicine.Price} " +
                $"Where {nameof(Medicine.Id)} = {Id}";

            await command.ExecuteNonQueryAsync();
            connection.Close();

            return medicine;
        }
    }
}
