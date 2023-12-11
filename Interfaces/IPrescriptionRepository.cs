using csharp_docker_postgree_api.Models;

namespace csharp_docker_postgree_api.Interfaces
{
    public interface IPrescriptionRepository
    {
        Task<List<Prescription>> GetAllPrescription();
        Task<Prescription> GetPrescriptionById(int id);
        Task<Prescription> CreatePrescription(Prescription request);
        Task<Prescription> UpdatePrescription(int id, Prescription request);
        Task<Prescription> DeletePrescription(int id);
    }
}
