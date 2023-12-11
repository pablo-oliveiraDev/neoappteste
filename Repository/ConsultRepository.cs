using csharp_docker_postgree_api.Data;
using csharp_docker_postgree_api.Interfaces;
using csharp_docker_postgree_api.Models;
using Microsoft.EntityFrameworkCore;

namespace csharp_docker_postgree_api.Repository
{
    public class ConsultRepository : IConsultRepository
    {
        private readonly UserContext _context;

        public ConsultRepository(UserContext context)
        {
            _context = context;
        }
        public async Task<List<Consult>> GetAllConsult()
        {
            return await _context.Consult.ToListAsync();
        }

        public async Task<Consult> GetConsultById(int id)
        {
            return await _context.Consult.Include(c => c.Patient).Include(c => c.Doctor).FirstOrDefaultAsync(c => c.ConsultId == id);
        }
        public async Task<Consult> CreateConsult(Consult request)
        {
            _context.Consult.Add(request);
            await _context.SaveChangesAsync();
            return request;
        }
        public async Task<Consult> UpdateConsult(int id, Consult request)
        {
            var existsConsult = await _context.Consult.FindAsync(id);
            if (existsConsult == null)
            {
                throw new Exception("Consult do not found!");
            }
            existsConsult.DateOfConsult = DateTime.Now;
            existsConsult.PatientId = request.PatientId;
            existsConsult.DoctorId = request.DoctorId;
            await _context.SaveChangesAsync();
            return existsConsult;
        }

        public async Task<Consult> DeleteConsult(int id)
        {
            var consult = await _context.Consult.FindAsync(id);
            if (consult == null)
            {
                throw new Exception("Consult do not found");

            }
            _context.Remove(consult);
            await _context.SaveChangesAsync();

            return consult;
        }

    }
}
