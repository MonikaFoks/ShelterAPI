using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShelterAPI.Models
{
    public class Shelter
    {
        public Shelter()
        {
            Employee = new HashSet<Employee>();
            Pet = new HashSet<Pet>();
        }

        public int Id { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public string Phone { get; set; }

        public virtual ICollection<Employee> Employee { get; set; }
        public virtual ICollection<Pet> Pet { get; set; }
    }
}