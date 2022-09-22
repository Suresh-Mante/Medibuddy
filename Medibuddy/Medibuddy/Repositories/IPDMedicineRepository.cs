using Medibuddy.DataAccess;
using Medibuddy.Models;
using Medibuddy.Utils;

namespace Medibuddy.Repositories
{
    public class IPDMedicineRepository : IIPDMedicineRepository
    {
        private readonly IIPDMedicineDataAccess _ipdmedicineDataAccess;

        public IPDMedicineRepository(IIPDMedicineDataAccess ipdmedicineDataAccess)
        {
            _ipdmedicineDataAccess = ipdmedicineDataAccess;
        }
        public async Task<Response<IPDMedicine>> Create(IPDMedicine ipdmedicine)
        {
            Response<IPDMedicine> response = new Response<IPDMedicine>();

            try
            {
                IPDMedicine createdIPDMedicine = await _ipdmedicineDataAccess.Create(ipdmedicine);
                response.StatusCode = 201;
                response.StatusMessage = HttpMessages.Created;
                response.Record = createdIPDMedicine;
            }
            catch (Exception ex)
            {
                //Write logic to log this exceptions somewhere//
                response.StatusCode = 500;
                response.StatusMessage = HttpMessages.InternalServerError;
            }

            return response;
        }

        public async Task<Response<IPDMedicine>> Delete(int IPDPatientID)
        {
            Response<IPDMedicine> response = new Response<IPDMedicine>();

            try
            {
                List<IPDMedicine> ipdmedicines = (await _ipdmedicineDataAccess.Get(IPDPatientID)).ToList();
                if (ipdmedicines.Count > 0)
                {
                    await _ipdmedicineDataAccess.Delete(IPDPatientID);
                    response.StatusCode = 200;
                    response.StatusMessage = HttpMessages.Deleted;
                    response.Records = ipdmedicines;
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

        public async Task<Response<IPDMedicine>> Get(int IPDPatientID)
        {
            Response<IPDMedicine> response = new Response<IPDMedicine>();

            try
            {
                List<IPDMedicine> ipdmedicines = (await _ipdmedicineDataAccess.Get(IPDPatientID)).ToList();
                response.StatusCode = 200;
                response.StatusMessage = HttpMessages.Ok;
                response.Records = ipdmedicines;
            }
            catch (Exception ex)
            {
                //Write logic to log this exceptions somewhere//

                response.StatusCode = 500;
                response.StatusMessage = HttpMessages.InternalServerError;
            }

            return response;
        }

        public async Task<Response<IPDMedicine>> Get()
        {
            Response<IPDMedicine> response = new Response<IPDMedicine>();

            try
            {
                List<IPDMedicine> ipdmedicines = (await _ipdmedicineDataAccess.Get()).ToList();
                response.StatusCode = 200;
                response.StatusMessage = HttpMessages.Ok;
                response.Records = ipdmedicines;
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
