using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetAdopter_API.Models
{
    public class ShelterDetail
    {
        public int ShelterId { get; set; }

        public string Name { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public float Rating { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }

        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }

        public List<DomesticListItem> ShelterDomesticList { get; set; } = new List<DomesticListItem>();

        public List<ExoticListItem> ShelterExoticList { get; set;} = new List<ExoticListItem>();

    }
}
