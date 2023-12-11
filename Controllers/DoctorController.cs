using csharp_docker_postgree_api.Interfaces;
using csharp_docker_postgree_api.Models;
using csharp_docker_postgree_api.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;

namespace csharp_docker_postgree_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorRepository _doctorRepository;


        public DoctorController(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository ?? throw new ArgumentNullException();
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Doctor>>> Get()
        {
            var doctor = await _doctorRepository.GetAllDoctorsAsync();
            if (doctor == null)
            {
                return NotFound();
            }
            return Ok(doctor);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Doctor>> GetById(int id)
        {
            var doctor = await _doctorRepository.GetDoctorByIdAsync(id);
            if (doctor == null)
            {
                return NotFound();
            }
            return Ok(doctor);
        }
        [HttpPost("Patient")]
        public async Task<ActionResult<Doctor>> Post(Doctor request)
        {

            await _doctorRepository.AddDoctorAsync(request);
            return CreatedAtAction(nameof(Get), new { request }, request);
        }


        [HttpPut]
        public async Task<ActionResult<Doctor>> PutPatient(int id, Doctor request)
        {
            var existsDoctor = await _doctorRepository.GetDoctorByIdAsync(id);
            if (existsDoctor == null)
            {
                return NotFound();
            }
            existsDoctor.DoctorName=request.DoctorName;
            existsDoctor.CRM=request.CRM;
            existsDoctor.EspecialityId=request.EspecialityId;
            return Ok(existsDoctor);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Doctor>> Delete(int id)
        {
            var doctor = await _doctorRepository.GetDoctorByIdAsync(id);
            if (doctor == null)
            {
                return NotFound();
            }
            await _doctorRepository.DeleteDoctorAsync(id);
            return Ok(doctor);
        }
    }
}
