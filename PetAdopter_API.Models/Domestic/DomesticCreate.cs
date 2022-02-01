using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetAdopter_API.Models
{
    public class DomesticCreate
    {
        [Required]
        public string Species { get; set; }

        [Required]
        public string Name { get; set; }

        public string Breed { get; set; }

        [Required]
        public string Sex { get; set; }

        public bool IsSterile { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        public bool IsAdoptionPending { get; set; }

        public bool IsKidFriendly { get; set; }

        public bool IsPetFriendly { get; set; }

        public bool IsHypoallergenic { get; set; }

        public bool IsHouseTrained { get; set; }

        public bool IsDeclawed { get; set; }

        [ForeignKey(nameof(Adopter))]
        public int AdopterId { get; set; }

        [ForeignKey(nameof(Shelter))]
        public int ShelterId { get; set; }
    }
}
       
