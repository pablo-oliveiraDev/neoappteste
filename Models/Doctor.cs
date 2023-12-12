using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace csharp_docker_postgree_api.Models
{
    public class Doctor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DoctorId { get; set; }
        [Required(ErrorMessage = "The DoctorName is mandatory!")]
        public string DoctorName { get; set;}
        [Required(ErrorMessage = "The CRM is mandatory!")]
        public string CRM {  get; set;}
        [Required(ErrorMessage = "The CPF is mandatory!")]
        public string CPF { get; set;}
        [Required(ErrorMessage = "The Password is mandatory!")]
        public string Password { get; set;}
        [ForeignKey(nameof(EspecialityId))]
        public int EspecialityId { get; set; }
        [JsonIgnore]
        public virtual MedicalEspeciality? MedicalEspeciality { get; set;}
       
    }
}
