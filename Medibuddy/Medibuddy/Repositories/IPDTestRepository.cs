using Medibuddy.DataAccess;
using Medibuddy.Models;
using Medibuddy.Utils;

namespace Medibuddy.Repositories
{
    public class IPDTestRepository : IIPDTestRepository
    {
        private readonly IIPDTestDataAccess _ipdtestDataAccess;

        public IPDTestRepository(IIPDTestDataAccess ipdtestDataAccess)
        {
            _ipdtestDataAccess = ipdtestDataAccess;
        }
        public async Task<Response<IPDTest>> Create(IPDTest ipdtest)
        {
            Response<IPDTest> response = new Response<IPDTest>();

            try
            {
                IPDTest createdIPDTest = await _ipdtestDataAccess.Create(ipdtest);
                response.StatusCode = 201;
                response.StatusMessage = HttpMessages.Created;
                response.Record = createdIPDTest;
            }
            catch (Exception ex)
            {
                //Write logic to log this exceptions somewhere//
                response.StatusCode = 500;
                response.StatusMessage = HttpMessages.InternalServerError;
            }

            return response;
        }

        public async Task<Response<IPDTest>> Delete(int IPDPatientID)
        {
            Response<IPDTest> response = new Response<IPDTest>();

            try
            {
                List<IPDTest> ipdtests = (await _ipdtestDataAccess.Get(IPDPatientID)).ToList();
                if (ipdtests.Count > 0)
                {
                    await _ipdtestDataAccess.Delete(IPDPatientID);
                    response.StatusCode = 200;
                    response.StatusMessage = HttpMessages.Deleted;
                    response.Records = ipdtests;
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

        public async Task<Response<IPDTest>> Get(int IPDPatientID)
        {
            Response<IPDTest> response = new Response<IPDTest>();

            try
            {
                List<IPDTest> ipdtests = (await _ipdtestDataAccess.Get(IPDPatientID)).ToList();
                response.StatusCode = 200;
                response.StatusMessage = HttpMessages.Ok;
                response.Records = ipdtests;
            }
            catch (Exception ex)
            {
                //Write logic to log this exceptions somewhere//

                response.StatusCode = 500;
                response.StatusMessage = HttpMessages.InternalServerError;
            }

            return response;
        }

        public async Task<Response<IPDTest>> Get()
        {
            Response<IPDTest> response = new Response<IPDTest>();

            try
            {
                List<IPDTest> ipdtests = (await _ipdtestDataAccess.Get()).ToList();
                response.StatusCode = 200;
                response.StatusMessage = HttpMessages.Ok;
                response.Records = ipdtests;
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
