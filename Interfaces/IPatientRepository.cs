using csharp_docker_postgree_api.Models;

namespace csharp_docker_postgree_api.Interfaces
{
    public interface IPatientRepository
    {
        Task<List<Patient>> GetAllPatient();
        Task<Patient> GetPatientById(int id);
        Task<Patient> CreatePatient(Patient request);
        Task<Patient> UpdatePatient(int id, Patient request);
        Task<Patient> DeletePatient(int id);
    }
}
