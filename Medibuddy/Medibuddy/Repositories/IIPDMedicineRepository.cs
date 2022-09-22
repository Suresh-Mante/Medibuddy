using Medibuddy.Models;

namespace Medibuddy.Repositories
{
    public interface IIPDMedicineRepository
    {

        public Task<Response<IPDMedicine>> Create(IPDMedicine ipdmedicine);
        public Task<Response<IPDMedicine>> Get(int IPDPatientID);
        public Task<Response<IPDMedicine>> Get();
        public Task<Response<IPDMedicine>> Delete(int IPDPatientID);
    }
}
