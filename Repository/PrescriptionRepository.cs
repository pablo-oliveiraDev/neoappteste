using csharp_docker_postgree_api.Data;
using csharp_docker_postgree_api.Interfaces;
using csharp_docker_postgree_api.Models;
using Microsoft.EntityFrameworkCore;

namespace csharp_docker_postgree_api.Repository
{
    public class PrescriptionRepository : IPrescriptionRepository
    {
        private readonly UserContext _context;

        public PrescriptionRepository(UserContext context)
        {
            _context = context;
        }
        public async Task<List<Prescription>> GetAllPrescription()
        { 
            return await _context.Prescription.ToListAsync();
        }

        public async Task<Prescription> GetPrescriptionById(int id)
        {
            return await _context.Prescription.FindAsync(id);
        }
        public async Task<Prescription> CreatePrescription(Prescription request)
        {
            _context.Prescription.Add(request);
            await _context.SaveChangesAsync();
            return request;
        }
        public async Task<Prescription> UpdatePrescription(int id, Prescription request)
        {
            var existsPrescription = await _context.Prescription.FindAsync(id);
            if (existsPrescription == null)
            {
                throw new Exception("Prescription do not found!");
            }
            existsPrescription.Instructions=request.Instructions;
            existsPrescription.Medicinals=request.Medicinals;
            existsPrescription.Dosgae=request.Dosgae;
            existsPrescription.ConsultId=request.ConsultId;

            await _context.SaveChangesAsync();
            return existsPrescription;
        }

        public async Task<Prescription> DeletePrescription(int id)
        {
            var prescription = await _context.Prescription.FindAsync(id);
            if (prescription == null)
            {
                throw new Exception("Prescription do not found");

            }
            _context.Remove(prescription);
            await _context.SaveChangesAsync();

            return prescription;
        }
    }
}
