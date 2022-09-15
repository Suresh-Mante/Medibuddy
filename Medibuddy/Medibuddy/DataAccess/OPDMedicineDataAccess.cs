using Medibuddy.Models;
using System.Data;
using System.Data.SqlClient;

namespace Medibuddy.DataAccess
{
    public class OPDMedicineDataAccess : IOPDMedicineDataAccess
    {

        private readonly IConfiguration _configuration;
        private SqlConnection connection;
        private SqlCommand command;

        public OPDMedicineDataAccess(IConfiguration configuration)
        {
            _configuration = configuration;
            connection = new SqlConnection(_configuration.GetConnectionString("DbConnectionString"));
            command = connection.CreateCommand();
        }

        public async Task<OPDMedicine> Create(OPDMedicine opdmedicine)
        {
            connection.Open();
            command = connection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = $"Insert into {nameof(OPDMedicine)}({nameof(OPDMedicine.OPDBillingID)},{nameof(OPDMedicine.MedicineID)})" +
                                      $" Values({opdmedicine.OPDBillingID},{opdmedicine.MedicineID})";
            await command.ExecuteNonQueryAsync();
            connection.Close();
            return opdmedicine;
        }

        public async Task<bool> Delete(int OPDBillingID)
        {
            connection.Open();
            command = connection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = $"Delete from {nameof(OPDMedicine)} where {nameof(OPDMedicine.OPDBillingID)} = {OPDBillingID}";
            await command.ExecuteNonQueryAsync();
            connection.Close();
            return true;
        }

        public async Task<IEnumerable<OPDMedicine>> Get()
        {
            List<OPDMedicine> opdmedicines = new List<OPDMedicine>();

            connection.Open();
            command = connection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = $"Select {nameof(OPDMedicine.OPDBillingID)},{nameof(OPDMedicine.MedicineID)}" +
                                  $" from {nameof(OPDMedicine)}";

            SqlDataReader reader = await command.ExecuteReaderAsync();
            while (reader.Read())
            {
                opdmedicines.Add(new OPDMedicine
                {
                    OPDBillingID = Convert.ToInt32(reader.GetValue(nameof(OPDMedicine.OPDBillingID))),
                    MedicineID = Convert.ToInt32(reader.GetValue(nameof(OPDMedicine.MedicineID)))

                });
            }
            reader.Close();
            reader.Dispose();
            connection.Close();
            return opdmedicines;
        }


        public async Task<IEnumerable<OPDMedicine>> Get(int OPDBillingID)
        {
            List<OPDMedicine> opdmedicines = new List<OPDMedicine>();

            connection.Open();
            command = connection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = $"Select {nameof(OPDMedicine.OPDBillingID)},{nameof(OPDMedicine.MedicineID)} from {nameof(OPDMedicine)} where {nameof(OPDMedicine.OPDBillingID)} = {OPDBillingID}";

            SqlDataReader reader = await command.ExecuteReaderAsync();
            while (reader.Read())
            {
                opdmedicines.Add(new OPDMedicine
                {
                    OPDBillingID = Convert.ToInt32(reader.GetValue(nameof(OPDMedicine.OPDBillingID))),
                    MedicineID = Convert.ToInt32(reader.GetValue(nameof(OPDMedicine.MedicineID)))

                });
            }
            reader.Close();
            reader.Dispose();
            connection.Close();
            return opdmedicines;
        }
    }
}
