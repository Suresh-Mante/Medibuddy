using Medibuddy.DataAccess;
using Medibuddy.Models;

namespace Medibuddy.Repositories
{
    public class NurseRepository : INurseRepository
    {
        private readonly INurseDataAccess _nurseDataAccess;

        public NurseRepository(INurseDataAccess nurseDataAccess)
        {
            _nurseDataAccess = nurseDataAccess;
        }

        public Nurse Create(Nurse nurse)
        {
            throw new NotImplementedException();
        }

        public Nurse Delete(int ID)
        {
            throw new NotImplementedException();
        }

        public Nurse Get(int ID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Nurse> Get()
        {
            throw new NotImplementedException();
        }

        public Nurse Update(int ID, Nurse nurse)
        {
            throw new NotImplementedException();
        }
    }
}
