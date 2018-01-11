using System.ComponentModel.DataAnnotations;


namespace Animal_Sanctuary.Models
{
    public class Animal
    {
        [Key]
        public int AnimalId { get; set; }
        public string Name { get; set; }
        public string Species { get; set; }
        public string Sex { get; set; }
        public string HabitatType { get; set; }
        public bool MedicalEmergency { get; set; }
        public int VeterinarianId { get; set; }
        public virtual Veterinarian Veterinarian { get; set; }


        public override bool Equals(System.Object otherAnimal)
        {
            if (!(otherAnimal is Animal))
            {
                return false;
            }
            else
            {
                Animal newAnimal = (Animal)otherAnimal;
                bool EqualId = this.AnimalId.Equals(newAnimal.AnimalId);
                bool EqualName = this.Name.Equals(newAnimal.Name);
                bool species = this.Species.Equals(newAnimal.Species);
                bool sex = this.Sex.Equals(newAnimal.Sex);
                bool habitype = this.HabitatType.Equals(newAnimal.HabitatType);
                bool medi = this.MedicalEmergency.Equals(newAnimal.MedicalEmergency);
                bool veternId = this.VeterinarianId.Equals(newAnimal.VeterinarianId);
             

                return (EqualId && EqualName && species && sex && habitype && medi && veternId);
            }
        }

        public override int GetHashCode()
        {
            return this.AnimalId.GetHashCode();
        }
    }
}