using Medibuddy.DataAccess;
using Medibuddy.Models;
using Medibuddy.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Medibuddy.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class OPDBillingController: ControllerBase
    {
        private readonly IOPDBillingRepository _OPDBillingRepository;

        public OPDBillingController(IOPDBillingRepository OPDBillingRepository)
        {
            _OPDBillingRepository = OPDBillingRepository;
        }

        /// <summary>
        /// Creates a new OPDBilling
        /// </summary>
        /// <param name="OPDBilling"></param>
        /// <returns>
        /// Created OPDBilling
        /// </returns>
        [HttpPost]
        public async Task<Response<OPDBilling>> Create(OPDBillingDTO OPDBilling)
        {
            OPDBilling newOPDBilling = new OPDBilling()
            {
                PID = OPDBilling.PID,
                DocId = OPDBilling.DocId
            };
            return await _OPDBillingRepository.Create(newOPDBilling);
        }

        /// <summary>
        /// Get OPDBilling with given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// Returns a OPDBilling with given id if exists
        /// </returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpGet("{id}")]
        public async Task<Response<OPDBilling>> Get(int id)
        {
            return await _OPDBillingRepository.Get(id);
        }

        /// <summary>
        /// Get all OPDBillings
        /// </summary>
        /// <returns>
        /// Returns all OPDBillings
        /// </returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpGet]
        public async Task<Response<OPDBilling>> Get()
        {
            return await _OPDBillingRepository.Get();
        }

        /// <summary>
        /// Updates OPDBilling with given id and data
        /// </summary>
        /// <param name="id"></param>
        /// <param name="OPDBilling"></param>
        /// <returns>
        /// Updated OPDBilling if exists
        /// </returns>
        [HttpPut]
        public async Task<Response<OPDBilling>> Update(int id, OPDBillingDTO OPDBilling)
        {
            return await _OPDBillingRepository.Update(id, new OPDBilling()
            {
                PID = OPDBilling.PID,
                DocId = OPDBilling.DocId
            });
        }

        /// <summary>
        /// Deletes OPDBilling with given id if exists
        /// </summary>
        /// <param name="id"></param>
        /// <param name="OPDBilling"></param>
        /// <returns>
        /// Deleted OPDBilling if exists
        /// </returns>
        [HttpDelete]
        public async Task<Response<OPDBilling>> Delete(int id)
        {
            return await _OPDBillingRepository.Delete(id);
        }
    }
}
