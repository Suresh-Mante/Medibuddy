using Medibuddy.DataAccess;
using Medibuddy.Models;

namespace Medibuddy.Repositories
{
    public class WardRepository : IWardRepository
    {
        private readonly IWardDataAccess _wardDataAccess;

        public WardRepository(IWardDataAccess wardDataAccess)
        {
            _wardDataAccess = wardDataAccess;
        }
        public Ward Create(Ward ward)
        {
            //Write your implementation here
            throw new NotImplementedException();
        }

        public Ward Delete(int id)
        {
            //Write your implementation here
            throw new NotImplementedException();
        }

        public Ward Get(int id)
        {
            //Write your implementation here
            throw new NotImplementedException();
        }

        public IEnumerable<Ward> Get()
        {
            //Write your implementation here
            throw new NotImplementedException();
        }

        public Ward Update(int id, Ward ward)
        {
            //Write your implementation here
            throw new NotImplementedException();
        }
    }
}
