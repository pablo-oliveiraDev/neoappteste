using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace csharp_docker_postgree_api.Models
{
    public class MedicalEspeciality
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EspecialityId { get; set; }
        public string EspecialityName { get; set; }

    }
}
