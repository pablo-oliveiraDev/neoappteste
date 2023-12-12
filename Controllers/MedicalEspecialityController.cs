using csharp_docker_postgree_api.Interfaces;
using csharp_docker_postgree_api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace csharp_docker_postgree_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalEspecialityController : ControllerBase
    {
        private readonly IMedicalEspecialityRepository _medicalEspecialityRepository;
        public MedicalEspecialityController(IMedicalEspecialityRepository medicalEspecialityRepository)
        {
            _medicalEspecialityRepository = medicalEspecialityRepository ?? throw new ArgumentNullException();
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MedicalEspeciality>>> Get()
        {
            var medicalEspeciality = await _medicalEspecialityRepository.GetAllMedicalEspeciality();
            if (medicalEspeciality == null)
            {
                return NotFound();
            }
            return Ok(medicalEspeciality);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<MedicalEspeciality>> GetById(int id)
        {
            var medicalEspeciality = await _medicalEspecialityRepository.GetMedicalEspecialityById(id);
            if (medicalEspeciality == null)
            {
                return NotFound();
            }
            return Ok(medicalEspeciality);
        }
        [HttpPost("Patient")]
        public async Task<ActionResult<MedicalEspeciality>> Post(MedicalEspeciality request)
        {

            await _medicalEspecialityRepository.CreateMedicalEspeciality(request);
            return CreatedAtAction(nameof(Get), new { request }, request);
        }


        [HttpPut]
        public async Task<ActionResult<MedicalEspeciality>> PutPatient(int id, MedicalEspeciality request)
        {
            var existsMedicalEspeciality = await _medicalEspecialityRepository.GetMedicalEspecialityById(id);
            if (existsMedicalEspeciality == null)
            {
                return NotFound();
            }
            existsMedicalEspeciality.EspecialityName = request.EspecialityName;
            return Ok(existsMedicalEspeciality);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<MedicalEspeciality>> Delete(int id)
        {
            var medicalEspeciality = await _medicalEspecialityRepository.GetMedicalEspecialityById(id);
            if (medicalEspeciality == null)
            {
                return NotFound();
            }
            await _medicalEspecialityRepository.DeleteMedicalEspeciality(id);
            return Ok(medicalEspeciality);
        }
    }
}
