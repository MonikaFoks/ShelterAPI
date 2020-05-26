using Fluent.Infrastructure.FluentDBContext;
using Fluent.Infrastructure.FluentModel;
using ShelterAPI.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
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

        
    }
}