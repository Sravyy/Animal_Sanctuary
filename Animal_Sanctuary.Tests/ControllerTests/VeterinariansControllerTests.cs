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
    public class VeterinariansControllerTests
    {
        Mock<IVeterinarianRepository> mock = new Mock<IVeterinarianRepository>();

            private void DbSetup()
            {
            mock.Setup(m => m.Veterinarians).Returns(new Veterinarian[]
            {
                new Veterinarian {VeterinarianId = 1, Name = "Jhon" , Specialty = "petCare" },
                new Veterinarian { VeterinarianId = 2, Name = "Pop", Specialty = "environmental" },
                new Veterinarian {VeterinarianId = 3, Name = "Dan" , Specialty = "disorder"}
                }.AsQueryable());
            }

        [TestMethod]
        public void Mock_GetViewResultIndex_ActionResult() // Confirms route returns view
        {
            //Arrange
            DbSetup();
            VeterinariansController controller = new VeterinariansController(mock.Object);

            //Act
            var result = controller.Index();

            //Assert
            Assert.IsInstanceOfType(result, typeof(ActionResult));
        }

        [ TestMethod]
        public void Mock_IndexContainsModelData_List() // Confirms model as list of veterns
        {
            // Arrange
            DbSetup();
            ViewResult indexView = new VeterinariansController(mock.Object).Index() as ViewResult;

            // Act
            var result = indexView.ViewData.Model;

            // Assert
            Assert.IsInstanceOfType(result, typeof(List<Veterinarian>));
        }

        [TestMethod]
        public void Mock_IndexModelContainsAnimals_Collection() // Confirms presence of known entry
        {
            // Arrange
            DbSetup();
            VeterinariansController controller = new VeterinariansController(mock.Object);
            Veterinarian testVeterinarian = new Veterinarian();
            testVeterinarian.Name = "Jhon";
            testVeterinarian.VeterinarianId = 1;
            testVeterinarian.Specialty = "petCare";

            // Act
            ViewResult indexView = controller.Index() as ViewResult;
            List<Veterinarian> collection = indexView.ViewData.Model as List<Veterinarian>;

            // Assert
            CollectionAssert.Contains(collection, testVeterinarian);
        }




        [TestMethod]
        public void Mock_PostViewResultCreate_ViewResult()
        {
            // Arrange
            Veterinarian testVeterinarian = new Veterinarian
            {   
                VeterinarianId = 1,
                Name = "Jhon"
            };

            DbSetup();
            VeterinariansController controller = new VeterinariansController(mock.Object);

            // Act
            var resultView = controller.Create(testVeterinarian) as ViewResult;


            // Assert
            Assert.IsInstanceOfType(resultView, typeof(ViewResult));

        }


        [TestMethod]
        public void Mock_GetDetails_ReturnsView()
        {
            // Arrange
            Veterinarian testVeterinarian = new Veterinarian
            {
                VeterinarianId = 4,
                Name = "donkey"
            };

            DbSetup();
            VeterinariansController controller = new VeterinariansController(mock.Object);

            // Act
            var resultView = controller.Details(testVeterinarian.VeterinarianId) as ViewResult;
            var model = resultView.ViewData.Model as Veterinarian;

            // Assert
            Assert.IsInstanceOfType(resultView, typeof(ViewResult));
            Assert.IsInstanceOfType(model, typeof(Veterinarian));
        }


    }

 }

