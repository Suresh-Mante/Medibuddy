using Medibuddy.Models;
namespace Medibuddy.DataAccess
{
    public interface INurseDataAccess
    {
        public Nurse Create(Nurse nurse);
        public Nurse Get(int ID);
        public IEnumerable<Nurse> Get();
        public Nurse Update(int ID, Nurse nurse);
        public Nurse Delete(int ID);
    }
}
