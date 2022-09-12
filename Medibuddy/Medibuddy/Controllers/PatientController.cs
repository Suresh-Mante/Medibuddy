using Medibuddy.Models;
using Medibuddy.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Medibuddy.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientController : ControllerBase
    {
        private readonly IPatientRepository _patientRepository;

        public PatientController(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        /// <summary>
        /// Creates a new patient
        /// </summary>
        /// <param name="patient"></param>
        /// <returns>
        /// Created patient
        /// </returns>
        [HttpPost]
        public async Task<Response<Patient>> Create(PatientDTO patient)
        {
            Patient newPatient = new Patient()
            {
                FirstName = patient.FirstName,
                MidName = patient.MidName,
                LastName = patient.LastName,
                Mobile = patient.Mobile,
                Email = patient.Email,
                Address = patient.Address,
                Gender = patient.Gender,
                DOB = patient.DOB
            };
            return await _patientRepository.Create(newPatient);
        }

        /// <summary>
        /// Get patient with given PID
        /// </summary>
        /// <param name="PID"></param>
        /// <returns>
        /// Returns a patient with given PID if exists
        /// </returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpGet("{PID}")]
        public async Task<Response<Patient>> Get(int PID)
        {
            return await _patientRepository.Get(PID);
        }

        /// <summary>
        /// Get all patients
        /// </summary>
        /// <returns>
        /// Returns all patients
        /// </returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpGet]
        public async Task<Response<Patient>> Get()
        {
            return await _patientRepository.Get();
        }

        /// <summary>
        /// Updates patient with given PID and data
        /// </summary>
        /// <param name="PID"></param>
        /// <param name="patient"></param>
        /// <returns>
        /// Updated patient if exists
        /// </returns>
        [HttpPut]
        public async Task<Response<Patient>> Update(int PID, PatientDTO patient)
        {
            return await _patientRepository.Update(PID, new Patient()
            {
                FirstName = patient.FirstName,
                MidName = patient.MidName,
                LastName = patient.LastName,    
                Mobile = patient.Mobile,
                Email = patient.Email,
                Address = patient.Address,
                Gender = patient.Gender,
                DOB = patient.DOB
            });
        }

        /// <summary>
        /// Deletes patient with given PID if exists
        /// </summary>
        /// <param name="PID"></param>
        /// <param name="patient"></param>
        /// <returns>
        /// Deleted patient if exists
        /// </returns>
        [HttpDelete]
        public async Task<Response<Patient>> Delete(int PID)
        {
            return await _patientRepository.Delete(PID);
        }
    }
}