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

        [ TestMethod]
        public void Mock_IndexContainsModelData_List() // Confirms model as list of items
        {
            // Arrange
            DbSetup();
            ViewResult indexView = new AnimalsController(mock.Object).Index() as ViewResult;

            // Act
            var result = indexView.ViewData.Model;

            // Assert
            Assert.IsInstanceOfType(result, typeof(List<Animal>));
        }

        [TestMethod]
        public void Mock_IndexModelContainsAnimals_Collection() // Confirms presence of known entry
        {
            // Arrange
            DbSetup();
            AnimalsController controller = new AnimalsController(mock.Object);
            Animal testAnimal = new Animal();
            testAnimal.Name = "cow";
            testAnimal.AnimalId = 3;
            testAnimal.Species = "herbivore";testAnimal.Sex = "female";testAnimal.HabitatType = "home";testAnimal.MedicalEmergency = true;
         

            // Act
            ViewResult indexView = controller.Index() as ViewResult;
            List<Animal> collection = indexView.ViewData.Model as List<Animal>;

            // Assert
            CollectionAssert.Contains(collection, testAnimal);
        }



        [TestMethod]
        public void Mock_IndexModelDoesNotContainsAnimals_Collection() // Confirms presence of unknown entry - should fail
        {
            // Arrange
            DbSetup();
            AnimalsController controller = new AnimalsController(mock.Object);
            Animal testAnimal = new Animal();
            testAnimal.Name = "cow";
            testAnimal.AnimalId = 3;
            testAnimal.Species = "herbivorsdasde"; testAnimal.Sex = "female"; testAnimal.HabitatType = "home"; testAnimal.MedicalEmergency = true;


            // Act
            ViewResult indexView = controller.Index() as ViewResult;
            List<Animal> collection = indexView.ViewData.Model as List<Animal>;

            // Assert
            CollectionAssert.Contains(collection, testAnimal);
        }


        [TestMethod]
        public void Mock_PostViewResultCreate_ViewResult()
        {
            // Arrange
            Animal testAnimal = new Animal
            {   
                AnimalId = 1,
                Name = "mew"
            };

            DbSetup();
            AnimalsController controller = new AnimalsController(mock.Object);

            // Act
            var resultView = controller.Create(testAnimal) as ViewResult;


            // Assert
            Assert.IsInstanceOfType(resultView, typeof(ViewResult));

        }


        [TestMethod]
        public void Mock_GetDetails_ReturnsView()
        {
            // Arrange
            Animal testAnimal = new Animal
            {
                AnimalId = 4,
                Name = "donkey"
            };

            DbSetup();
            AnimalsController controller = new AnimalsController(mock.Object);

            // Act
            var resultView = controller.Details(testAnimal.AnimalId) as ViewResult;
            var model = resultView.ViewData.Model as Animal;

            // Assert
            Assert.IsInstanceOfType(resultView, typeof(ViewResult));
            Assert.IsInstanceOfType(model, typeof(Animal));
        }


    }

 }

