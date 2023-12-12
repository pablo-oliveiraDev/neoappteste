using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace csharp_docker_postgree_api.ViewModel
{
    public class LoginViewModel
    {
        [Required]
        public string CPF { get; set; }
        [Required]
        public string Password { get; set; }
        [JsonIgnore]
        public string? UserType { get; set; } // "Doctor" ou "Patient"
    }
}
