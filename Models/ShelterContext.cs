using ShelterAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ShelterAPI.Models
{
    public class ShelterContext : DbContext
    {
        public ShelterContext()
        {

        }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Shelter> Shelters { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}