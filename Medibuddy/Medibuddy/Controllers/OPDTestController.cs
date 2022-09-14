using Medibuddy.Models;
using Medibuddy.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Medibuddy.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OPDTestController : Controller
    {

        private readonly IOPDTestRepository _opdtestRepository;

        public OPDTestController(IOPDTestRepository opdtestRepository)
        {
            _opdtestRepository = opdtestRepository;
        }

        [HttpPost]
        public async Task<Response<OPDTest>> Create(OPDTestDTO opdtest)
        {
            OPDTest newOPDTest = new OPDTest()
            {
                OPDBillingID = opdtest.OPDBillingID,
                TestID = opdtest.TestID
            };
            return await _opdtestRepository.Create(newOPDTest);
        }

        [HttpGet("{id}")]
        public async Task<Response<OPDTest>> Get(int OPDBillingID,int TestID)
        {
            return await _opdtestRepository.Get(OPDBillingID,TestID);
        }

        [HttpGet]
        public async Task<Response<OPDTest>> Get()
        {
            return await _opdtestRepository.Get();
        }

        [HttpPut]
        public async Task<Response<OPDTest>> Update(int OPDBillingID,int TestID, OPDTestDTO opdtest)
        {
            return await _opdtestRepository.Update(OPDBillingID,TestID, new OPDTest()
            {
                OPDBillingID = opdtest.OPDBillingID,
                TestID = opdtest.TestID
            });
        }

        [HttpDelete]
        public async Task<Response<OPDTest>> Delete(int OPDBillingID,int TestID)
        {
            return await _opdtestRepository.Delete(OPDBillingID,TestID);
        }
    }
}
