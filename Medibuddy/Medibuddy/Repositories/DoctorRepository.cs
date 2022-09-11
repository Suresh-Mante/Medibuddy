using Medibuddy.DataAccess;
using Medibuddy.Models;
using Medibuddy.Utils;

namespace Medibuddy.Repositories
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly IDoctorDataAccess _doctorDataAccess;

        public DoctorRepository(IDoctorDataAccess doctorDataAccess)
        {
            _doctorDataAccess = doctorDataAccess;
        }

        public async Task<Response<Doctor>> Create(Doctor doctor)
        {
            Response<Doctor> response = new Response<Doctor>();

            try
            {
                Doctor createdDoctor = await _doctorDataAccess.Create(doctor);
                response.StatusCode = 201;
                response.StatusMessage = HttpMessages.Created;
                response.Record = createdDoctor;
            }
            catch (Exception ex)
            {
                //Write logic to log this exceptions somewhere//

                response.StatusCode = 500;
                response.StatusMessage = HttpMessages.InternalServerError;
            }

            return response;
        }

        public async Task<Response<Doctor>> Delete(int ID)
        {
            Response<Doctor> response = new Response<Doctor>();

            try
            {
                Doctor? existingDoctor = await _doctorDataAccess.Get(ID);
                if (existingDoctor != null)
                {
                    await _doctorDataAccess.Delete(ID);
                    response.StatusCode = 200;
                    response.StatusMessage = HttpMessages.Deleted;
                    response.Record = existingDoctor;
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

        public async Task<Response<Doctor>> Get(int ID)
        {
            Response<Doctor> response = new Response<Doctor>();

            try
            {
                Doctor? doctor = await _doctorDataAccess.Get(ID);
                if (doctor != null)
                {
                    response.StatusCode = 200;
                    response.StatusMessage = HttpMessages.Ok;
                    response.Record = doctor;
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

        public async Task<Response<Doctor>> Get()
        {
            Response<Doctor> response = new Response<Doctor>();

            try
            {
                List<Doctor> doctors = (await _doctorDataAccess.Get()).ToList();
                response.StatusCode = 200;
                response.StatusMessage = HttpMessages.Ok;
                response.Records = doctors;
            }
            catch (Exception ex)
            {
                //Write logic to log this exceptions somewhere//

                response.StatusCode = 500;
                response.StatusMessage = HttpMessages.InternalServerError;
            }

            return response;
        }

        public async Task<Response<Doctor>> Update(int ID, Doctor doctor)
        {
            Response<Doctor> response = new Response<Doctor>();

            try
            {
                Doctor? existingDoctor = await _doctorDataAccess.Get(ID);
                if (existingDoctor != null)
                {
                    Doctor? updatedDoctor = await _doctorDataAccess.Update(ID, doctor);
                    response.StatusCode = 204;
                    response.StatusMessage = HttpMessages.Updated;
                    response.Record = updatedDoctor;
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
