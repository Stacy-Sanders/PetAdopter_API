using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetAdopter_API.Models
{
    public class ExoticCreate
    {
        [Required]
        public string Species { get; set; }

        [Required]
        public string Name { get; set; }

        public string Breed { get; set; }

        [Required]
        public string Sex { get; set; }

        // [Required]
        public bool IsSterile { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        public bool IsAdoptionPending
        {
            get
            {
                return AdopterId > 1;
            }
        }

        public bool IsKidFriendly { get; set; }

        public bool IsPetFriendly { get; set; }

        public bool IsHypoallergenic { get; set; }

        [Required]
        public bool IsLegalInCity { get; set; }

        [ForeignKey(nameof(Adopter))]
        public int AdopterId { get; set; }

        [ForeignKey(nameof(Shelter))]
        public int ShelterId { get; set; }

    }
}
