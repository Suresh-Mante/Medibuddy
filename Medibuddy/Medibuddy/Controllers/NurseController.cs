using Medibuddy.Models;
using Medibuddy.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Medibuddy.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NurseController : Controller
    {
        private readonly INurseRepository _nurseRepository;

        public NurseController(INurseRepository nurseRepository)
        {
            _nurseRepository = nurseRepository;
        }

        [HttpPost]
        public async Task<Response<Nurse>> Create(NurseDTO nurse)
        {
            Nurse newNurse = new Nurse()
            {
                Name = nurse.Name,
                Mobile = nurse.Mobile,
                Email = nurse.Email,
                Gender = nurse.Gender,
                Salary = nurse.Salary
            };
            return await _nurseRepository.Create(newNurse);
        }

        [HttpGet("{ID}")]
        public async Task<Response<Nurse>> Get(int ID)
        {
            return await _nurseRepository.Get(ID);
        }

        [HttpGet]
        public async Task<Response<Nurse>> Get()
        {
            return await _nurseRepository.Get();
        }

        [HttpPut]
        public async Task<Response<Nurse>> Update(int ID, NurseDTO nurse)
        {
            return await _nurseRepository.Update(ID, new Nurse()
            {
                Name = nurse.Name,
                Mobile = nurse.Mobile,
                Email = nurse.Email,
                Gender = nurse.Gender,
                Salary = nurse.Salary
            });
        }

        [HttpDelete]
        public async Task<Response<Nurse>> Delete(int ID)
        {
            return await _nurseRepository.Delete(ID);
        }
    }
}
