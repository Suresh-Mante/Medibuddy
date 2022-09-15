using Medibuddy.Models;
using Medibuddy.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Medibuddy.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OPDMedicineController : Controller
    {

        private readonly IOPDMedicineRepository _opdmedicineRepository;

        public OPDMedicineController(IOPDMedicineRepository opdmedicineRepository)
        {
            _opdmedicineRepository = opdmedicineRepository;
        }


        [HttpPost]
        public async Task<Response<OPDMedicine>> Create(OPDMedicineDTO opdmedicine)
        {
            OPDMedicine newOPDMedicine = new OPDMedicine()
            {
                OPDBillingID = opdmedicine.OPDBillingID,
                MedicineID = opdmedicine.MedicineID
            };
            return await _opdmedicineRepository.Create(newOPDMedicine);
        }

        [HttpGet("{OPDBillingID}")]
        public async Task<Response<OPDMedicine>> Get(int OPDBillingID)
        {
            return await _opdmedicineRepository.Get(OPDBillingID);
        }

        [HttpGet]
        public async Task<Response<OPDMedicine>> Get()
        {
            return await _opdmedicineRepository.Get();
        }

        [HttpDelete]
        public async Task<Response<OPDMedicine>> Delete(int OPDBillingID)
        {
            return await _opdmedicineRepository.Delete(OPDBillingID);
        }




    }
}
