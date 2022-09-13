using Medibuddy.Models;

namespace Medibuddy.DataAccess
{
    public interface ITestDataAccess
    {
        public Task<Test> Create(Test test);
        public Task<Test?> Get(int Id);
        public Task<IEnumerable<Test>> Get();
        public Task<Test?> Update(int Id, Test test);
        public Task<bool> Delete(int Id);
    }
}