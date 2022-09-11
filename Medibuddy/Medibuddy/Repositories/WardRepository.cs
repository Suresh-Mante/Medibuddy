using Medibuddy.DataAccess;
using Medibuddy.Models;
using Medibuddy.Utils;

namespace Medibuddy.Repositories
{
    public class WardRepository : IWardRepository
    {
        private readonly IWardDataAccess _wardDataAccess;

        public WardRepository(IWardDataAccess wardDataAccess)
        {
            _wardDataAccess = wardDataAccess;
        }

        public async Task<Response<Ward>> Create(Ward ward)
        {
            Response<Ward> response = new Response<Ward>();

            try
            {
                Ward createdWard = await _wardDataAccess.Create(ward);
                response.StatusCode = 201;
                response.StatusMessage = HttpMessages.Created;
                response.Record = createdWard;
            }
            catch (Exception ex)
            {
                //Write logic to log this exceptions somewhere//

                response.StatusCode = 500;
                response.StatusMessage = HttpMessages.InternalServerError;
            }

            return response;
        }

        public async Task<Response<Ward>> Delete(int id)
        {
            Response<Ward> response = new Response<Ward>();

            try
            {
                Ward? existingWard = await _wardDataAccess.Get(id);
                if (existingWard != null)
                {
                    await _wardDataAccess.Delete(id);
                    response.StatusCode = 200;
                    response.StatusMessage = HttpMessages.Created;
                    response.Record = existingWard;
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

        public async Task<Response<Ward>> Get(int id)
        {
            Response<Ward> response = new Response<Ward>();

            try
            {
                Ward? ward = await _wardDataAccess.Get(id);
                if(ward != null)
                {
                    response.StatusCode = 200;
                    response.StatusMessage = HttpMessages.Ok;
                    response.Record = ward;
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

        public async Task<Response<Ward>> Get()
        {
            Response<Ward> response = new Response<Ward>();

            try
            {
                List<Ward> wards = (await _wardDataAccess.Get()).ToList();
                response.StatusCode = 200;
                response.StatusMessage = HttpMessages.Ok;
                response.Records = wards;
            }
            catch (Exception ex)
            {
                //Write logic to log this exceptions somewhere//

                response.StatusCode = 500;
                response.StatusMessage = HttpMessages.InternalServerError;
            }

            return response;
        }

        public async Task<Response<Ward>> Update(int id, Ward ward)
        {
            Response<Ward> response = new Response<Ward>();

            try
            {
                Ward? existingWard = await _wardDataAccess.Get(id);
                if(existingWard != null)
                {
                    Ward? updatedWard = await _wardDataAccess.Update(id, ward);
                    response.StatusCode = 201;
                    response.StatusMessage = HttpMessages.Created;
                    response.Record = updatedWard;
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
