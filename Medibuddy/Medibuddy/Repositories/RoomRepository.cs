using Medibuddy.DataAccess;
using Medibuddy.Models;
using Medibuddy.Utils;

namespace Medibuddy.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly IRoomDataAccess _roomDataAccess;

        public RoomRepository(IRoomDataAccess roomDataAccess)
        {
            _roomDataAccess = roomDataAccess;
        }

        public async Task<Response<Room>> Create(Room room)
        {
            Response<Room> response = new Response<Room>();

            try
            {
                Room createdRoom = await _roomDataAccess.Create(room);
                response.StatusCode = 201;
                response.StatusMessage = HttpMessages.Created;
                response.Record = createdRoom;
            }
            catch (Exception ex)
            {
                //Write logic to log this exceptions somewhere//

                response.StatusCode = 500;
                response.StatusMessage = HttpMessages.InternalServerError;
            }

            return response;
        }

        public async Task<Response<Room>> Delete(int id)
        {
            Response<Room> response = new Response<Room>();

            try
            {
                Room? existingRoom = await _roomDataAccess.Get(id);
                if (existingRoom != null)
                {
                    await _roomDataAccess.Delete(id);
                    response.StatusCode = 200;
                    response.StatusMessage = HttpMessages.Deleted;
                    response.Record = existingRoom;
                }
                else
                {
                    response.StatusCode = 404;
                    response.StatusMessage = HttpMessages.NotFound;
                }
            }
            catch (Exception ex)
            {
                //Write logic to log this exceptions somewhere//

                response.StatusCode = 500;
                response.StatusMessage = HttpMessages.InternalServerError;
            }

            return response;
        }

        public async Task<Response<Room>> Get(int id)
        {
            Response<Room> response = new Response<Room>();

            try
            {
                Room? room = await _roomDataAccess.Get(id);
                if(room != null)
                {
                    response.StatusCode = 200;
                    response.StatusMessage = HttpMessages.Ok;
                    response.Record = room;
                }
                else
                {
                    response.StatusCode = 404;
                    response.StatusMessage = HttpMessages.NotFound;
                }
            }
            catch (Exception ex)
            {
                //Write logic to log this exceptions somewhere//

                response.StatusCode = 500;
                response.StatusMessage = HttpMessages.InternalServerError;
            }

            return response;
        }

        public async Task<Response<Room>> Get()
        {
            Response<Room> response = new Response<Room>();

            try
            {
                List<Room> rooms = (await _roomDataAccess.Get()).ToList();
                response.StatusCode = 200;
                response.StatusMessage = HttpMessages.Ok;
                response.Records = rooms;
            }
            catch (Exception ex)
            {
                //Write logic to log this exceptions somewhere//

                response.StatusCode = 500;
                response.StatusMessage = HttpMessages.InternalServerError;
            }

            return response;
        }

        public async Task<Response<Room>> Update(int id, Room room)
        {
            Response<Room> response = new Response<Room>();

            try
            {
                Room? existingRoom = await _roomDataAccess.Get(id);
                if(existingRoom != null)
                {
                    Room? updatedRoom = await _roomDataAccess.Update(id, room);
                    response.StatusCode = 204;
                    response.StatusMessage = HttpMessages.Updated;
                    response.Record = updatedRoom;
                }
                else
                {
                    response.StatusCode = 404;
                    response.StatusMessage = HttpMessages.NotFound;
                }
            }
            catch (Exception ex)
            {
                //Write logic to log this exceptions somewhere//

                response.StatusCode = 500;
                response.StatusMessage = HttpMessages.InternalServerError;
            }

            return response;
        }
    }
}
