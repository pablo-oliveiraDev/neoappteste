using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace csharp_docker_postgree_api.Models
{
    public class Prescription
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PrescriptionId { get; set; }
        public string Medicinals { get; set; }
        public string Dosgae { get; set; }
        public string Instructions { get; set; }
        [ForeignKey(nameof(ConsultId))]
        public int ConsultId { get; set; }
        [JsonIgnore]
        public virtual Consult? Consult { get; set; }

    }
}
