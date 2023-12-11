using csharp_docker_postgree_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace csharp_docker_postgree_api.Interfaces
{
    public interface IConsultRepository
    {
        Task<List<Consult>> GetAllConsult();
        Task<Consult> GetConsultById(int id);
        Task<Consult> CreateConsult(Consult request);
        Task<Consult> UpdateConsult(int id, Consult request);
        Task<Consult> DeleteConsult(int id);
    }
}
