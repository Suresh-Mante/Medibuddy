using Medibuddy.Models;
using Medibuddy.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Medibuddy.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IPDTestController : Controller
    {

        private readonly IIPDTestRepository _ipdtestRepository;

        public IPDTestController(IIPDTestRepository ipdtestRepository)
        {
            _ipdtestRepository = ipdtestRepository;
        }


        [HttpPost]
        public async Task<Response<IPDTest>> Create(IPDTestDTO ipdtest)
        {
            IPDTest newIPDTest = new IPDTest()
            {
                IPDPatientID = ipdtest.IPDPatientID,
                TestID = ipdtest.TestID
            };
            return await _ipdtestRepository.Create(newIPDTest);
        }

        [HttpGet("{IPDPatientId}")]
        public async Task<Response<IPDTest>> Get(int IPDPatientId)
        {
            return await _ipdtestRepository.Get(IPDPatientId);
        }

        [HttpGet]
        public async Task<Response<IPDTest>> Get()
        {
            return await _ipdtestRepository.Get();
        }

        [HttpDelete]
        public async Task<Response<IPDTest>> Delete(int IPDPatientID)
        {
            return await _ipdtestRepository.Delete(IPDPatientID);
        }

    }
}
