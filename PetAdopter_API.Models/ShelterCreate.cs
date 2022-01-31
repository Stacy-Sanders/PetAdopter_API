using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetAdopter_API.Models
{
    public class ShelterCreate
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
