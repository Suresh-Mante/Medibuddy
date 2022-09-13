using Medibuddy.Models;
using Medibuddy.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;

namespace Medibuddy.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        private readonly ITestRepository _testRepository;

        public TestController(ITestRepository testRepository)
        {
            _testRepository = testRepository;
        }

        /// <summary>
        /// Creates a new test
        /// </summary>
        /// <param name="test"></param>
        /// <returns>
        /// Created test
        /// </returns>
        [HttpPost]
        public async Task<Response<Test>> Create(TestDTO test)
        {
            Test newTest = new Test()
            {
                Name = test.Name,
                Price = test.Price
            };
            return await _testRepository.Create(newTest);
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get test with given Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>
        /// Returns a test with give Id if exists
        /// </returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpGet("{Id}")]
        public async Task<Response<Test>> Get(int Id)
        {
            return await _testRepository.Get(Id);
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get all Tests
        /// </summary>
        /// <returns>
        /// Returns all tests
        /// </returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpGet]
        public async Task<Response<Test>> Get()
        {
            return await _testRepository.Get();
            throw new NotImplementedException();

        }

        /// <summary>
        /// Updates test with given Id and data
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="test"></param>
        /// <returns>
        /// Updated test if exists
        /// </returns>
        [HttpPut]
        public async Task<Response<Test>> Update(int Id, TestDTO test)
        {
            return await _testRepository.Update(Id, new Test()
            {
                Name = test.Name,
                Price = test.Price
            });
            throw new NotImplementedException();
        }

        /// <summary>
        /// Deletes Test with given Id if exists
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="test"></param>
        /// <returns>
        /// Deleted test if exists
        /// </returns>
        [HttpDelete]
        public async Task<Response<Test>> Delete(int Id)
        {
            return await _testRepository.Delete(Id);
            throw new NotImplementedException();
        }
    }
}
