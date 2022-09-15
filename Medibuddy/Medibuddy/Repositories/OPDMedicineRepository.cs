using Medibuddy.DataAccess;
using Medibuddy.Models;
using Medibuddy.Utils;

namespace Medibuddy.Repositories
{
    public class OPDMedicineRepository : IOPDMedicineRepository
    {
        private readonly IOPDMedicineDataAccess _opdmedicineDataAccess;

        public OPDMedicineRepository(IOPDMedicineDataAccess opdmedicineDataAccess)
        {
            _opdmedicineDataAccess = opdmedicineDataAccess;
        }
        public async Task<Response<OPDMedicine>> Create(OPDMedicine opdmedicine)
        {
            Response<OPDMedicine> response = new Response<OPDMedicine>();

            try
            {
                OPDMedicine createdOPDMedicine = await _opdmedicineDataAccess.Create(opdmedicine);
                response.StatusCode = 201;
                response.StatusMessage = HttpMessages.Created;
                response.Record = createdOPDMedicine;
            }
            catch (Exception ex)
            {
                //Write logic to log this exceptions somewhere//
                response.StatusCode = 500;
                response.StatusMessage = HttpMessages.InternalServerError;
            }

            return response;
        }

        public async Task<Response<OPDMedicine>> Delete(int OPDBillingID)
        {
            Response<OPDMedicine> response = new Response<OPDMedicine>();

            try
            {
                List<OPDMedicine> opdmedicines = (await _opdmedicineDataAccess.Get(OPDBillingID)).ToList();
                if (opdmedicines.Count > 0)
                {
                    await _opdmedicineDataAccess.Delete(OPDBillingID);
                    response.StatusCode = 200;
                    response.StatusMessage = HttpMessages.Deleted;
                    response.Records = opdmedicines;
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

        public async Task<Response<OPDMedicine>> Get(int OPDBillingID)
        {
            Response<OPDMedicine> response = new Response<OPDMedicine>();

            try
            {
                List<OPDMedicine> opdmedicines = (await _opdmedicineDataAccess.Get(OPDBillingID)).ToList();
                response.StatusCode = 200;
                response.StatusMessage = HttpMessages.Ok;
                response.Records = opdmedicines;
            }
            catch (Exception ex)
            {
                //Write logic to log this exceptions somewhere//

                response.StatusCode = 500;
                response.StatusMessage = HttpMessages.InternalServerError;
            }

            return response;
        }

        public async Task<Response<OPDMedicine>> Get()
        {
            Response<OPDMedicine> response = new Response<OPDMedicine>();

            try
            {
                List<OPDMedicine> opdmedicines = (await _opdmedicineDataAccess.Get()).ToList();
                response.StatusCode = 200;
                response.StatusMessage = HttpMessages.Ok;
                response.Records = opdmedicines;
            }
            catch (Exception ex)
            {
                //Write logic to log this exceptions somewhere//

                response.StatusCode = 500;
                response.StatusMessage = HttpMessages.InternalServerError;
            }

            return response;
        }


        /*
        public async Task<Response<OPDMedicine>> Update(int OPDBillingID, int OPDMedicineID, OPDMedicine opdmedicine)
        {
            Response<OPDMedicine> response = new Response<OPDMedicine>();

            try
            {
                OPDMedicine? existingopdmedicine = await _opdmedicineDataAccess.Get(OPDBillingID,OPDMedicineID);
                if (existingopdmedicine != null)
                {
                    OPDMedicine? updatedopdmedicine = await _opdmedicineDataAccess.Update(OPDBillingID,OPDMedicineID,opdmedicine);
                    response.StatusCode = 204;
                    response.StatusMessage = HttpMessages.Updated;
                    response.Record = updatedopdmedicine;
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
        */
    }
}
