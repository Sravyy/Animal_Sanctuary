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
    }
}