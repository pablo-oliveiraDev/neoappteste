using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace csharp_docker_postgree_api.Models
{
    public class Consult
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ConsultId { get; set; }
        [Required(ErrorMessage = "The consult date is mandatory.")]
        public DateTime DateOfConsult { get; set; }
        public string Sympytpms { get; set; }
        public string Disease { get; set; }
            
        [ForeignKey(nameof(PatientId))]
        public int PatientId { get; set; }
        [JsonIgnore]
        public virtual Patient? Patient { get; set; }
        [ForeignKey(nameof(DoctorId))]
        public int DoctorId { get; set; }
        [JsonIgnore]
        public virtual Doctor? Doctor { get; set; }
    }
}
