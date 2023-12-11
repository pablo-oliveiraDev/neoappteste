using csharp_docker_postgree_api.Interfaces;
using csharp_docker_postgree_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace csharp_docker_postgree_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConsultController : ControllerBase
    {
        private readonly IConsultRepository _consultRepository;

        public ConsultController(IConsultRepository consultRepository)
        {
            _consultRepository = consultRepository ?? throw new ArgumentNullException();
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Consult>>> Get()
        {
            var Consult = await _consultRepository.GetAllConsult();

            return Ok(Consult);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Consult>> GetConsultById(int id)
        {
            var consult = await _consultRepository.GetConsultById(id);
            if (consult == null)
            {
                return NotFound();
            }
            return Ok(consult);
        }
        [HttpPost]
        public async Task<ActionResult<Consult>> PostConsult(Consult request)
        {

            await _consultRepository.CreateConsult(request);
            return CreatedAtAction(nameof(Get), new { request }, request);
        }
        [HttpPut]
        public async Task<ActionResult<Consult>> UpdateConsult(int id, Consult request)
        {
            var existsConsult = await _consultRepository.GetConsultById(id);
            if (existsConsult == null)
            {
                return NotFound();
            }
            existsConsult.Sympytpms = request.Sympytpms;
            existsConsult.DateOfConsult = request.DateOfConsult;
            existsConsult.Disease = request.Disease;
            existsConsult.PatientId = request.PatientId;
            existsConsult.DoctorId = request.DoctorId;
            return Ok(existsConsult);
        }
        [HttpDelete]
        public async Task<ActionResult<Consult>> Delete(int id)
        {
            var existsConsult = await _consultRepository.GetConsultById(id);
            if (existsConsult == null)
            {
                return NotFound();
            }
            await _consultRepository.DeleteConsult(id);
            return Ok(existsConsult);
        }
    }
}
