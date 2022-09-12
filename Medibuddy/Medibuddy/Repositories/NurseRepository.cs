using Medibuddy.DataAccess;
using Medibuddy.Models;
using Medibuddy.Utils;

namespace Medibuddy.Repositories
{
    public class NurseRepository : INurseRepository
    {
        private readonly INurseDataAccess _nurseDataAccess;

        public NurseRepository(INurseDataAccess nurseDataAccess)
        {
            _nurseDataAccess = nurseDataAccess;
        }

        public async Task<Response<Nurse>> Create(Nurse nurse)
        {
            Response<Nurse> response = new Response<Nurse>();

            try
            {
                Nurse createdNurse = await _nurseDataAccess.Create(nurse);
                response.StatusCode = 201;
                response.StatusMessage = HttpMessages.Created;
                response.Record = createdNurse;
            }
            catch (Exception ex)
            {
                //Write logic to log this exceptions somewhere//

                response.StatusCode = 500;
                response.StatusMessage = HttpMessages.InternalServerError;
            }
            return response;
        }

        public async Task<Response<Nurse>> Delete(int ID)
        {

            Response<Nurse> response = new Response<Nurse>();

            try
            {
                Nurse? existingNurse = await _nurseDataAccess.Get(ID);
                if (existingNurse != null)
                {
                    await _nurseDataAccess.Delete(ID);
                    response.StatusCode = 200;
                    response.StatusMessage = HttpMessages.Deleted;
                    response.Record = existingNurse;
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

        public async Task<Response<Nurse>> Get(int ID)
        {
            Response<Nurse> response = new Response<Nurse>();

            try
            {
                Nurse? nurse = await _nurseDataAccess.Get(ID);
                if (nurse != null)
                {
                    response.StatusCode = 200;
                    response.StatusMessage = HttpMessages.Ok;
                    response.Record = nurse;
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

        public async Task<Response<Nurse>> Get()
        {
            Response<Nurse> response = new Response<Nurse>();

            try
            {
                List<Nurse> nurses = (await _nurseDataAccess.Get()).ToList();
                response.StatusCode = 200;
                response.StatusMessage = HttpMessages.Ok;
                response.Records = nurses;
            }
            catch (Exception ex)
            {
                //Write logic to log this exceptions somewhere//

                response.StatusCode = 500;
                response.StatusMessage = HttpMessages.InternalServerError;
            }

            return response;
        }

        public async Task<Response<Nurse>> Update(int ID, Nurse nurse)
        {
            Response<Nurse> response = new Response<Nurse>();

            try
            {
                Nurse? existingNurse = await _nurseDataAccess.Get(ID);
                if (existingNurse != null)
                {
                    Nurse? updatedNurse = await _nurseDataAccess.Update(ID, nurse);
                    response.StatusCode = 204;
                    response.StatusMessage = HttpMessages.Updated;
                    response.Record = updatedNurse;
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
