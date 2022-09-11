using Medibuddy.Models;

namespace Medibuddy.DataAccess
{

    public interface IDoctorDataAccess
    {
        public Task<Doctor> Create(Doctor doctor);
        public Task<Doctor?> Get(int ID);
        public Task<IEnumerable<Doctor>> Get();
        public Task<Doctor?> Update(int ID, Doctor doctor);
        public Task<bool> Delete(int ID);
    }
}
