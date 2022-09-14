using Medibuddy.Models;
using Medibuddy.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Medibuddy.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OPDPatientController : ControllerBase
    {
        private readonly IOPDPatientRepository _OPDPatientRepository;

        public OPDPatientController(IOPDPatientRepository OPDPatientRepository)
        {
            _OPDPatientRepository = OPDPatientRepository;
        }

        /// <summary>
        /// Creates a new OPDPatient
        /// </summary>
        /// <param name="OPDPatient"></param>
        /// <returns>
        /// Created OPDPatient
        /// </returns>
        [HttpPost]
        public async Task<Response<OPDPatient>> Create(OPDPatientDTO OPDPatient)
        {
            OPDPatient newOPDPatient = new OPDPatient()
            {
                PID = OPDPatient.PID,
                DocId = OPDPatient.DocId,
                VisitDate = OPDPatient.VisitDate,
                OPDBillingID = OPDPatient.OPDBillingID
            };
            return await _OPDPatientRepository.Create(newOPDPatient);
        }

        /// <summary>
        /// Get OPDPatient with given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// Returns a OPDPatient with given id if exists
        /// </returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpGet("{id}")]
        public async Task<Response<OPDPatient>> Get(int id)
        {
            return await _OPDPatientRepository.Get(id);
        }

        /// <summary>
        /// Get all OPDPatients
        /// </summary>
        /// <returns>
        /// Returns all OPDPatients
        /// </returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpGet]
        public async Task<Response<OPDPatient>> Get()
        {
            return await _OPDPatientRepository.Get();
        }

        /// <summary>
        /// Updates OPDPatient with given id and data
        /// </summary>
        /// <param name="id"></param>
        /// <param name="OPDPatient"></param>
        /// <returns>
        /// Updated OPDPatient if exists
        /// </returns>
        [HttpPut]
        public async Task<Response<OPDPatient>> Update(int id, OPDPatientDTO OPDPatient)
        {
            return await _OPDPatientRepository.Update(id, new OPDPatient()
            {
                PID = OPDPatient.PID,
                DocId = OPDPatient.DocId,
                VisitDate = OPDPatient.VisitDate,
                OPDBillingID = OPDPatient.OPDBillingID
            });
        }

        /// <summary>
        /// Deletes OPDPatient with given id if exists
        /// </summary>
        /// <param name="id"></param>
        /// <param name="OPDPatient"></param>
        /// <returns>
        /// Deleted OPDPatient if exists
        /// </returns>
        [HttpDelete]
        public async Task<Response<OPDPatient>> Delete(int id)
        {
            return await _OPDPatientRepository.Delete(id);
        }
    }
}
