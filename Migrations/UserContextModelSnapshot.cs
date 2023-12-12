﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using csharp_docker_postgree_api.Data;

#nullable disable

namespace csharp_docker_postgree_api.Migrations
{
    [DbContext(typeof(UserContext))]
    partial class UserContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("csharp_docker_postgree_api.Models.Consult", b =>
                {
                    b.Property<int>("ConsultId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ConsultId"));

                    b.Property<DateTime>("DateOfConsult")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Disease")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("DoctorId")
                        .HasColumnType("integer");

                    b.Property<int>("PatientId")
                        .HasColumnType("integer");

                    b.Property<string>("Sympytpms")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ConsultId");

                    b.HasIndex("DoctorId");

                    b.HasIndex("PatientId");

                    b.ToTable("Consult");
                });

            modelBuilder.Entity("csharp_docker_postgree_api.Models.Doctor", b =>
                {
                    b.Property<int>("DoctorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("DoctorId"));

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CRM")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("DoctorName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("EspecialityId")
                        .HasColumnType("integer");

                    b.Property<int?>("MedicalEspecialityEspecialityId")
                        .HasColumnType("integer");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("DoctorId");

                    b.HasIndex("MedicalEspecialityEspecialityId");

                    b.ToTable("Doctor");
                });

            modelBuilder.Entity("csharp_docker_postgree_api.Models.Evolution", b =>
                {
                    b.Property<int>("EvollutionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("EvollutionId"));

                    b.Property<int>("ConsultId")
                        .HasColumnType("integer");

                    b.Property<string>("DescribeEvolution")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("EvollutionId");

                    b.HasIndex("ConsultId");

                    b.ToTable("Evolution");
                });

            modelBuilder.Entity("csharp_docker_postgree_api.Models.MedicalEspeciality", b =>
                {
                    b.Property<int>("EspecialityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("EspecialityId"));

                    b.Property<string>("EspecialityName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("EspecialityId");

                    b.ToTable("MedicalEspeciality");
                });

            modelBuilder.Entity("csharp_docker_postgree_api.Models.Patient", b =>
                {
                    b.Property<int>("PatientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("PatientId"));

                    b.Property<int>("Age")
                        .HasColumnType("integer");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PatientName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<float>("Weigth")
                        .HasColumnType("real");

                    b.HasKey("PatientId");

                    b.ToTable("Patient");
                });

            modelBuilder.Entity("csharp_docker_postgree_api.Models.Prescription", b =>
                {
                    b.Property<int>("PrescriptionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("PrescriptionId"));

                    b.Property<int>("ConsultId")
                        .HasColumnType("integer");

                    b.Property<string>("Dosgae")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Instructions")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Medicinals")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("PrescriptionId");

                    b.HasIndex("ConsultId");

                    b.ToTable("Prescription");
                });

            modelBuilder.Entity("csharp_docker_postgree_api.Models.Consult", b =>
                {
                    b.HasOne("csharp_docker_postgree_api.Models.Doctor", "Doctor")
                        .WithMany()
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("csharp_docker_postgree_api.Models.Patient", "Patient")
                        .WithMany("Consult")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("csharp_docker_postgree_api.Models.Doctor", b =>
                {
                    b.HasOne("csharp_docker_postgree_api.Models.MedicalEspeciality", "MedicalEspeciality")
                        .WithMany()
                        .HasForeignKey("MedicalEspecialityEspecialityId");

                    b.Navigation("MedicalEspeciality");
                });

            modelBuilder.Entity("csharp_docker_postgree_api.Models.Evolution", b =>
                {
                    b.HasOne("csharp_docker_postgree_api.Models.Consult", "Consult")
                        .WithMany()
                        .HasForeignKey("ConsultId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Consult");
                });

            modelBuilder.Entity("csharp_docker_postgree_api.Models.Prescription", b =>
                {
                    b.HasOne("csharp_docker_postgree_api.Models.Consult", "Consult")
                        .WithMany()
                        .HasForeignKey("ConsultId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Consult");
                });

            modelBuilder.Entity("csharp_docker_postgree_api.Models.Patient", b =>
                {
                    b.Navigation("Consult");
                });
#pragma warning restore 612, 618
        }
    }
}
