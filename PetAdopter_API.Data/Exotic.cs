using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PetAdopter_API.Models
{
    public class Exotic
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        // [Required]
        public string Breed { get; set; }

        [Required]
        public string Species { get; set; }

        [Required]
        public string Sex { get; set; }

        [Required]
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
        [Required]
        public bool IsAdoptionPending { get; set; }

        // [Required]
        public bool IsKidFriendly { get; set; }

        // [Required]
        public bool IsPetFriendly { get; set; }

        // [Required]
        public bool IsHypoallergenic { get; set; }

        [Required]
        public bool IsLegalInCity { get; set; }

        [Required]
        public DateTimeOffset CreatedUtc { get; set; }
        [ForeignKey(nameof(Adopter))]
        public int AdopterID { get; set; }
        public virtual Adopter Adopter { get; set; }



        [ForeignKey(nameof(Shelter))]
        public int ShelterId { get; set; }
        public virtual Shelter Shelter { get; set; }

        //public ExoticTable(int id, string name, string breed, string species, bool isSterile, DateTime birthDate, float age, bool isAdoptionPending, bool isKidFriendly, bool isPetFriendly, bool ishypoallegernic, bool islegalInCity, int shelterId)
        //{
        //    Id = id;
        //    Name = name;
        //    Breed = breed;
        //    Species = species;
        //    Sterile = isSterile;
        //    BirthDate = birthDate;
        //    IsAdoptionPending = isAdoptionPending;
        //    IsKidFriendly = isKidFriendly;
        //    IsPetFriendly = isPetFriendly;
        //    IsHypoallergenic = ishypoallegernic;
        //    IsLegalInCity = slegalInCity;
        //    ShelterId = shelterId;

        //}
    }
}