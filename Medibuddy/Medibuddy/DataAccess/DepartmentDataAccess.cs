using Medibuddy.Models;
using Medibuddy.Repositories;
using System.Data;
using System.Data.SqlClient;

namespace Medibuddy.DataAccess
{
    public class DepartmentDataAccess : IDepartmentDataAccess
    {
        private readonly IConfiguration _configuration;
        private SqlConnection connection;
        private SqlCommand command;

        public DepartmentDataAccess(IConfiguration configuration)
        {
            _configuration = configuration;
            connection = new SqlConnection(_configuration.GetConnectionString("DbConnectionString"));
        }

        public async Task<Department> Create(Department department)
        {
            connection.Open();
            command = connection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = $"Insert into {nameof(Department)}({nameof(Department.DepName)}) " +                               
                                  $" Values('{department.DepName}')";

            await command.ExecuteNonQueryAsync();
            connection.Close();


            return department;
        }

        public async Task<bool> Delete(int DepID)
        {
            

            connection.Open();
            command = connection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = $"Delete from {nameof(Department)} where {nameof(Department.DepID)} = {DepID}";

            await command.ExecuteNonQueryAsync();
            connection.Close();


            return true;
        }

        public async Task<Department?> Get(int DepID)
        {
            Department? department = null;

            connection.Open();
            command = connection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = $"Select {nameof(Department.DepID)}, {nameof(Department.DepName)} " +               
                                  $" from {nameof(Department)} where {nameof(Department.DepID)} = {DepID}";

            SqlDataReader reader = await command.ExecuteReaderAsync();
            while (reader.Read())
            {
                department = new Department
                {
                    DepID = Convert.ToInt32(reader.GetValue(nameof(Department.DepID))),
                    DepName = reader.GetString(nameof(Department.DepName))
                    
                };
            }

            reader.Close();
            reader.Dispose();
            connection.Close();
            return department;
        }

        public async Task<IEnumerable<Department>> Get()
        {
            List<Department> departments = new List<Department>();

            connection.Open();
            command = connection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = $"Select {nameof(Department.DepID)}, {nameof(Department.DepName)}" +
                                  $" from {nameof(Department)}";

            SqlDataReader reader = await command.ExecuteReaderAsync();
            while (reader.Read())
            {
                departments.Add(new Department
                {
                    DepID = Convert.ToInt32(reader.GetValue(nameof(Department.DepID))),
                    DepName = reader.GetString(nameof(Department.DepName))
                    
                });
            }

            reader.Close();
            reader.Dispose();
            connection.Close();

            return departments;
        }

        public async Task<Department?> Update(int DepID, Department department)
        {
            connection.Open();
            command = connection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = $"Update {nameof(Department)} " +
                $"Set {nameof(Department.DepName)} = '{department.DepName}' " +
                $"Where {nameof(Department.DepID)} = {DepID}";

            await command.ExecuteNonQueryAsync();
            connection.Close();
            return department;
        }
    }
}


