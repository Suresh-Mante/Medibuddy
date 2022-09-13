using Medibuddy.Models;
using Medibuddy.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Medibuddy.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DoctorController : Controller
    {
        private readonly IDoctorRepository _doctorRepository;

        public DoctorController(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }


        [HttpPost]
        public async Task<Response<Doctor>> Create(DoctorDTO doctor)
        {
            Doctor newDoctor = new Doctor()
            {
                Name = doctor.Name,
                Type = doctor.Type,
                Mobile =doctor.Mobile,
                Email = doctor.Email,
                Gender = doctor.Gender,
                Fees = doctor.Fees,
                Salary = doctor.Salary
            };
            return await _doctorRepository.Create(newDoctor);
        }


        [HttpGet]
        public async Task<Response<Doctor>> Get()
        {
            return await _doctorRepository.Get();
        }

        [HttpGet("{ID}")]
        public async Task<Response<Doctor>> Get(int ID)
        {
            return await _doctorRepository.Get(ID);
        }


        [HttpPut]
        public async Task<Response<Doctor>> Update(int ID, DoctorDTO doctor)
        {
            return await _doctorRepository.Update(ID, new Doctor()
            {
                Name = doctor.Name,
                Type = doctor.Type,
                Mobile = doctor.Mobile,
                Email = doctor.Email,
                Gender = doctor.Gender,
                Fees = doctor.Fees,
                Salary = doctor.Salary
            });
        }

        [HttpDelete]
        public async Task<Response<Doctor>> Delete(int ID)
        {
           return await _doctorRepository.Delete(ID); 
        }
    }
}
