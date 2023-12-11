using csharp_docker_postgree_api.Interfaces;
using csharp_docker_postgree_api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace csharp_docker_postgree_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrescriptionController : ControllerBase
    {
        private readonly IPrescriptionRepository _prescriptionRepository;


        public PrescriptionController(IPrescriptionRepository prescriptionRepository)
        {
            _prescriptionRepository = prescriptionRepository ?? throw new ArgumentNullException();
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Prescription>>> Get()
        {
            var prescription = await _prescriptionRepository.GetAllPrescription();

            return Ok(prescription);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Prescription>> GetById(int id)
        {
            var prescription = await _prescriptionRepository.GetPrescriptionById(id);
            if (prescription == null)
            {
                return NotFound();
            }
            return Ok(prescription);
        }
        [HttpPost]
        public async Task<ActionResult<Prescription>> PostPrescription(Prescription request)
        {

            await _prescriptionRepository.CreatePrescription(request);
            return CreatedAtAction(nameof(Get), new { request }, request);
        }


        [HttpPut]
        public async Task<ActionResult<Prescription>> PutPrescription(int id, Prescription request)
        {
            var existsprescription = await _prescriptionRepository.GetPrescriptionById(id);
            if (existsprescription == null)
            {
                return NotFound();
            }
            existsprescription.Instructions= request.Instructions;
            existsprescription.Dosgae= request.Dosgae;
            existsprescription.Medicinals= request.Medicinals;
            existsprescription.ConsultId= request.ConsultId;
            return Ok(existsprescription);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Prescription>> Delete(int id)
        {
            var prescription = await _prescriptionRepository.GetPrescriptionById(id);
            if (prescription == null)
            {
                return NotFound();
            }
            await _prescriptionRepository.DeletePrescription(id);
            return Ok(prescription);
        }
    }
}
