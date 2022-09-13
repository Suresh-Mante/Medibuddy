using Medibuddy.Models;
using Medibuddy.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Medibuddy.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MedicineController : ControllerBase
    {
        private readonly IMedicineRepository _medicineRepository;

        public MedicineController(IMedicineRepository medicineRepository)
        {
            _medicineRepository = medicineRepository;
        }

        /// <summary>
        /// Creates a new medicine
        /// </summary>
        /// <param name="medicine"></param>
        /// <returns>
        /// Created medicine
        /// </returns>
        [HttpPost]
        public Task<IActionResult> Create(Medicine medicine)
        {
            //Write your implementation here
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get medicine with given Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>
        /// Returns a medicine with give Id if exists
        /// </returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpGet("{Id}")]
        public Task<IActionResult> Get(int Id)
        {
            //Write your implementation here
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get all Medicine
        /// </summary>
        /// <returns>
        /// Returns all medicine
        /// </returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpGet]
        public Task<IActionResult> Get()
        {
            //Write your implementation here
            throw new NotImplementedException();
        }

        /// <summary>
        /// Updates medicine with given Id and data
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="medicine"></param>
        /// <returns>
        /// Updated Medicine if exists
        /// </returns>
        [HttpPut]
        public Task<IActionResult> Update(int Id, Medicine medicine)
        {
            //Write your implementation here
            throw new NotImplementedException();
        }

        /// <summary>
        /// Deletes Medicine with given Id if exists
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="medicine"></param>
        /// <returns>
        /// Deleted Medicine if exists
        /// </returns>
        [HttpDelete]
        public Task<IActionResult> Delete(int Id)
        {
            //Write your implementation here
            throw new NotImplementedException();
        }
    }
}
