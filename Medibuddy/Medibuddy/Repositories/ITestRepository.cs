using Medibuddy.Models;

namespace Medibuddy.Repositories
{
    public interface ITestRepository
    {
        public Test Create(Test test);
        public Test Get(int Id);
        public IEnumerable<Test> Get();
        public Test Update(int Id, Test test);
        public Test Delete(int Id);
    }
}
