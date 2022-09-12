using Medibuddy.Models;
using System.Data;
using System.Data.SqlClient;

namespace Medibuddy.DataAccess
{
    public class RoomDataAccess : IRoomDataAccess
    {
        private readonly IConfiguration _configuration;
        private SqlConnection connection;
        private SqlCommand command;

        public RoomDataAccess(IConfiguration configuration)
        {
            _configuration = configuration;
            connection = new SqlConnection(_configuration.GetConnectionString("DbConnectionString"));
            command = connection.CreateCommand();
        }

        public async Task<Room> Create(Room room)
        {
            connection.Open();
            command.CommandType = CommandType.Text;
            command.CommandText = $"Insert into {nameof(Room)}({nameof(Room.WardId)}, {nameof(Room.Type)}, " +
                                  $"{nameof(Room.Rate)}, {nameof(Room.CurrentBedCapacity)}, {nameof(Room.MaxBedCapacity)})" +
                                  $" Values({room.WardId}, '{room.Type}', {room.Rate}, {room.CurrentBedCapacity}," +
                                  $" {room.MaxBedCapacity})";

            await command.ExecuteNonQueryAsync();
            connection.Close();

            return room;
        }

        public async Task<bool> Delete(int id)
        {
            connection.Open();
            command.CommandType = CommandType.Text;
            command.CommandText = $"Delete from {nameof(Room)} where {nameof(Room.Id)} = {id}";

            await command.ExecuteNonQueryAsync();
            connection.Close();

            return true;
        }

        public async Task<Room?> Get(int id)
        {
            Room? room = null;

            connection.Open();
            command.CommandType = CommandType.Text;
            command.CommandText = $"Select {nameof(Room.Id)}, {nameof(Room.WardId)}, {nameof(Room.Type)}, " +
                                  $"{nameof(Room.Rate)}, {nameof(Room.CurrentBedCapacity)}, " +
                                  $"{nameof(Room.MaxBedCapacity)}" +
                                  $" from {nameof(Room)} where {nameof(Room.Id)} = {id}";

            SqlDataReader reader = await command.ExecuteReaderAsync();
            while (reader.Read())
            {
                room = new Room
                {
                    Id = Convert.ToInt32(reader.GetValue(nameof(Room.Id))),
                    WardId = Convert.ToInt32(reader.GetValue(nameof(Room.WardId))),
                    Type = Convert.ToString(reader.GetValue(nameof(Room.Type))),
                    Rate = Convert.ToInt32(reader.GetValue(nameof(Room.Rate))),
                    CurrentBedCapacity = Convert.ToInt16(reader.GetValue(nameof(Room.CurrentBedCapacity))),
                    MaxBedCapacity = Convert.ToInt16(reader.GetValue(nameof(Room.MaxBedCapacity)))
                };
            }

            reader.Close();
            reader.Dispose();
            connection.Close();

            return room;
        }

        public async Task<IEnumerable<Room>> Get()
        {
            List<Room> rooms = new List<Room>();

            connection.Open();
            command.CommandType = CommandType.Text;
            command.CommandText = $"Select {nameof(Room.Id)}, {nameof(Room.WardId)}, {nameof(Room.Type)}, " +
                                  $"{nameof(Room.Rate)}, {nameof(Room.CurrentBedCapacity)}, " +
                                  $"{nameof(Room.MaxBedCapacity)}" +
                                  $" from {nameof(Room)}";

            SqlDataReader reader = await command.ExecuteReaderAsync();
            while (reader.Read())
            {
                rooms.Add(new Room
                {
                    Id = Convert.ToInt32(reader.GetValue(nameof(Room.Id))),
                    WardId = Convert.ToInt32(reader.GetValue(nameof(Room.WardId))),
                    Type = Convert.ToString(reader.GetValue(nameof(Room.Type))),
                    Rate = Convert.ToInt32(reader.GetValue(nameof(Room.Rate))),
                    CurrentBedCapacity = Convert.ToInt16(reader.GetValue(nameof(Room.CurrentBedCapacity))),
                    MaxBedCapacity = Convert.ToInt16(reader.GetValue(nameof(Room.MaxBedCapacity)))
                });
            }

            reader.Close();
            reader.Dispose();
            connection.Close();

            return rooms;
        }

        public async Task<Room?> Update(int id, Room room)
        {
            connection.Open();
            command.CommandType = CommandType.Text;
            command.CommandText = $"Update {nameof(Room)} " +
                $"Set {nameof(Room.WardId)} = {room.WardId}, " +
                $"{nameof(Room.Type)} = '{room.Type}', " +
                $"{nameof(Room.Rate)} = {room.Rate}, " +
                $"{nameof(Room.CurrentBedCapacity)} = {room.CurrentBedCapacity}, " +
                $"{nameof(Room.MaxBedCapacity)} = {room.MaxBedCapacity} " +
                $"Where {nameof(Room.Id)} = {id}";

            await command.ExecuteNonQueryAsync();
            connection.Close();

            return room;
        }
    }
}
