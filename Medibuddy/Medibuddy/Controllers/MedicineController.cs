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
        public async Task<Response<Medicine>> Create(MedicineDTO medicine)
        {
            Medicine newMedicine = new Medicine()
            {
                Name = medicine.Name,
                Price = medicine.Price
            };
            return await _medicineRepository.Create(newMedicine);
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
        public async Task<Response<Medicine>> Get(int Id)
        {
            return await _medicineRepository.Get(Id);
        }

        /// <summary>
        /// Get all Medicines
        /// </summary>
        /// <returns>
        /// Returns all medicines
        /// </returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpGet]
        public async Task<Response<Medicine>> Get()
        {
            return await _medicineRepository.Get();
        }

        /// <summary>
        /// Updates medicine with given Id and data
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="medicine"></param>
        /// <returns>
        /// Updated medicine if exists
        /// </returns>
        [HttpPut]
        public async Task<Response<Medicine>> Update(int Id, MedicineDTO medicine)
        {
            return await _medicineRepository.Update(Id, new Medicine()
            {
                Name = medicine.Name,
                Price = medicine.Price
            });
        }

        /// <summary>
        /// Deletes Medicine with given Id if exists
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="medicine"></param>
        /// <returns>
        /// Deleted medicine if exists
        /// </returns>
        [HttpDelete]
        public async Task<Response<Medicine>> Delete(int Id)
        {
            return await _medicineRepository.Delete(Id);
        }
    }
}
