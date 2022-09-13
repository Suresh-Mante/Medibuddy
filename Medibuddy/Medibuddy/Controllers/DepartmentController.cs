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
        public async Task<Response<Department>> Create(DepartmentDTO department)
        {
            Department newDepartment = new Department()
            {
                DepName = department.DepName
            };
            return await _departmentRepository.Create(newDepartment);
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
        public async Task<Response<Department>> Get(int DepID)
        {
            return await _departmentRepository.Get(DepID);
        }

        /// <summary>
        /// Get all departments
        /// </summary>
        /// <returns>
        /// Returns all departments
        /// </returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpGet]
        public async Task<Response<Department>> Get()
        {
            return await _departmentRepository.Get();
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
        public async Task<Response<Department>> Update(int DepID, DepartmentDTO department)
        {
            return await _departmentRepository.Update(DepID, new Department()
            {
                DepName= department.DepName
            });
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
        public async Task<Response<Department>> Delete(int DepID)
        {
            return await _departmentRepository.Delete(DepID);
        }
    }
}

