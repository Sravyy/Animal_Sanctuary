using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Animal_Sanctuary.Models;
using Animal_Sanctuary.Controllers;
using System.Linq;
using Animal_Sanctuary.Models.Repositories;

namespace Animal_Sanctuary.Tests.ControllerTests
{
    [TestClass]
    public class AnimalsControllerTests
    {
            Mock<IAnimalRepository> mock = new Mock<IAnimalRepository>();

            private void DbSetup()
            {
            mock.Setup(m => m.Animals).Returns(new Animal[]
            {
                new Animal {AnimalId = 1, Name = "dog" , Species = "carnivore",Sex = "male",HabitatType = "land",MedicalEmergency = true },
            new Animal { AnimalId = 2, Name = "cat", Species = "herbivore", Sex = "female", HabitatType = "forest", MedicalEmergency = false },
                new Animal {AnimalId = 3, Name = "cow" , Species = "herbivore",Sex = "female",HabitatType = "home",MedicalEmergency = true}
                }.AsQueryable());
            }

        [TestMethod]
        public void Mock_GetViewResultIndex_ActionResult() // Confirms route returns view
        {
            //Arrange
            DbSetup();
            AnimalsController controller = new AnimalsController(mock.Object);

            //Act
            var result = controller.Index();

            //Assert
            Assert.IsInstanceOfType(result, typeof(ActionResult));
        }




















        }
}
