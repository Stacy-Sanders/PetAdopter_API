using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PetAdopter_API.Models
{
    public class Shelter
    {
        [Key]
        public int ShelterId { get; set; }

        [Required]
        public string ShelterName { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        public float Rating { get; set; }





    }
}