using Medibuddy.Models;

namespace Medibuddy.DataAccess
{
    public interface IWardDataAccess
    {
        public Ward Create(Ward ward);
        public Ward Get(int id);
        public IEnumerable<Ward> Get();
        public Ward Update(int id, Ward ward);
        public Ward Delete(int id);
    }
}
