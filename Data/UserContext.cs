using Microsoft.EntityFrameworkCore;
using csharp_docker_postgree_api.Models;



namespace csharp_docker_postgree_api.Data;

public class UserContext : DbContext
{
    public UserContext(DbContextOptions<UserContext> options) : base(options)
    {
       
       
    }

    public DbSet<Patient> Patient { get; set; }
    public DbSet<Doctor> Doctor { get; set; }
    public DbSet<MedicalEspeciality> MedicalEspeciality { get; set; }
    public DbSet<Consult> Consult { get; set; }
    public DbSet<Evolution> Evolution { get; set; }
    public DbSet<Prescription> Prescription { get; set; }   

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

    }

}




