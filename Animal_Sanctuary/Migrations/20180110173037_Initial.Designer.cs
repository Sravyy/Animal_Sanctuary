using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Animal_Sanctuary.Models;

namespace Animal_Sanctuary.Migrations
{
    [DbContext(typeof(AnimalSanctuaryDbContext))]
    [Migration("20180110173037_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2");

            modelBuilder.Entity("Animal_Sanctuary.Models.Animal", b =>
                {
                    b.Property<int>("AnimalId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("HabitatType");

                    b.Property<bool>("MedicalEmergency");

                    b.Property<string>("Name");

                    b.Property<string>("Sex");

                    b.Property<string>("Species");

                    b.Property<int>("VeterinarianId");

                    b.HasKey("AnimalId");

                    b.HasIndex("VeterinarianId");

                    b.ToTable("Animals");
                });

            modelBuilder.Entity("Animal_Sanctuary.Models.Veterinarian", b =>
                {
                    b.Property<int>("VeterinarianId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<string>("Specialty");

                    b.HasKey("VeterinarianId");

                    b.ToTable("Veterinarians");
                });

            modelBuilder.Entity("Animal_Sanctuary.Models.Animal", b =>
                {
                    b.HasOne("Animal_Sanctuary.Models.Veterinarian", "Veterinarian")
                        .WithMany("Animals")
                        .HasForeignKey("VeterinarianId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
