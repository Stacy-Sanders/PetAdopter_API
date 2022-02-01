using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetAdopter_API.Models
{
    public class ExoticEdit
    {
        public int ExoticId { get; set; }

        public string Species { get; set; }

        public string Name { get; set; }

        public string Breed { get; set; }

        public string Sex { get; set; }

        public bool IsSterile { get; set; }

        public DateTime BirthDate { get; set; }

        public bool IsAdoptionPending { get; set; }

        public bool IsKidFriendly { get; set; }

        public bool IsPetFriendly { get; set; }

        public bool IsHypoallergenic { get; set; }

        public bool IsLegalInCity { get; set; }

        [ForeignKey(nameof(Shelter))]
        public int ShelterId { get; set; }

        [ForeignKey(nameof(Adopter))]
        public int AdopterId { get; set; }

    }
}
