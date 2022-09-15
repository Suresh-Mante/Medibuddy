using Medibuddy.Models;

namespace Medibuddy.DataAccess
{
    public class IOPDMedicineDataAccess
    {
        public Task<OPDMedicine> Create(OPDMedicine opdmedicine);
        public Task<IEnumerable<OPDMedicine>> Get(int OPDBillingID);
        public Task<IEnumerable<OPDMedicine>> Get();
        public Task<bool> Delete(int OPDBillingID);
    }
}
