using Medibuddy.DataAccess;
using Medibuddy.Models;
using Medibuddy.Utils;

namespace Medibuddy.Repositories
{
    public class OPDBillingRepository : IOPDBillingRepository
    {
        private readonly IOPDBillingDataAccess _OPDBillingDataAccess;

        public OPDBillingRepository(IOPDBillingDataAccess OPDBillingDataAccess)
        {
            _OPDBillingDataAccess = OPDBillingDataAccess;
        }

        public async Task<Response<OPDBilling>> Create(OPDBilling OPDBilling)
        {
            Response<OPDBilling> response = new Response<OPDBilling>();

            try
            {
                OPDBilling createdOPDBilling = await _OPDBillingDataAccess.Create(OPDBilling);
                response.StatusCode = 201;
                response.StatusMessage = HttpMessages.Created;
                response.Record = createdOPDBilling;
            }
            catch (Exception ex)
            {
                //Write logic to log this exceptions somewhere//

                response.StatusCode = 500;
                response.StatusMessage = HttpMessages.InternalServerError;
                //response.StatusMessage = ex.ToString();
            }

            return response;
        }

        public async Task<Response<OPDBilling>> Delete(int id)
        {
            Response<OPDBilling> response = new Response<OPDBilling>();

            try
            {
                OPDBilling? existingOPDBilling = await _OPDBillingDataAccess.Get(id);
                if (existingOPDBilling != null)
                {
                    await _OPDBillingDataAccess.Delete(id);
                    response.StatusCode = 200;
                    response.StatusMessage = HttpMessages.Deleted;
                    response.Record = existingOPDBilling;
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

        public async Task<Response<OPDBilling>> Get(int id)
        {
            Response<OPDBilling> response = new Response<OPDBilling>();

            try
            {
                OPDBilling? OPDBilling = await _OPDBillingDataAccess.Get(id);
                if (OPDBilling != null)
                {
                    response.StatusCode = 200;
                    response.StatusMessage = HttpMessages.Ok;
                    response.Record = OPDBilling;
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

        public async Task<Response<OPDBilling>> Get()
        {
            Response<OPDBilling> response = new Response<OPDBilling>();

            try
            {
                List<OPDBilling> OPDBillings = (await _OPDBillingDataAccess.Get()).ToList();
                response.StatusCode = 200;
                response.StatusMessage = HttpMessages.Ok;
                response.Records = OPDBillings;
            }
            catch (Exception ex)
            {
                //Write logic to log this exceptions somewhere//

                response.StatusCode = 500;
                response.StatusMessage = HttpMessages.InternalServerError;
            }

            return response;
        }

        public async Task<Response<OPDBilling>> Update(int id, OPDBilling OPDBilling)
        {
            Response<OPDBilling> response = new Response<OPDBilling>();

            try
            {
                OPDBilling? existingOPDBilling = await _OPDBillingDataAccess.Get(id);
                if (existingOPDBilling != null)
                {
                    OPDBilling? updatedOPDBilling = await _OPDBillingDataAccess.Update(id, OPDBilling);
                    response.StatusCode = 204;
                    response.StatusMessage = HttpMessages.Updated;
                    response.Record = updatedOPDBilling;
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
