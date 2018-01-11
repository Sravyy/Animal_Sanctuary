using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Animal_Sanctuary.Models.Repositories
{
    public class EFVeterinarianRepository : IVeterinarianRepository
    {
        AnimalSanctuaryDbContext db = new AnimalSanctuaryDbContext();



        public IQueryable<Veterinarian> Veterinarians 
        { get { return db.Veterinarians; } }

        public Veterinarian Edit(Veterinarian veterinarian)
        {
            db.Entry(veterinarian).State = EntityState.Modified;
            db.SaveChanges();
            return veterinarian;
        }

        public void Remove(Veterinarian veterinarian)
        {
            db.Veterinarians.Remove(veterinarian);
            db.SaveChanges();
        }

        public Veterinarian Save(Veterinarian veterinarian)
        {
            db.Veterinarians.Add(veterinarian);
            db.SaveChanges();
            return veterinarian;
        }
    }
}
