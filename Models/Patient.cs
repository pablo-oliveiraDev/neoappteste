using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace csharp_docker_postgree_api.Models
{
    public class Patient
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PatientId { get; set; }
        [Required(ErrorMessage = "The patient's name is mandatory.")]
        public string PatientName { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public float Weigth { get; set; }
        [JsonIgnore]
        public virtual ICollection<Consult>? Consult { get; set; } 
    }
}
