using Medibuddy.Models;

namespace Medibuddy.DataAccess
{
    public interface IIPDMedicineDataAccess
    {
        public Task<IPDMedicine> Create(IPDMedicine ipdmedicine);
        public Task<IEnumerable<IPDMedicine>> Get(int IPDPatientID);
        public Task<IEnumerable<IPDMedicine>> Get();
        public Task<bool> Delete(int IPDPatientID);
    }
}
