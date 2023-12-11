using csharp_docker_postgree_api.Data;
using csharp_docker_postgree_api.Interfaces;
using csharp_docker_postgree_api.Models;
using Microsoft.EntityFrameworkCore;

namespace csharp_docker_postgree_api.Repository
{
    public class EvolutionRepository : IEvolutionRepository
    {
        private readonly UserContext _context;

        public EvolutionRepository(UserContext context)
        {
            _context = context;
        }
        public async Task<List<Evolution>> GetAllEvolution()
        {
            return await _context.Evolution.ToListAsync();
        }

        public async Task<Evolution> GetEvolutiontById(int id)
        {
            return await _context.Evolution.FindAsync(id);
        }
        public async Task<Evolution> CreateEvolution(Evolution request)
        {
            _context.Evolution.Add(request);
            await _context.SaveChangesAsync();
            return request;
        }
        public async Task<Evolution> UpdateEvolution(int id, Evolution request)
        {
            var existsEvolution = await _context.Evolution.FindAsync(id);
            if (existsEvolution == null)
            {
                throw new Exception("Evolution do not found!");
            }
            existsEvolution.DescribeEvolution = request.DescribeEvolution;
            existsEvolution.ConsultId = request.ConsultId;
            await _context.SaveChangesAsync();
            return existsEvolution;
        }

        public async Task<Evolution> DeleteEvolution(int id)
        {
            var evolution = await _context.Evolution.FindAsync(id);
            if (evolution == null)
            {
                throw new Exception("Evolution do not found");

            }
            _context.Remove(evolution);
            await _context.SaveChangesAsync();

            return evolution;
        }

    }
}
