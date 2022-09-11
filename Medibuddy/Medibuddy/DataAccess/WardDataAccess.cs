using Medibuddy.Models;
using System.Data;
using System.Data.SqlClient;

namespace Medibuddy.DataAccess
{
    public class WardDataAccess : IWardDataAccess
    {
        private readonly IConfiguration _configuration;
        private SqlConnection connection;
        private SqlCommand command;

        public WardDataAccess(IConfiguration configuration)
        {
            _configuration = configuration;
            connection = new SqlConnection(_configuration.GetConnectionString("DbConnectionString"));
        }

        public async Task<Ward> Create(Ward ward)
        {
            connection.Open();
            command = connection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = $"Insert into {nameof(Ward)}({nameof(Ward.DepId)}, {nameof(Ward.RoomSpecialCapacity)}, " +
                                  $"{nameof(Ward.RoomSharedCapacity)}, {nameof(Ward.RoomGeneralCapacity)})" +
                                  $" Values({ward.DepId}, {ward.RoomSpecialCapacity}, {ward.RoomSharedCapacity}, {ward.RoomGeneralCapacity})";

            await command.ExecuteNonQueryAsync();
            connection.Close();
            

            return ward;
        }

        public async Task<bool> Delete(int id)
        {
            connection.Open();
            command = connection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = $"Delete from {nameof(Ward)} where {nameof(Ward.Id)} = {id}";

            await command.ExecuteNonQueryAsync();
            connection.Close();
            

            return true;
        }

        public async Task<Ward?> Get(int id)
        {
            Ward? ward = null;

            connection.Open();
            command = connection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = $"Select {nameof(Ward.Id)}, {nameof(Ward.DepId)}, {nameof(Ward.RoomSpecialCapacity)}, " +
                                  $"{nameof(Ward.RoomSharedCapacity)}, {nameof(Ward.RoomGeneralCapacity)}" +
                                  $" from {nameof(Ward)} where {nameof(Ward.Id)} = {id}";

            SqlDataReader reader = await command.ExecuteReaderAsync();
            while (reader.Read())
            {
                ward = new Ward
                {
                    Id = Convert.ToInt32(reader.GetValue(nameof(Ward.Id))),
                    DepId = Convert.ToInt32(reader.GetValue(nameof(Ward.DepId))),
                    RoomGeneralCapacity = Convert.ToInt32(reader.GetValue(nameof(Ward.RoomGeneralCapacity))),
                    RoomSharedCapacity = Convert.ToInt32(reader.GetValue(nameof(Ward.RoomSharedCapacity))),
                    RoomSpecialCapacity = Convert.ToInt32(reader.GetValue(nameof(Ward.RoomSpecialCapacity)))
                };
            }
            reader.Close();
            reader.Dispose();
            connection.Close();

            return ward;
        }

        public async Task<IEnumerable<Ward>> Get()
        {
            List<Ward> wards = new List<Ward>();

            connection.Open();
            command = connection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = $"Select {nameof(Ward.Id)}, {nameof(Ward.DepId)}, {nameof(Ward.RoomSpecialCapacity)}, " +
                                  $"{nameof(Ward.RoomSharedCapacity)}, {nameof(Ward.RoomGeneralCapacity)}" +
                                  $" from {nameof(Ward)}";

            SqlDataReader reader = await command.ExecuteReaderAsync();
            while (reader.Read())
            {
                wards.Add(new Ward
                {
                    Id = Convert.ToInt32(reader.GetValue(nameof(Ward.Id))),
                    DepId = Convert.ToInt32(reader.GetValue(nameof(Ward.DepId))),
                    RoomGeneralCapacity = Convert.ToInt32(reader.GetValue(nameof(Ward.RoomGeneralCapacity))),
                    RoomSharedCapacity = Convert.ToInt32(reader.GetValue(nameof(Ward.RoomSharedCapacity))),
                    RoomSpecialCapacity = Convert.ToInt32(reader.GetValue(nameof(Ward.RoomSpecialCapacity)))
                });
            }

            reader.Close();
            reader.Dispose();
            connection.Close();
            

            return wards;
        }

        public async Task<Ward?> Update(int id, Ward ward)
        {
            connection.Open();
            command = connection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = $"Update {nameof(Ward)} " +
                $"Set {nameof(Ward.DepId)} = {ward.DepId}, " +
                $"{nameof(Ward.RoomSharedCapacity)} = {ward.RoomSharedCapacity}, " +
                $"{nameof(Ward.RoomSpecialCapacity)} = {ward.RoomSpecialCapacity}, " +
                $"{nameof(Ward.RoomGeneralCapacity)} = {ward.RoomGeneralCapacity} " +
                $"Where {nameof(Ward.Id)} = {id}";

            await command.ExecuteNonQueryAsync();
            connection.Close();
            

            return ward;
        }
    }
}
