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
        public string DoctorName { get; set;}      
        public string CRM {  get; set;}
        [ForeignKey(nameof(EspecialityId))]
        public int EspecialityId { get; set; }
        [JsonIgnore]
        public virtual MedicalEspeciality? MedicalEspeciality { get; set;}
    }
}
