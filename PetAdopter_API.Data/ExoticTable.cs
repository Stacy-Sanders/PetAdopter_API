using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PetAdopter_API.Models
{
    public class ExoticTable
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        
        public string Breed { get; set; }
        [Required]
        public string Species { get; set; }
        [Required]
        public string Sex { get; set; }
        
        public bool Sterile { get; set; }
        [Required]
        public DateTime Birthdate { get; set; }
        
        public float Age
        {

            get
            {
                TimeSpan age = DateTime.Now - Birthdate;
                return (int)Math.Floor(age.TotalDays / 365.24);
            }

        }
        
        public bool IsAdoptionPending { get; set; }
        
        public bool IsKidFriendly { get; set; }
        
        public bool IsPetFriendly { get; set; }
        
        public bool IsHypoallergenic { get; set; }
        
        public bool IsLegalInCity { get; set; }


        [ForeignKey(nameof(Shelter))]
        public int ShelterId { get; set; }

        public virtual Shelter Shelter { get; set; }
        
    }
}