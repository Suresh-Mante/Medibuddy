using Medibuddy.Models;
using Medibuddy.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Medibuddy.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IPDMedicineController : Controller
    {

        private readonly IIPDMedicineRepository _ipdmedicineRepository;

        public IPDMedicineController(IIPDMedicineRepository ipdmedicineRepository)
        {
            _ipdmedicineRepository = ipdmedicineRepository;
        }


        [HttpPost]
        public async Task<Response<IPDMedicine>> Create(IPDMedicineDTO ipdmedicine)
        {
            IPDMedicine newIPDMedicine = new IPDMedicine()
            {
                IPDPatientID = ipdmedicine.IPDPatientID,
                MedicineID = ipdmedicine.MedicineID
            };
            return await _ipdmedicineRepository.Create(newIPDMedicine);
        }

        [HttpGet("{IPDPatientId}")]
        public async Task<Response<IPDMedicine>> Get(int IPDPatientID)
        {
            return await _ipdmedicineRepository.Get(IPDPatientID);
        }

        [HttpGet]
        public async Task<Response<IPDMedicine>> Get()
        {
            return await _ipdmedicineRepository.Get();
        }

        [HttpDelete]
        public async Task<Response<IPDMedicine>> Delete(int IPDPatientID)
        {
            return await _ipdmedicineRepository.Delete(IPDPatientID);
        }

    }
}
