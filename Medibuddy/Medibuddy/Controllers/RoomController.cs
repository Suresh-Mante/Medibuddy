using Medibuddy.Models;
using Medibuddy.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Medibuddy.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomController : ControllerBase
    {
        private readonly IRoomRepository _roomRepository;

        public RoomController(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        /// <summary>
        /// Creates a new room
        /// </summary>
        /// <param name="room"></param>
        /// <returns>
        /// Created room
        /// </returns>
        [HttpPost]
        public async Task<Response<Room>> Create(RoomDTO room)
        {
            Room newRoom = new Room()
            {
                WardId = room.WardId,
                Type = room.Type,
                Rate = room.Rate,
                CurrentBedCapacity = room.CurrentBedCapacity,
                MaxBedCapacity = room.MaxBedCapacity
            };
            return await _roomRepository.Create(newRoom);
        }

        /// <summary>
        /// Get room with given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// Returns a room with given id if exists
        /// </returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpGet("{id}")]
        public async Task<Response<Room>> Get(int id)
        {
            return await _roomRepository.Get(id);
        }

        /// <summary>
        /// Get all rooms
        /// </summary>
        /// <returns>
        /// Returns all rooms
        /// </returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpGet]
        public async Task<Response<Room>> Get()
        {
            return await _roomRepository.Get();
        }

        /// <summary>
        /// Updates room with given id and data
        /// </summary>
        /// <param name="id"></param>
        /// <param name="room"></param>
        /// <returns>
        /// Updated room if exists
        /// </returns>
        [HttpPut]
        public async Task<Response<Room>> Update(int id, RoomDTO room)
        {
            return await _roomRepository.Update(id, new Room()
            {
                WardId = room.WardId,
                Type = room.Type,
                Rate = room.Rate,
                CurrentBedCapacity = room.CurrentBedCapacity,
                MaxBedCapacity = room.MaxBedCapacity
            });
        }

        /// <summary>
        /// Deletes room with given id if exists
        /// </summary>
        /// <param name="id"></param>
        /// <param name="room"></param>
        /// <returns>
        /// Deleted room if exists
        /// </returns>
        [HttpDelete]
        public async Task<Response<Room>> Delete(int id)
        {
            return await _roomRepository.Delete(id);
        }
    }
}
