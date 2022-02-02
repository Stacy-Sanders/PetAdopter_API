using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PetAdopter_API.Models
{

    public class Domestic
    {
        [Key]
        public int DomesticId { get; set; }

        [Required]
        public Guid AdminId { get; set; }

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

        public float Age
        {

            get
            {
                TimeSpan age = DateTime.Now - BirthDate;
                return (int)Math.Floor(age.TotalDays / 365.24);
            }
        }

        [Required]
        public bool IsAdoptionPending { get; set; }

        public bool IsKidFriendly { get; set; }

        public bool IsPetFriendly { get; set; }

        public bool IsHypoallergenic { get; set; }

        public bool IsHouseTrained { get; set; }

        public bool IsDeclawed { get; set; }

        [Required]
        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }

        [ForeignKey(nameof(Adopter))]
        public int AdopterId { get; set; }
        public virtual Adopter Adopter { get; set; }

        [ForeignKey(nameof(Shelter))]
        public int ShelterId { get; set; }
        public virtual Shelter Shelter { get; set; }

    }
}


