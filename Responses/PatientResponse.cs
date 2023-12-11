namespace csharp_docker_postgree_api.Responses
{
    public class PatientResponse
    {
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public float Weigth { get; set; }
    }
}
