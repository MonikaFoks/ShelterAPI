using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShelterAPI.Models
{
    public class Employee
    {
        public int Id { get; set; }
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        [Required(ErrorMessage ="This field is required.")]
        public string Login { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "This field is required.")]
        public string Password { get; set; }

        public int ShelterId { get; set; }

        public virtual Shelter Shelter { get; set; }

        public string LoginErrorMessage { get; set; }
    }
}