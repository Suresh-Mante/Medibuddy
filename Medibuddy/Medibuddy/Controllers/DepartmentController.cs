using Medibuddy.Models;
using Medibuddy.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Medibuddy.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        /// <summary>
        /// Creates a new department
        /// </summary>
        /// <param name="department"></param>
        /// <returns>
        /// Created department
        /// </returns>
        [HttpPost]
        public Task<IActionResult> Create(Department department)
        {
            //Write your implementation here
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get department with given DepID
        /// </summary>
        /// <param name="DepID"></param>
        /// <returns>
        /// Returns a department with given DepID if exists
        /// </returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpGet("{DepID}")]
        public Task<IActionResult> Get(int DepID)
        {
            //Write your implementation here
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get all departments
        /// </summary>
        /// <returns>
        /// Returns all departments
        /// </returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpGet]
        public Task<IActionResult> Get()
        {
            //Write your implementation here
            throw new NotImplementedException();
        }

        /// <summary>
        /// Updates department with given DepID and data
        /// </summary>
        /// <param name="DepID"></param>
        /// <param name="department"></param>
        /// <returns>
        /// Updated department if exists
        /// </returns>
        [HttpPut]
        public Task<IActionResult> Update(int DepID, Department department)
        {
            //Write your implementation here
            throw new NotImplementedException();
        }

        /// <summary>
        /// Deletes department with given DepID if exists
        /// </summary>
        /// <param name="DepID"></param>
        /// <param name="department"></param>
        /// <returns>
        /// Deleted department if exists
        /// </returns>
        [HttpDelete]
        public Task<IActionResult> Delete(int DepID)
        {
            //Write your implementation here
            throw new NotImplementedException();
        }
    }
}

