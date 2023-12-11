using csharp_docker_postgree_api.Models;

namespace csharp_docker_postgree_api.Interfaces
{
    public interface IEvolutionRepository
    {
        Task<List<Evolution>> GetAllEvolution();
        Task<Evolution> GetEvolutiontById(int id);
        Task<Evolution> CreateEvolution(Evolution request);
        Task<Evolution> UpdateEvolution(int id, Evolution request);
        Task<Evolution> DeleteEvolution(int id);
    }
}
