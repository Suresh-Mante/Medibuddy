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
            connection.Open();
            command = connection.CreateCommand();
        }

        public async Task<Department> Create(Department department)
        {
            command.CommandType = CommandType.Text;
            command.CommandText = $"Insert into {nameof(Department)}({nameof(Department.DepName)}) " +                               
                                  $" Values('{department.DepName}')";

            await command.ExecuteNonQueryAsync();
            connection.Close();
            connection.Dispose();

            return department;
        }

        public async Task<bool> Delete(int DepID)
        {
            command.CommandType = CommandType.Text;
            command.CommandText = $"Delete from {nameof(Department)} where {nameof(Department.DepID)} = {DepID}";

            await command.ExecuteNonQueryAsync();
            connection.Close();
            connection.Dispose();

            return true;
        }

        public async Task<Department?> Get(int DepID)
        {
            Department? department = null;

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

            connection.Close();
            connection.Dispose();

            return department;
        }

        public async Task<IEnumerable<Department>> Get()
        {
            List<Department> departments = new List<Department>();

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

            connection.Close();
            connection.Dispose();

            return departments;
        }

        public async Task<Department?> Update(int DepID, Department department)
        {
            command.CommandType = CommandType.Text;
            command.CommandText = $"Update {nameof(Department)} " +
                $"Set {nameof(Department.DepName)} = '{department.DepName}', " +
                $"Where {nameof(Department.DepID)} = {DepID}";

            await command.ExecuteNonQueryAsync();
            connection.Close();
            connection.Dispose();

            return department;
        }
    }
}


