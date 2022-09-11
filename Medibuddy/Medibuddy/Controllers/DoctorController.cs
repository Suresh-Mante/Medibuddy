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
        public Task<IActionResult> Create(Doctor doctor)
        {
            //Write your implementation here
            throw new NotImplementedException();
        }

        [HttpGet("{id}")]
        public Task<IActionResult> Get(int id)
        {
            //Write your implementation here
            throw new NotImplementedException();
        }

        [HttpGet]
        public Task<IActionResult> Get()
        {
            //Write your implementation here
            throw new NotImplementedException();
        }

        [HttpPut]
        public Task<IActionResult> Update(int ID, Doctor doctor)
        {
            //Write your implementation here
            throw new NotImplementedException();
        }

        [HttpDelete]
        public Task<IActionResult> Delete(int ID)
        {
            //Write your implementation here
            throw new NotImplementedException();
        }
    }
}
