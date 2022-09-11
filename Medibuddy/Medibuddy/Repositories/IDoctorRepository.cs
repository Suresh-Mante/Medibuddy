using Medibuddy.Models;
namespace Medibuddy.Repositories
{
    public interface IDoctorRepository
    {
        public Doctor Create(Doctor doctor);
        public Doctor Get(int ID);
        public IEnumerable<Doctor> Get();
        public Doctor Update(int ID, Doctor doctor);
        public Doctor Delete(int ID);
    }
}
