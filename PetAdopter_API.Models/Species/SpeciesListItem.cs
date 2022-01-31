using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetAdopter_API.Models.Species
{
    public class SpeciesListItem
    {
        public string Species { get; set; }
        public string Name { get; set; }

        public int ShelterId { get; set; }
        public string Breed { get; set; }
        public string Sex { get; set; }
        public DateTimeOffset Birthdate { get; set; }
        public bool IsAdoptionPending { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
                    
                    
    }
}
