using Microsoft.VisualStudio.TestTools.UnitTesting;
using Animal_Sanctuary.Models;

namespace Animal_Sanctuary.Tests
{
    [TestClass]
    public class AnimalTests
    {
        [TestMethod]
        public void GetName_ReturnsAnimalName_String()
        {
            //Arrange
            var animal = new Animal();


            //Act
            var result = animal.Name = "dog";

            //Assert
            Assert.AreEqual("dog", result);
        }

        [TestMethod]
        public void GetSpecies_ReturnsAnimalSpecies_String()
        {
            //Arrange
            var animal = new Animal();


            //Act
            var result = animal.Species = "carnivore";

            //Assert
            Assert.AreEqual("carnivore", result);
        }

        [TestMethod]
        public void GetSex_ReturnsAnimalSex_String()
        {
            //Arrange
            var animal = new Animal();


            //Act
            var result = animal.Sex = "male";

            //Assert
            Assert.AreEqual("male", result);
        }

        [TestMethod]
        public void GetHabitatType_ReturnsAnimalHabitatType_String()
        {
            //Arrange
            var animal = new Animal();


            //Act
            var result = animal.HabitatType = "grassland";

            //Assert
            Assert.AreEqual("grassland", result);
        }

        [TestMethod]
        public void GetMedicalEmergency_ReturnsAnimalMedicalEmergency_String()
        {
            //Arrange
            var animal = new Animal();


            //Act
            var result = animal.MedicalEmergency = true;

            //Assert
            Assert.AreEqual(true, result);
        }
    }
}