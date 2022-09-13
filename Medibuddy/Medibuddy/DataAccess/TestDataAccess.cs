using Medibuddy.Models;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace Medibuddy.DataAccess
{
    public class TestDataAccess : ITestDataAccess
    {
        private readonly IConfiguration _configuration;
        private SqlConnection connection;
        private SqlCommand command;

        public TestDataAccess(IConfiguration configuration)
        {
            _configuration = configuration;
            connection = new SqlConnection(_configuration.GetConnectionString("DbConnectionString"));
            //command = connection.CreateCommand();
        }
        public async Task<Test> Create(Test test)
        {
            connection.Open();
            command = connection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = $"Insert into {nameof(Test)}({nameof(Test.Name)}, {nameof(Test.Price)})" +
                                  $" Values('{test.Name}', '{test.Price}')";

            await command.ExecuteNonQueryAsync();
            connection.Close();

            return test ;
        }

        public async Task<bool> Delete(int Id)
        {
            connection.Open();
            command = connection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = $"Delete from {nameof(Test)} where {nameof(Test.Id)} = {Id}";

            await command.ExecuteNonQueryAsync();
            connection.Close();

            return true;
        }

        public async Task<Test?> Get(int Id)
        {
            Test? test = null;

            connection.Open();
            command = connection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = $"Select {nameof(Test.Id)}, {nameof(Test.Name)}, {nameof(Test.Price)}" +
                                  $" from {nameof(Test)} where {nameof(Test.Id)} = {Id}";

            SqlDataReader reader = await command.ExecuteReaderAsync();
            while (reader.Read())
            {
                test = new Test
                {
                    Id = Convert.ToInt32(reader.GetValue(nameof(Test.Id))),
                    Name = reader.GetString(nameof(Test.Name)),
                    Price = Convert.ToInt32(reader.GetValue(nameof(Test.Price)))
                };
            }

            reader.Close();
            reader.Dispose();
            connection.Close();

            return test;
        }

        public async Task<IEnumerable<Test>> Get()
        {
            List<Test> tests = new List<Test>();
            connection.Open();
            command = connection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = $"Select {nameof(Test.Id)}, {nameof(Test.Name)}, {nameof(Test.Price)}" +
                                  $" from {nameof(Test)}";

            SqlDataReader reader = await command.ExecuteReaderAsync();
            while (reader.Read())
            {
                tests.Add(new Test
                {
                    Id = Convert.ToInt32(reader.GetValue(nameof(Test.Id))),
                    Name = reader.GetString(nameof(Test.Name)),
                    Price = Convert.ToInt32(reader.GetValue(nameof(Test.Price)))
                });
            }

            reader.Close();
            reader.Dispose();
            connection.Close();
            return tests;
        }

        public async Task<Test?> Update(int Id, Test test)
        {
            connection.Open();
            command = connection.CreateCommand();
            command.CommandType = CommandType.Text; command.CommandText = $"Update {nameof(Test)} " +
                $"Set {nameof(Test.Name)} = '{test.Name}', " +
                $"{nameof(Test.Price)} = {test.Price}, " +
                $"Where {nameof(Test.Id)} = {Id}";

            await command.ExecuteNonQueryAsync();
            connection.Close();

            return test;
        }
    }
}
