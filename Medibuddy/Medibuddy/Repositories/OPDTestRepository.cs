using Medibuddy.DataAccess;
using Medibuddy.Models;
using Medibuddy.Utils;

namespace Medibuddy.Repositories
{
    public class OPDTestRepository : IOPDTestRepository
    {
        private readonly IOPDTestDataAccess _opdtestDataAccess;

        public OPDTestRepository(IOPDTestDataAccess opdtestDataAccess)
        {
            _opdtestDataAccess = opdtestDataAccess;
        }
        public async Task<Response<OPDTest>> Create(OPDTest opdtest)
        {
            Response<OPDTest> response = new Response<OPDTest>();

            try
            {
                OPDTest createdOPDTest = await _opdtestDataAccess.Create(opdtest);
                response.StatusCode = 201;
                response.StatusMessage = HttpMessages.Created;
                response.Record = createdOPDTest;
            }
            catch (Exception ex)
            {
                //Write logic to log this exceptions somewhere//
                response.StatusCode = 500;
                response.StatusMessage = HttpMessages.InternalServerError;
            }

            return response;
        }

        public async Task<Response<OPDTest>> Delete(int OPDBillingID)
        {
            Response<OPDTest> response = new Response<OPDTest>();

            try
            {
                List<OPDTest> opdtests = (await _opdtestDataAccess.Get(OPDBillingID)).ToList();
                if (opdtests.Count>0)
                {
                    await _opdtestDataAccess.Delete(OPDBillingID);
                    response.StatusCode = 200;
                    response.StatusMessage = HttpMessages.Deleted;
                    response.Records = opdtests;
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

        public async Task<Response<OPDTest>> Get(int OPDBillingID)
        {
            Response<OPDTest> response = new Response<OPDTest>();

            try
            {
                List<OPDTest> opdtests = (await _opdtestDataAccess.Get(OPDBillingID)).ToList();
                response.StatusCode = 200;
                response.StatusMessage = HttpMessages.Ok;
                response.Records = opdtests;
            }
            catch (Exception ex)
            {
                //Write logic to log this exceptions somewhere//

                response.StatusCode = 500;
                response.StatusMessage = HttpMessages.InternalServerError;
            }

            return response;
        }

        public async Task<Response<OPDTest>> Get()
        {
            Response<OPDTest> response = new Response<OPDTest>();

            try
            {
                List<OPDTest> opdtests = (await _opdtestDataAccess.Get()).ToList();
                response.StatusCode = 200;
                response.StatusMessage = HttpMessages.Ok;
                response.Records = opdtests;
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
        public async Task<Response<OPDTest>> Update(int OPDBillingID, int OPDTestID, OPDTest opdtest)
        {
            Response<OPDTest> response = new Response<OPDTest>();

            try
            {
                OPDTest? existingopdtest = await _opdtestDataAccess.Get(OPDBillingID,OPDTestID);
                if (existingopdtest != null)
                {
                    OPDTest? updatedopdtest = await _opdtestDataAccess.Update(OPDBillingID,OPDTestID,opdtest);
                    response.StatusCode = 204;
                    response.StatusMessage = HttpMessages.Updated;
                    response.Record = updatedopdtest;
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
