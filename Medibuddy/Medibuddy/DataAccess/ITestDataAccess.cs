using Medibuddy.Models;

namespace Medibuddy.DataAccess
{
    public interface ITestDataAccess
    {
        public Test Create(Test test);
        public Test Get(int Id);
        public IEnumerable<Test> Get();
        public Test Update(int Id, Test test);
        public Test Delete(int Id);
    }
}