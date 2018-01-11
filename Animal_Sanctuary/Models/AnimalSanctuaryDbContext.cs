using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

namespace Animal_Sanctuary.Models
{
    public class AnimalSanctuaryDbContext : DbContext
    {
        public AnimalSanctuaryDbContext()
        {
        }

        public DbSet<Veterinarian> Veterinarians { get; set; }

        public DbSet<Animal> Animals { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseMySql(@"Server=localhost;Port=8889;database=animalSanc;uid=root;pwd=root;");
        }

        public AnimalSanctuaryDbContext(DbContextOptions<AnimalSanctuaryDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

    }
}
