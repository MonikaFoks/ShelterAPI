using Microsoft.Ajax.Utilities;
using ShelterAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.UI.WebControls;

namespace ShelterAPI.Controllers.API
{
    public class PetsController : ApiController
    {
        private ShelterContext _context;

        public PetsController()
        {
            _context = new ShelterContext();
        }
        // GET /api/pets
        public IEnumerable<Pet> GetPets()
        {
            return _context.Pets.ToList();
        }

        // GET /api/pets/1
        public Pet GetPet(int id)
        {
            var pet = _context.Pets.SingleOrDefault(p => p.Id == id);

            if (pet == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return pet;
        }

        // POST /api/pets
        [HttpPost]
        public Pet CreatePet(Pet pet)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _context.Pets.Add(pet);
            _context.SaveChanges();

            return pet;
        }

        // PUT /api/pets/1
        [HttpPut]
        public void UpdatePet(int id, Pet pet)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var petInDb = _context.Pets.SingleOrDefault(p => p.Id == id);

            if (petInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            petInDb.PetName = pet.PetName;
            petInDb.Species = pet.Species;
            petInDb.IsAdopted = pet.IsAdopted;
            petInDb.Shelter = pet.Shelter;
            petInDb.AddedDate = pet.AddedDate;
            petInDb.Breed = pet.Breed;
            petInDb.Description = pet.Description;

            _context.SaveChanges();
        }

        // DELETE /api/pets/1
        [HttpDelete]
        public void DeletePet(int id)
        {
            var petInDb = _context.Pets.SingleOrDefault(p => p.Id == id);

            if (petInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Pets.Remove(petInDb);
            _context.SaveChanges();
        }

    }
}
