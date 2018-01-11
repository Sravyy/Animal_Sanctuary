using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Animal_Sanctuary.Models
{
    public class Veterinarian
    {
        [Key]
        public int VeterinarianId { get; set; }
        public string Name { get; set; }
        public string Specialty { get; set; }
        public virtual ICollection<Animal> Animals { get; set; }


        public override bool Equals(System.Object otherVeterinarian)
        {
            if (!(otherVeterinarian is Veterinarian))
            {
                return false;
            }
            else
            {
                Veterinarian newVeterinarian = (Veterinarian)otherVeterinarian;
                bool EqualId = this.VeterinarianId.Equals(newVeterinarian.VeterinarianId);
                bool EqualName = this.Name.Equals(newVeterinarian.Name);
                bool specialty = this.Specialty.Equals(newVeterinarian.Specialty);
               

                return (EqualId && EqualName && specialty );
            }
        }

        public override int GetHashCode()
        {
            return this.VeterinarianId.GetHashCode();
        }
    }
}