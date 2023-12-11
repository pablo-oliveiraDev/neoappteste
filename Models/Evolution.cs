using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace csharp_docker_postgree_api.Models
{
    public class Evolution
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EvollutionId { get; set; }
        public string DescribeEvolution { get; set; }
        [ForeignKey(nameof(ConsultId))]
        public int ConsultId { get; set; }
        [JsonIgnore]
        public virtual Consult? Consult { get; set; }
    }
}
