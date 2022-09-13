using Medibuddy.DataAccess;
using Medibuddy.Models;

namespace Medibuddy.Repositories
{
    public class TestRepository
    {
        private readonly ITestDataAccess _testDataAccess;

        public TestRepository(ITestDataAccess testDataAccess)
        {
            _testDataAccess = testDataAccess;
        }
        public Test Create(Test test)
        {
            //Write your implementation here
            throw new NotImplementedException();
        }

        public Test Delete(int Id)
        {
            //Write your implementation here
            throw new NotImplementedException();
        }

        public Test Get(int Id)
        {
            //Write your implementation here
            throw new NotImplementedException();
        }

        public IEnumerable<Test> Get()
        {
            //Write your implementation here
            throw new NotImplementedException();
        }

        public Test Update(int Id, Test test)
        {
            //Write your implementation here
            throw new NotImplementedException();
        }
    }
}
