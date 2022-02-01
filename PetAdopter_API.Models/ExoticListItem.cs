using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetAdopter_API.Models
{
    public class ExoticListItem
    {
        public int ExoticId { get; set; }

        public string Species { get; set; }

        public string Name { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
