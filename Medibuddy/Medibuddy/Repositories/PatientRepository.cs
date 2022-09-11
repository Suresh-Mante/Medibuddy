using Medibuddy.DataAccess;
using Medibuddy.Models;

namespace Medibuddy.Repositories
{
    public class PatientRepository
    {
        private readonly IPatientDataAccess _patientDataAccess;

        public PatientRepository(IPatientDataAccess patientDataAccess)
        {
            _patientDataAccess = patientDataAccess;
        }
        public Patient Create(Patient patient)
        {
            //Write your implementation here
            throw new NotImplementedException();
        }

        public Patient Delete(int PID)
        {
            //Write your implementation here
            throw new NotImplementedException();
        }

        public Patient Get(int PID)
        {
            //Write your implementation here
            throw new NotImplementedException();
        }

        public IEnumerable<Patient> Get()
        {
            //Write your implementation here
            throw new NotImplementedException();
        }

        public Patient Update(int PID, Patient patient)
        {
            //Write your implementation here
            throw new NotImplementedException();
        }
    }
}
