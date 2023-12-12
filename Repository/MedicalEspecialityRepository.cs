using csharp_docker_postgree_api.Data;
using csharp_docker_postgree_api.Interfaces;
using csharp_docker_postgree_api.Models;
using Microsoft.EntityFrameworkCore;

namespace csharp_docker_postgree_api.Repository
{
    public class MedicalEspecialityRepository : IMedicalEspecialityRepository
    {
        private readonly UserContext _context;

        public MedicalEspecialityRepository(UserContext context)
        {
            _context = context;
        }
        public async Task<List<MedicalEspeciality>> GetAllMedicalEspeciality()
        {
            return await _context.MedicalEspeciality.ToListAsync();
        }

        public async Task<MedicalEspeciality> GetMedicalEspecialityById(int id)
        {
            return await _context.MedicalEspeciality.FindAsync(id);
        }
        public async Task<MedicalEspeciality> CreateMedicalEspeciality(MedicalEspeciality request)
        {
            _context.MedicalEspeciality.Add(request);
            await _context.SaveChangesAsync();
            return request;
        }
        public async Task<MedicalEspeciality> UpdateMedicalEspeciality(int id, MedicalEspeciality request)
        {
            var existsMedicalEspeciality = await _context.MedicalEspeciality.FindAsync(id);
            if (existsMedicalEspeciality == null)
            {
                throw new Exception("MedicalEspeciality do not found!");
            }
           
            await _context.SaveChangesAsync();
            return existsMedicalEspeciality;
        }

        public async Task<MedicalEspeciality> DeleteMedicalEspeciality(int id)
        {
            var medicalEspeciality = await _context.MedicalEspeciality.FindAsync(id);
            if (medicalEspeciality == null)
            {
                throw new Exception("MedicalEspeciality do not found");

            }
            _context.Remove(medicalEspeciality);
            await _context.SaveChangesAsync();

            return medicalEspeciality;
        }
    }
}
