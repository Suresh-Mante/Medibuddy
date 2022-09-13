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
        public async Task<Response<Ward>> Create(WardDTO ward)
        {
            Ward newWard = new Ward()
            {
                DepId = ward.DepId,
                RoomGeneralCapacity = ward.RoomGeneralCapacity,
                RoomSharedCapacity = ward.RoomSharedCapacity,
                RoomSpecialCapacity = ward.RoomSpecialCapacity
            };
            return await _wardRepository.Create(newWard);
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
        public async Task<Response<Ward>> Get(int id)
        {
            return await _wardRepository.Get(id);
        }

        /// <summary>
        /// Get all wards
        /// </summary>
        /// <returns>
        /// Returns all wards
        /// </returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpGet]
        public async Task<Response<Ward>> Get()
        {
            return await _wardRepository.Get();
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
        public async Task<Response<Ward>> Update(int id, WardDTO ward)
        {
            return await _wardRepository.Update(id, new Ward()
            {
                DepId = ward.DepId,
                RoomGeneralCapacity = ward.RoomGeneralCapacity,
                RoomSharedCapacity = ward.RoomSharedCapacity,
                RoomSpecialCapacity = ward.RoomSpecialCapacity
            });
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
        public async Task<Response<Ward>> Delete(int id)
        {
            return await _wardRepository.Delete(id);
        }
    }
}
