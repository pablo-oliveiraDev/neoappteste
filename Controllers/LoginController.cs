using csharp_docker_postgree_api.Data;
using csharp_docker_postgree_api.Interfaces;
using csharp_docker_postgree_api.ViewModel;
using Microsoft.AspNetCore.Http;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace csharp_docker_postgree_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private readonly IAuthRepository _authRepository;
        private readonly UserContext _context;

        public LoginController(IAuthRepository authRepository, UserContext context)
        {
            _authRepository = authRepository;
            _context = context;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel model)
        {
            //derterminado se doctor ou patient 
            var doctor = _context.Doctor.FirstOrDefault(d => d.CPF == model.CPF);
            var patient = _context.Patient.FirstOrDefault(p => p.CPF == model.CPF);
            //verifica se o user e Doctor
            if (doctor != null && doctor.Password == model.Password)
            {
                model.CPF = doctor.CPF;
                model.Password = doctor.Password;
                model.UserType = "Doctor";

                var token = _authRepository.GerarTokenJwt(doctor, model.UserType);
                return Ok(new { Token = token, UserType = model.UserType });
            }//verifica se o user e patient
            else if (patient != null && patient.Password == model.Password)
            {
                model.CPF = patient.CPF;
                model.Password = patient.Password;
                model.UserType = "Patient";

                var token =_authRepository.GerarTokenJwt(patient, model.UserType);
                return Ok(new { Token = token, UserType = model.UserType });
            }          
                return Unauthorized("Invalid credentials");
            
        }
    }
}
