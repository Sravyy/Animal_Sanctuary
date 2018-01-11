using Microsoft.VisualStudio.TestTools.UnitTesting;
using Animal_Sanctuary.Models;
using Moq;

namespace Animal_Sanctuary.Tests
{

    [TestClass]
    public class AnimalControllerTests
    {
        [TestMethod]
        public void GetName_ReturnsVeterinarianName_String()
        {
            //Arrange
            var veterinarian = new Veterinarian();


            //Act
            var result = veterinarian.Name = "chacko";

            //Assert
            Assert.AreEqual("chacko", result);
        }

        [TestMethod]
        public void GetSpecialty_ReturnsVeterinarianSpecialty_String()
        {
            //Arrange
            var veterinarian = new Veterinarian();


            //Act
            var result = veterinarian.Specialty = "animal Welfare";

            //Assert
            Assert.AreEqual("animal Welfare", result);
        }


    }

    }