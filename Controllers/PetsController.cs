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

        public ActionResult Details(int id)
        {
            var pet = _context.Pets.SingleOrDefault(p => p.Id == id);
            if (pet == null)
            {
                return HttpNotFound();
            }

            return View(pet);
        }

        private IEnumerable<Pet> GetPets()
        {
            return new List<Pet>
            {

            };

        }
        
    }
}