using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetAdopter_API.Models
{
    public class ShelterListItem
    {
        public int ShelterId { get; set; }

        public string Name { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public float Rating { get; set; }

        [Display(Name="Created")]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
