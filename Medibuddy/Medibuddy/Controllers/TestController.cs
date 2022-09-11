using Medibuddy.Models;
using Medibuddy.Repositories;
using Microsoft.AspNetCore.Mvc;

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
        public Task<IActionResult> Create(Test test)
        {
            //Write your implementation here
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get patient with given PID
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>
        /// Returns a test with give Id if exists
        /// </returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpGet("{Id}")]
        public Task<IActionResult> Get(int Id)
        {
            //Write your implementation here
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
        public Task<IActionResult> Get()
        {
            //Write your implementation here
            throw new NotImplementedException();
        }

        /// <summary>
        /// Updates test with given Id and data
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="test"></param>
        /// <returns>
        /// Updated patient if exists
        /// </returns>
        [HttpPut]
        public Task<IActionResult> Update(int Id, Test test)
        {
            //Write your implementation here
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
        public Task<IActionResult> Delete(int Id)
        {
            //Write your implementation here
            throw new NotImplementedException();
        }
    }
}
