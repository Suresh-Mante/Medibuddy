using Medibuddy.DataAccess;
using Medibuddy.Models;
using Medibuddy.Utils;
using System.Security.Cryptography;
using static System.Net.Mime.MediaTypeNames;


namespace Medibuddy.Repositories
{
    public class MedicineRepository : IMedicineRepository
    {
        private readonly IMedicineDataAccess _medicineDataAccess;

        public MedicineRepository(IMedicineDataAccess medicineDataAccess)
        {
            _medicineDataAccess = medicineDataAccess;
        }
        public async Task<Response<Medicine>> Create(Medicine medicine)
        {
            Response<Medicine> response = new Response<Medicine>();
            try
            {
                Medicine createdMedicine = await _medicineDataAccess.Create(medicine);
                response.StatusCode = 201;
                response.StatusMessage = HttpMessages.Created;
                response.Record = createdMedicine;
            }
            catch (Exception ex)
            {
                //Write logic to log this exceptions somewhere//

                response.StatusCode = 500;
                response.StatusMessage = HttpMessages.InternalServerError;
            }

            return response;
        }

        public async Task<Response<Medicine>> Delete(int Id)
        {
            Response<Medicine> response = new Response<Medicine>();
            try
            {
                Medicine? existingMedicine = await _medicineDataAccess.Get(Id);
                if (existingMedicine != null)
                {
                    await _medicineDataAccess.Delete(Id);
                    response.StatusCode = 200;
                    response.StatusMessage = HttpMessages.Created;
                    response.Record = existingMedicine;
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

        public async Task<Response<Medicine>> Get(int Id)
        {
            Response<Medicine> response = new Response<Medicine>();
            try
            {
                Medicine? medicine = await _medicineDataAccess.Get(Id);
                if (medicine != null)
                {
                    response.StatusCode = 200;
                    response.StatusMessage = HttpMessages.Created;
                    response.Record = medicine;
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

        public async Task<Response<Medicine>> Get()
        {
            Response<Medicine> response = new Response<Medicine>();
            try
            {
                List<Medicine> medicines = (await _medicineDataAccess.Get()).ToList();
                response.StatusCode = 200;
                response.StatusMessage = HttpMessages.Ok;
                response.Records = medicines;
            }
            catch (Exception ex)
            {
                //Write logic to log this exceptions somewhere//

                response.StatusCode = 500;
                response.StatusMessage = HttpMessages.InternalServerError;
            }

            return response;
        }

        public async Task<Response<Medicine>> Update(int Id, Medicine medicine)
        {
            Response<Medicine> response = new Response<Medicine>();
            try
            {
                Medicine? existingMedicine = await _medicineDataAccess.Get(Id);
                if (existingMedicine != null)
                {
                    Medicine? updatedMedicine = await _medicineDataAccess.Update(Id, medicine);
                    response.StatusCode = 201;
                    response.StatusMessage = HttpMessages.Created;
                    response.Record = updatedMedicine;
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
