using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Animal_Sanctuary.Models.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Animal_Sanctuary.Models;

namespace Animal_Sanctuary.Controllers
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class VeterinariansController : Controller
    {
        private IVeterinarianRepository veternRepo;  // New!

        public VeterinariansController(IVeterinarianRepository repo = null)
        {
            if (repo == null)
            {
                this.veternRepo = new EFVeterinarianRepository();
            }
            else
            {
                this.veternRepo = repo;
            }
        }

        public ViewResult Index()
        {
            // Updated:
            return View(veternRepo.Veterinarians.ToList());
        }

        public IActionResult Details(int id)
        {
            // Updated:
            Veterinarian thisVeterinarian = veternRepo.Veterinarians.FirstOrDefault(x => x.VeterinarianId == id);
            return View(thisVeterinarian);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Veterinarian veterinarian)
        {
            veternRepo.Save(veterinarian);   // Updated
            // Removed db.SaveChanges() call
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            // Updated:
            Veterinarian thisVeterinarian = veternRepo.Veterinarians.FirstOrDefault(x => x.VeterinarianId == id);
            return View(thisVeterinarian);
        }

        [HttpPost]
        public IActionResult Edit(Veterinarian veterinarian)
        {
            veternRepo.Edit(veterinarian);   // Updated!
            // Removed db.SaveChanges() call
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            // Updated:
            Veterinarian thisVeterinarian = veternRepo.Veterinarians.FirstOrDefault(x => x.VeterinarianId == id);
            return View(thisVeterinarian);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            // Updated:
            Veterinarian thisVeterinarian = veternRepo.Veterinarians.FirstOrDefault(x => x.VeterinarianId == id);
            veternRepo.Remove(thisVeterinarian);   // Updated!
            // Removed db.SaveChanges() call
            return RedirectToAction("Index");
        }
    }
}
