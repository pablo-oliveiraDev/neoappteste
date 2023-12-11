using csharp_docker_postgree_api.Interfaces;
using csharp_docker_postgree_api.Models;
using Microsoft.AspNetCore.Mvc;



namespace csharp_docker_postgree_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EvolutionController : ControllerBase
    {

        private readonly IEvolutionRepository _evolutionRepository;


        public EvolutionController(IEvolutionRepository evolutionRepository)
        {
            _evolutionRepository = evolutionRepository ?? throw new ArgumentNullException();
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Evolution>>> Get()
        {
            var evolution = await _evolutionRepository.GetAllEvolution();
           
            return Ok(evolution);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Evolution>> GetById(int id)
        {
            var evolution = await _evolutionRepository.GetEvolutiontById(id);
            if (evolution == null)
            {
                return NotFound();
            }
            return Ok(evolution);
        }
        [HttpPost]
        public async Task<ActionResult<Evolution>> PostEvolution(Evolution request)
        {

            await _evolutionRepository.CreateEvolution(request);
            return CreatedAtAction(nameof(Get), new { request }, request);
        }


        [HttpPut]
        public async Task<ActionResult<Evolution>> PutEvolution(int id, Evolution request)
        {
            var existsEvolution = await _evolutionRepository.GetEvolutiontById(id);
            if (existsEvolution == null)
            {
                return NotFound();
            }
            existsEvolution.DescribeEvolution = request.DescribeEvolution;
            existsEvolution.ConsultId = request.ConsultId;
            return Ok(existsEvolution);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Evolution>> Delete(int id)
        {
            var evolution = await _evolutionRepository.GetEvolutiontById(id);
            if (evolution == null)
            {
                return NotFound();
            }
            await _evolutionRepository.DeleteEvolution(id);
            return Ok(evolution);
        }
    }
}
