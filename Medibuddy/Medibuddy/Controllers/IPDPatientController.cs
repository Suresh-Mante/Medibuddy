using Medibuddy.Models;
using Medibuddy.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Medibuddy.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IPDPatientController : ControllerBase
    {
        private readonly IIPDPatientRepository _IPDPatientRepository;

        public IPDPatientController(IIPDPatientRepository IPDPatientRepository)
        {
            _IPDPatientRepository = IPDPatientRepository;
        }

        /// <summary>
        /// Creates a new IPDPatient
        /// </summary>
        /// <param name="IPDPatient"></param>
        /// <returns>
        /// Created IPDPatient
        /// </returns>
        [HttpPost]
        public async Task<Response<IPDPatient>> Create(IPDPatientDTO IPDPatient)
        {
            IPDPatient newIPDPatient = new IPDPatient()
            {
                PID = IPDPatient.PID,
                DocId = IPDPatient.DocId,
                NurseID = IPDPatient.NurseID,
                EntryDate = IPDPatient.EntryDate,
                ExitDate = IPDPatient.ExitDate,
                RoomID = IPDPatient.RoomID,
                Discharged = IPDPatient.Discharged
            };
            return await _IPDPatientRepository.Create(newIPDPatient);
        }

        /// <summary>
        /// Get IPDPatient with given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// Returns a IPDPatient with given id if exists
        /// </returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpGet("{id}")]
        public async Task<Response<IPDPatient>> Get(int id)
        {
            return await _IPDPatientRepository.Get(id);
        }

        /// <summary>
        /// Get all IPDPatients
        /// </summary>
        /// <returns>
        /// Returns all IPDPatients
        /// </returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpGet]
        public async Task<Response<IPDPatient>> Get()
        {
            return await _IPDPatientRepository.Get();
        }

        /// <summary>
        /// Updates IPDPatient with given id and data
        /// </summary>
        /// <param name="id"></param>
        /// <param name="IPDPatient"></param>
        /// <returns>
        /// Updated IPDPatient if exists
        /// </returns>
        [HttpPut]
        public async Task<Response<IPDPatient>> Update(int id, IPDPatientDTO IPDPatient)
        {
            return await _IPDPatientRepository.Update(id, new IPDPatient()
            {
                PID = IPDPatient.PID,
                DocId = IPDPatient.DocId,
                NurseID=IPDPatient.NurseID,
                EntryDate=IPDPatient.EntryDate,
                ExitDate=IPDPatient.ExitDate,
                RoomID=IPDPatient.RoomID,
                Discharged = IPDPatient.Discharged
            });
        }

        /// <summary>
        /// Deletes IPDPatient with given id if exists
        /// </summary>
        /// <param name="id"></param>
        /// <param name="IPDPatient"></param>
        /// <returns>
        /// Deleted IPDPatient if exists
        /// </returns>
        [HttpDelete]
        public async Task<Response<IPDPatient>> Delete(int id)
        {
            return await _IPDPatientRepository.Delete(id);
        }

        [HttpPost("Discharge/{id}")]
        public async Task<Response<IPDPatient>> Discharge(int id)
        {
            return await _IPDPatientRepository.Discharge(id);
        }
    }
}
