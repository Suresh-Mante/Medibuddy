using Medibuddy.Models;

namespace Medibuddy.Repositories
{
    public interface IOPDMedicineRepository
    {

        public Task<Response<OPDMedicine>> Create(OPDMedicine opdmedicine);
        public Task<Response<OPDMedicine>> Get(int OPDBillingID);
        public Task<Response<OPDMedicine>> Get();
        public Task<Response<OPDMedicine>> Delete(int OPDBillingID);
    }
}
