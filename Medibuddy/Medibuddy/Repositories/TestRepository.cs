using Medibuddy.DataAccess;
using Medibuddy.Models;
using Medibuddy.Utils;
using System.Security.Cryptography;

namespace Medibuddy.Repositories
{
    public class TestRepository
    {
        private readonly ITestDataAccess _testDataAccess;

        public TestRepository(ITestDataAccess testDataAccess)
        {
            _testDataAccess = testDataAccess;
        }
        public async Task<Response<Test>> Create(Test test)
        {
            Response<Test> response = new Response<Test>();

            try
            {
                Test createdTest = await _testDataAccess.Create(test);
                response.StatusCode = 201;
                response.StatusMessage = HttpMessages.Created;
                response.Record = createdTest;
            }
            catch (Exception ex)
            {
                //Write logic to log this exceptions somewhere//

                response.StatusCode = 500;
                response.StatusMessage = HttpMessages.InternalServerError;
            }

            return response;
            throw new NotImplementedException();
        }

        public async Task<Response<Test>> Delete(int Id)
        {
            Response<Test> response = new Response<Test>();

            try
            {
                Test? existingTest = await _testDataAccess.Get(Id);
                if (existingTest != null)
                {
                    await _testDataAccess.Delete(Id);
                    response.StatusCode = 200;
                    response.StatusMessage = HttpMessages.Created;
                    response.Record = existingTest;
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
            throw new NotImplementedException();
        }

        public async Task<Response<Test>> Get(int Id)
        {
            Response<Test> response = new Response<Test>();

            try
            {
                Test? test = await _testDataAccess.Get(Id);
                if (test != null)
                {
                    response.StatusCode = 200;
                    response.StatusMessage = HttpMessages.Ok;
                    response.Record = test;
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
            throw new NotImplementedException();
        }

        public async Task<Response<Test>> Get()
        {
            Response<Test> response = new Response<Test>();

            try
            {
                List<Test> patients = (await _testDataAccess.Get()).ToList();
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
            throw new NotImplementedException();
        }

        public async Task<Response<Test>> Update(int Id, Test test)
        {
            Response<Test> response = new Response<Test>();

            try
            {
                Test? existingTest = await _testDataAccess.Get(Id);
                if (existingTest != null)
                {
                    Test? updatedTest = await _testDataAccess.Update(Id, test);
                    response.StatusCode = 201;
                    response.StatusMessage = HttpMessages.Created;
                    response.Record = updatedTest;
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
            throw new NotImplementedException();
        }
    }
}
