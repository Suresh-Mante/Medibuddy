using Medibuddy.Models;

namespace Medibuddy.Repositories
{
    public interface ITestRepository
    {
        public Task<Response<Test>> Create(Test test);
        public Task<Response<Test>> Get(int Id);
        public Task<Response<Test>> Get();
        public Task<Response<Test>> Update(int Id, Test test);
        public Task<Response<Test>> Delete(int Id);
    }
}
