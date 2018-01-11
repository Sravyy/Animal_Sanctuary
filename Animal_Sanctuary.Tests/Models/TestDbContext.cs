using System;
using Animal_Sanctuary.Models;
using Microsoft.EntityFrameworkCore;

namespace Animal_Sanctuary.Tests.Models
{
    public class TestDbContext : AnimalSanctuaryDbContext
    {
        public override DbSet<Animal> Animals { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseMySql(@"Server=localhost;port=8889;database=animalSanc_test;uid=root;pwd=root;");
        }

    }
}
