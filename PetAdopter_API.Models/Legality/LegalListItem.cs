using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetAdopter_API.Models.Legality
{
    public class LegalListItem
    {
        public bool IsLegalInCity { get; set; }

        public string Species { get; set; }

        public string Breed { get; set; }

        public string Name { get; set; }

        public string Sex { get; set; }

        public DateTime BirthDate { get; set; }

        public int ShelterId { get; set; }

        public bool IsAdoptionPending { get; set; }

        [Display(Name="Created")]
        public DateTimeOffset CreatedUtc { get; set; }

        public virtual Exotic Exotics { get; set; }
    }
}


