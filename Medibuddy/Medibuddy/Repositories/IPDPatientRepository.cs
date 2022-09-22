using Medibuddy.Models;
using Medibuddy.Utils;
using Medibuddy.DataAccess;

namespace Medibuddy.Repositories
{
    public class IPDPatientRepository : IIPDPatientRepository
    {
        private readonly IIPDPatientDataAccess _IPDPatientDataAccess;

        public IPDPatientRepository(IIPDPatientDataAccess IPDPatientDataAccess)
        {
            _IPDPatientDataAccess = IPDPatientDataAccess;
        }

        public async Task<Response<IPDPatient>> Create(IPDPatient IPDPatient)
        {
            Response<IPDPatient> response = new Response<IPDPatient>();

            try
            {
                IPDPatient createdIPDPatient = await _IPDPatientDataAccess.Create(IPDPatient);
                response.StatusCode = 201;
                response.StatusMessage = HttpMessages.Created;
                response.Record = createdIPDPatient;
            }
            catch (Exception ex)
            {
                //Write logic to log this exceptions somewhere//

                response.StatusCode = 500;
                //response.StatusMessage = HttpMessages.InternalServerError;
                response.StatusMessage = ex.Message;
            }

            return response;
        }

        public async Task<Response<IPDPatient>> Delete(int id)
        {
            Response<IPDPatient> response = new Response<IPDPatient>();

            try
            {
                IPDPatient? existingIPDPatient = await _IPDPatientDataAccess.Get(id);
                if (existingIPDPatient != null)
                {
                    await _IPDPatientDataAccess.Delete(id);
                    response.StatusCode = 200;
                    response.StatusMessage = HttpMessages.Deleted;
                    response.Record = existingIPDPatient;
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

        public async Task<Response<IPDPatient>> Discharge(int id)
        {
            Response<IPDPatient> response = new Response<IPDPatient>();

            try
            {
                IPDPatient? existingIPDPatient = await _IPDPatientDataAccess.Get(id);
                if (existingIPDPatient != null)
                {
                    existingIPDPatient.Discharged = true;
                    await _IPDPatientDataAccess.Update(id, existingIPDPatient);
                    response.StatusCode = 200;
                    response.StatusMessage = HttpMessages.Deleted;
                    response.Record = existingIPDPatient;
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

        public async Task<Response<IPDPatient>> Get(int id)
        {
            Response<IPDPatient> response = new Response<IPDPatient>();

            try
            {
                IPDPatient? IPDPatient = await _IPDPatientDataAccess.Get(id);
                if (IPDPatient != null)
                {
                    response.StatusCode = 200;
                    response.StatusMessage = HttpMessages.Ok;
                    response.Record = IPDPatient;
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

        public async Task<Response<IPDPatient>> Get()
        {
            Response<IPDPatient> response = new Response<IPDPatient>();

            try
            {
                List<IPDPatient> IPDPatients = (await _IPDPatientDataAccess.Get()).ToList();
                response.StatusCode = 200;
                response.StatusMessage = HttpMessages.Ok;
                response.Records = IPDPatients;
            }
            catch (Exception ex)
            {
                //Write logic to log this exceptions somewhere//

                response.StatusCode = 500;
                response.StatusMessage = HttpMessages.InternalServerError;
            }

            return response;
        }

        public async Task<Response<IPDPatient>> Update(int id, IPDPatient IPDPatient)
        {
            Response<IPDPatient> response = new Response<IPDPatient>();

            try
            {
                IPDPatient? existingIPDPatient = await _IPDPatientDataAccess.Get(id);
                if (existingIPDPatient != null)
                {
                    IPDPatient? updatedIPDPatient = await _IPDPatientDataAccess.Update(id, IPDPatient);
                    response.StatusCode = 204;
                    response.StatusMessage = HttpMessages.Updated;
                    response.Record = updatedIPDPatient;
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
