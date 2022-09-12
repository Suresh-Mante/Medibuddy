using Medibuddy.Models;

namespace Medibuddy.DataAccess
{
    public interface IDoctorDataAccess
    {
        public Doctor Create(Doctor doctor);
        public Doctor Get(int ID);
        public IEnumerable<Doctor> Get();
        public Doctor Update(int ID, Doctor doctor);
        public Doctor Delete(int ID);
    }
}
