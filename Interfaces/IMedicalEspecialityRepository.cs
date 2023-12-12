using csharp_docker_postgree_api.Models;

namespace csharp_docker_postgree_api.Interfaces
{
    public interface IMedicalEspecialityRepository
    {
        Task<List<MedicalEspeciality>> GetAllMedicalEspeciality();
        Task<MedicalEspeciality> GetMedicalEspecialityById(int id);
        Task<MedicalEspeciality> CreateMedicalEspeciality(MedicalEspeciality request);
        Task<MedicalEspeciality> UpdateMedicalEspeciality(int id, MedicalEspeciality request);
        Task<MedicalEspeciality> DeleteMedicalEspeciality(int id);
    }
}
