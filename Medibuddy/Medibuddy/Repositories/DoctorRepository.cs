using Medibuddy.DataAccess;
using Medibuddy.Models;

namespace Medibuddy.Repositories
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly IDoctorDataAccess _doctorDataAccess;

        public DoctorRepository(IDoctorDataAccess doctorDataAccess)
        {
            _doctorDataAccess = doctorDataAccess;
        }
        public Doctor Create(Doctor doctor)
        {
            throw new NotImplementedException();
        }

        public Doctor Delete(int ID)
        {
            throw new NotImplementedException();
        }

        public Doctor Get(int ID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Doctor> Get()
        {
            throw new NotImplementedException();
        }

        public Doctor Update(int ID, Doctor doctor)
        {
            throw new NotImplementedException();
        }
    }
}
