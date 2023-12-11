using csharp_docker_postgree_api.Data;
using csharp_docker_postgree_api.Interfaces;
using csharp_docker_postgree_api.Models;
using Microsoft.EntityFrameworkCore;

namespace csharp_docker_postgree_api.Repository
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly UserContext _context;

        public DoctorRepository(UserContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Doctor>> GetAllDoctorsAsync()
        {
            return await _context.Doctor.ToListAsync();
        }

        public async Task<Doctor> GetDoctorByIdAsync(int doctorId)
        {
            return await _context.Doctor.FindAsync(doctorId);
        }

        public async Task<Doctor> AddDoctorAsync(Doctor doctor)
        {
            _context.Doctor.Add(doctor);
            await _context.SaveChangesAsync();
            return doctor;
        }

        public async Task<Doctor> UpdateDoctorAsync(int id, Doctor doctor)
        {
            var existsDoctor = await _context.Doctor.FindAsync(id);
            if (existsDoctor == null)
            {
                throw new Exception("Patient do not found!");
            }
            existsDoctor.DoctorName = doctor.DoctorName;
            existsDoctor.CRM = doctor.CRM;
            existsDoctor.EspecialityId = doctor.EspecialityId;

            if (existsDoctor.EspecialityId == null)
            {
                throw new Exception("Especiality not exists!\nTry again!");
            }

            await _context.SaveChangesAsync();
            return existsDoctor;
        }
        public async Task<Doctor> DeleteDoctorAsync(int doctorId)
        {
            var existsDoctor = await _context.Doctor.FindAsync(doctorId);
            if (existsDoctor == null)
            {
                throw new Exception("Doctor do not found!");
            }
            await _context.SaveChangesAsync();
            return existsDoctor;
        }
    }
}
