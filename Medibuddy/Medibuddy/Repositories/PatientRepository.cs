using Medibuddy.DataAccess;
using Medibuddy.Models;
using Medibuddy.Utils;

namespace Medibuddy.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly IPatientDataAccess _patientDataAccess;

        public PatientRepository(IPatientDataAccess patientDataAccess)
        {
            _patientDataAccess = patientDataAccess;
        }

        public async Task<Response<Patient>> Create(Patient patient)
        {
            Response<Patient> response = new Response<Patient>();

            try
            {
                Patient createdPatient = await _patientDataAccess.Create(patient);
                response.StatusCode = 201;
                response.StatusMessage = HttpMessages.Created;
                response.Record = createdPatient;
            }
            catch (Exception ex)
            {
                //Write logic to log this exceptions somewhere//

                response.StatusCode = 500;
                response.StatusMessage = HttpMessages.InternalServerError;
            }

            return response;
        }

        public async Task<Response<Patient>> Delete(int PID)
        {
            Response<Patient> response = new Response<Patient>();

            try
            {
                Patient? existingPatient = await _patientDataAccess.Get(PID);
                if (existingPatient != null)
                {
                    await _patientDataAccess.Delete(PID);
                    response.StatusCode = 200;
                    response.StatusMessage = HttpMessages.Created;
                    response.Record = existingPatient;
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

        public async Task<Response<Patient>> Get(int PID)
        {
            Response<Patient> response = new Response<Patient>();

            try
            {
                Patient? patient = await _patientDataAccess.Get(PID);
                if (patient != null)
                {
                    response.StatusCode = 200;
                    response.StatusMessage = HttpMessages.Ok;
                    response.Record = patient;
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

        public async Task<Response<Patient>> Get()
        {
            Response<Patient> response = new Response<Patient>();

            try
            {
                List<Patient> patients = (await _patientDataAccess.Get()).ToList();
                response.StatusCode = 200;
                response.StatusMessage = HttpMessages.Ok;
                response.Records = patients;
            }
            catch (Exception ex)
            {
                //Write logic to log this exceptions somewhere//

                response.StatusCode = 500;
                response.StatusMessage = HttpMessages.InternalServerError;
            }

            return response;
        }

        public async Task<Response<Patient>> Update(int PID, Patient patient)
        {
            Response<Patient> response = new Response<Patient>();

            try
            {
                Patient? existingPatient = await _patientDataAccess.Get(PID);
                if (existingPatient != null)
                {
                    Patient? updatedPatient = await _patientDataAccess.Update(PID, patient);
                    response.StatusCode = 201;
                    response.StatusMessage = HttpMessages.Created;
                    response.Record = updatedPatient;
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
