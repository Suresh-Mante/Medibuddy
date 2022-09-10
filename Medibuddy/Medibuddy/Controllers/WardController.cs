using Medibuddy.Models;
using Medibuddy.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Medibuddy.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WardController : ControllerBase
    {
        private readonly IWardRepository _wardRepository;

        public WardController(IWardRepository wardRepository)
        {
            _wardRepository = wardRepository;
        }

        /// <summary>
        /// Creates a new ward
        /// </summary>
        /// <param name="ward"></param>
        /// <returns>
        /// Created ward
        /// </returns>
        [HttpPost]
        public Task<IActionResult> Create(Ward ward)
        {
            //Write your implementation here
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get ward with given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// Returns a ward with given id if exists
        /// </returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpGet("{id}")]
        public Task<IActionResult> Get(int id)
        {
            //Write your implementation here
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get all wards
        /// </summary>
        /// <returns>
        /// Returns all wards
        /// </returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpGet]
        public Task<IActionResult> Get()
        {
            //Write your implementation here
            throw new NotImplementedException();
        }

        /// <summary>
        /// Updates ward with given id and data
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ward"></param>
        /// <returns>
        /// Updated ward if exists
        /// </returns>
        [HttpPut]
        public Task<IActionResult> Update(int id, Ward ward)
        {
            //Write your implementation here
            throw new NotImplementedException();
        }

        /// <summary>
        /// Deletes ward with given id if exists
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ward"></param>
        /// <returns>
        /// Deleted ward if exists
        /// </returns>
        [HttpDelete]
        public Task<IActionResult> Delete(int id)
        {
            //Write your implementation here
            throw new NotImplementedException();
        }
    }
}
