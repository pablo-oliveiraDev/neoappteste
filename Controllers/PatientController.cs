using csharp_docker_postgree_api.Interfaces;
using csharp_docker_postgree_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace csharp_docker_postgree_api.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class PatientController : ControllerBase
    {
        private readonly IPatientRepository _patientRepository;
        

        public PatientController(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository ?? throw new ArgumentNullException();
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Patient>>> Get()
        {
            var patient = await _patientRepository.GetAllPatient();
            if (patient == null)
            {
                return NotFound();
            }
            return Ok(patient);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Patient>> Get(int id)
        {
            var patient = await _patientRepository.GetPatientById(id);
            if (patient == null)
            {
                return NotFound();
            }
            return Ok(patient);
        }
        [HttpPost("Patient")]
        public async Task<ActionResult<Patient>> Post(Patient request)
        {         
            
            await _patientRepository.CreatePatient(request);
            return CreatedAtAction(nameof(Get), new { request }, request);
        }

    
        [HttpPut]
        public async Task<ActionResult<Patient>> PutPatient(int id, Patient request)
        {
            var existsPatient = await _patientRepository.GetPatientById(id);
            if (existsPatient == null)
            {
                return NotFound();
            }
            existsPatient.PatientName = request.PatientName;
            existsPatient.Age = request.Age;
            existsPatient.Gender = request.Gender;
            existsPatient.DateOfBirth = request.DateOfBirth;
            existsPatient.Weigth = request.Weigth;
            return Ok(existsPatient);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Patient>> Delete(int id)
        {
            var patient = await _patientRepository.GetPatientById(id);
            if (patient == null)
            {
                return NotFound();
            }
            await _patientRepository.DeletePatient(id);
            return Ok(patient);
        }
    }
}
