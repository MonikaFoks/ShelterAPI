using Fluent.Infrastructure.FluentDBContext;
using Fluent.Infrastructure.FluentModel;
using ShelterAPI.Models;
using ShelterAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShelterAPI.Controllers
{
    public class PetsController : Controller
    {
        private ShelterContext _context;

        public PetsController()
        {
            _context = new ShelterContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ViewResult Index()
        {
            var pets = _context.Pets.ToList();

            return View(pets);
        }

        public ViewResult AllPets()
        {
            var pets = _context.Pets.ToList();

            return View(pets);
        }

        public ViewResult Dogs()
        {
            var dogs = _context.Pets.ToList().Where(d => d.Species == "Dog");
            return View(dogs);
        }

        public ViewResult Cats()
        {
            var cats = _context.Pets.ToList().Where(c => c.Species == "Cat");
            return View(cats);
        }

        public ViewResult Other()
        {
            var other = _context.Pets.ToList().Where(o => (o.Species != "Cat" && o.Species != "Dog"));
            return View(other);
        }

        public ActionResult Details(int id)
        {
            var pet = _context.Pets.SingleOrDefault(p => p.Id == id);
            if (pet == null)
            {
                return HttpNotFound();
            }

            return View(pet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Pet pet)
        {

            if (!ModelState.IsValid)
            {
                var viewModel = new PetViewModel
                {
                    Pet = pet,

                    Shelters = _context.Shelters.ToList()
                };
                return View("PetForm", viewModel);
            }

            if (pet.Id == 0)
                _context.Pets.Add(pet);

            else
            {
                var petInDb = _context.Pets.Single(p => p.Id == pet.Id);

                petInDb.PetName = pet.PetName;
                petInDb.Species = pet.Species;
                petInDb.Breed = pet.Breed;
                petInDb.IsAdopted = pet.IsAdopted;
                petInDb.Description = pet.Description;
                petInDb.Shelter = pet.Shelter;
                petInDb.AddedDate = pet.AddedDate;
                petInDb.PhotoPath = pet.PhotoPath;
            }

            // TODO: Naprawić dodawanie/edycję! Problem: pole HiddenFor w PetForm


            _context.SaveChanges();
            return RedirectToAction("Index", "Pets");
        }
        public ActionResult New()
        {
            var shelters = _context.Shelters.ToList();
            var viewModel = new PetViewModel
            {
                Shelters = shelters
            };

            return View("PetForm", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var pet = _context.Pets.SingleOrDefault(p => p.Id == id);
            if (pet == null)
                return HttpNotFound();

            var viewModel = new PetViewModel
            {
                Pet = pet,
                Shelters = _context.Shelters.ToList()
            };
            return View("PetForm", viewModel);
        }

        
    }
}