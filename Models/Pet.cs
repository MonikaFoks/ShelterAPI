using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShelterAPI.Models
{
    public class Pet
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Please enter pet's name.")]
        [Display(Name="Name")]
        public string PetName { get; set; }
        public string Species { get; set; }
        public string Breed { get; set; }
        public string Description { get; set; }
        public int ShelterId { get; set; }
        [Required(ErrorMessage = "Please enter the date.")]
        public DateTime? AddedDate { get; set; }
        [Required]
        public bool IsAdopted { get; set; }

        public string PhotoPath { get; set; }
        [Required(ErrorMessage = "Please choose shelter.")]
        public virtual Shelter Shelter { get; set; }
        //public HttpPostedFileBase ImageFile { get; set; }
    }

    public enum Species
    {
        Dog,
        Cat,
        Other
    }
}