using Medibuddy.DataAccess;
using Medibuddy.Models;

namespace Medibuddy.Repositories
{
    public class MedicineRepository
    {
        private readonly IMedicineDataAccess _medicineDataAccess;

        public MedicineRepository(IMedicineDataAccess medicineDataAccess)
        {
            _medicineDataAccess = medicineDataAccess;
        }
        public Medicine Create(Medicine medicine)
        {
            //Write your implementation here
            throw new NotImplementedException();
        }

        public Medicine Delete(int Id)
        {
            //Write your implementation here
            throw new NotImplementedException();
        }

        public Medicine Get(int Id)
        {
            //Write your implementation here
            throw new NotImplementedException();
        }

        public IEnumerable<Medicine> Get()
        {
            //Write your implementation here
            throw new NotImplementedException();
        }

        public Medicine Update(int Id, Medicine test)
        {
            //Write your implementation here
            throw new NotImplementedException();
        }
    }
}
