using Medibuddy.DataAccess;
using Medibuddy.Models;
using Medibuddy.Utils;

namespace Medibuddy.Repositories
{
    public class OPDPatientRepository : IOPDPatientRepository
    {
        private readonly IOPDPatientDataAccess _OPDPatientDataAccess;

        public OPDPatientRepository(IOPDPatientDataAccess OPDPatientDataAccess)
        {
            _OPDPatientDataAccess = OPDPatientDataAccess;
        }

        public async Task<Response<OPDPatient>> Create(OPDPatient OPDPatient)
        {
            Response<OPDPatient> response = new Response<OPDPatient>();

            try
            {
                OPDPatient createdOPDPatient = await _OPDPatientDataAccess.Create(OPDPatient);
                response.StatusCode = 201;
                response.StatusMessage = HttpMessages.Created;
                response.Record = createdOPDPatient;
            }
            catch (Exception ex)
            {
                //Write logic to log this exceptions somewhere//

                response.StatusCode = 500;
                response.StatusMessage = HttpMessages.InternalServerError;
            }

            return response;
        }

        public async Task<Response<OPDPatient>> Delete(int id)
        {
            Response<OPDPatient> response = new Response<OPDPatient>();

            try
            {
                OPDPatient? existingOPDPatient = await _OPDPatientDataAccess.Get(id);
                if (existingOPDPatient != null)
                {
                    await _OPDPatientDataAccess.Delete(id);
                    response.StatusCode = 200;
                    response.StatusMessage = HttpMessages.Deleted;
                    response.Record = existingOPDPatient;
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

        public async Task<Response<OPDPatient>> Discharge(int id)
        {
            Response<OPDPatient> response = new Response<OPDPatient>();

            try
            {
                OPDPatient? existingOPDPatient = await _OPDPatientDataAccess.Get(id);
                if (existingOPDPatient != null)
                {
                    existingOPDPatient.Discharged = true;
                    await _OPDPatientDataAccess.Update(id, existingOPDPatient);
                    response.StatusCode = 200;
                    response.StatusMessage = HttpMessages.Deleted;
                    response.Record = existingOPDPatient;
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

        public async Task<Response<OPDPatient>> Get(int id)
        {
            Response<OPDPatient> response = new Response<OPDPatient>();

            try
            {
                OPDPatient? OPDPatient = await _OPDPatientDataAccess.Get(id);
                if (OPDPatient != null)
                {
                    response.StatusCode = 200;
                    response.StatusMessage = HttpMessages.Ok;
                    response.Record = OPDPatient;
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

        public async Task<Response<OPDPatient>> Get()
        {
            Response<OPDPatient> response = new Response<OPDPatient>();

            try
            {
                List<OPDPatient> OPDPatients = (await _OPDPatientDataAccess.Get()).ToList();
                response.StatusCode = 200;
                response.StatusMessage = HttpMessages.Ok;
                response.Records = OPDPatients;
            }
            catch (Exception ex)
            {
                //Write logic to log this exceptions somewhere//

                response.StatusCode = 500;
                response.StatusMessage = HttpMessages.InternalServerError;
            }

            return response;
        }

        public async Task<Response<OPDPatient>> Update(int id, OPDPatient OPDPatient)
        {
            Response<OPDPatient> response = new Response<OPDPatient>();

            try
            {
                OPDPatient? existingOPDPatient = await _OPDPatientDataAccess.Get(id);
                if (existingOPDPatient != null)
                {
                    OPDPatient? updatedOPDPatient = await _OPDPatientDataAccess.Update(id, OPDPatient);
                    response.StatusCode = 204;
                    response.StatusMessage = HttpMessages.Updated;
                    response.Record = updatedOPDPatient;
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
