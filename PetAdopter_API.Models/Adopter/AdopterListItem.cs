using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetAdopter_API.Models
{
    public class AdopterListItem
    {
        public int AdopterId { get; set; }


        public string FirstName { get; set; }


        public string LastName { get; set; }


        public string City { get; set; }


        public string State { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
