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
        /// Creates a new patient
        /// </summary>
        /// <param name="patient"></param>
        /// <returns>
        /// Created patient
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
        /// <param name="PID"></param>
        /// <returns>
        /// Returns a patient with given PID if exists
        /// </returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpGet("{Id}")]
        public Task<IActionResult> Get(int Id)
        {
            //Write your implementation here
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get all patients
        /// </summary>
        /// <returns>
        /// Returns all patients
        /// </returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpGet]
        public Task<IActionResult> Get()
        {
            //Write your implementation here
            throw new NotImplementedException();
        }

        /// <summary>
        /// Updates patient with given PID and data
        /// </summary>
        /// <param name="PID"></param>
        /// <param name="patient"></param>
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
        /// Deletes patient with given PID if exists
        /// </summary>
        /// <param name="PID"></param>
        /// <param name="patient"></param>
        /// <returns>
        /// Deleted patient if exists
        /// </returns>
        [HttpDelete]
        public Task<IActionResult> Delete(int Id)
        {
            //Write your implementation here
            throw new NotImplementedException();
        }
    }
}