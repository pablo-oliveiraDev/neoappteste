using csharp_docker_postgree_api.Data;
using csharp_docker_postgree_api.Interfaces;
using csharp_docker_postgree_api.Models;
using Microsoft.EntityFrameworkCore;


namespace csharp_docker_postgree_api.Repository
{
    public class PatientRepository : IPatientRepository
    {
        private readonly UserContext _context;

        public PatientRepository(UserContext context)
        {
            _context = context;
        }
        public async Task<List<Patient>> GetAllPatient()
        {
            return await _context.Patient.ToListAsync();

        }

        public async Task<Patient> GetPatientById(int id)
        {
            return await _context.Patient.FindAsync(id);
        }
        public async Task<Patient> CreatePatient(Patient patient)
        {
            patient.Consult = null;
          
            _context.Patient.Add(patient);
            await _context.SaveChangesAsync();
            return patient;
        }

        public async Task<Patient> UpdatePatient(int id, Patient request)
        {
            var exitsPatient = await _context.Patient.FindAsync(id);
            if (exitsPatient == null)
            {
                throw new Exception("Patient do not found!");
            }
            exitsPatient.PatientName = request.PatientName;
            exitsPatient.Age = request.Age;
            exitsPatient.Gender = request.Gender;
            exitsPatient.DateOfBirth = request.DateOfBirth;
            exitsPatient.Weigth = request.Weigth;
            await _context.SaveChangesAsync();
            return exitsPatient;
        }


        public async Task<Patient> DeletePatient(int id)
        {
            var patient = await _context.Patient.FindAsync(id);
            if (patient == null)
            {
                throw new Exception("Patient do not Found!");
            }
            _context.Remove(patient);
            await _context.SaveChangesAsync();

            return patient;
        }

      
    }
}
