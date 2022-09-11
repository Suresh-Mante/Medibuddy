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
        public Task<IActionResult> Create(Nurse nurse)
        {
            //Write your implementation here
            throw new NotImplementedException();
        }

        [HttpGet("{id}")]
        public Task<IActionResult> Get(int ID)
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
        public Task<IActionResult> Update(int ID, Nurse nurse)
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
