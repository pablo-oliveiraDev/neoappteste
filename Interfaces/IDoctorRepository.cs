using csharp_docker_postgree_api.Models;

namespace csharp_docker_postgree_api.Interfaces
{
    public interface IDoctorRepository
    {
        Task<IEnumerable<Doctor>> GetAllDoctorsAsync();
        Task<Doctor> GetDoctorByIdAsync(int doctorId);
        Task<Doctor> AddDoctorAsync(Doctor doctor);
        Task<Doctor> UpdateDoctorAsync(int id, Doctor doctor);
        Task<Doctor> DeleteDoctorAsync(int doctorId);
    }
}
