using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetAdopter_API.Models
{
    public class ShelterDetail
    {
        public int ShelterId { get; set; }
        public string ShelterName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public float Rating { get; set; }
        public List<DomesticListItem> ShelterDomesticList { get; set; } = new List<DomesticListItem>();
        public List<ExoticListItem> ShelterExoticList { get; set;} = new List<ExoticListItem>();

    }
}
