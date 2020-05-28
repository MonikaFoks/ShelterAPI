﻿using ShelterAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShelterAPI.ViewModels
{
    public class NewPetViewModel
    {
        public IEnumerable<Shelter> Shelters { get; set; }
        public Pet Pet { get; set; }
    }
}