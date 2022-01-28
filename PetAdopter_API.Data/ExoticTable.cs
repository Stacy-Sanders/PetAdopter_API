﻿using System;
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
<<<<<<< HEAD
        [ForeignKey(nameof(Shelter))]
        public int ShelterId { get; set; }
        public virtual Shelter Shelter { get; set; }
=======
        //[ForeignKey(nameof(Shelter))]
        //public int ShelterId { get; set; }
        //public virtual Shelter Shelter { get; set; }
        public ExoticTable() { }
        public ExoticTable(int id, string name, string breed, string species, bool isSterile, DateTime birthdate, float age, bool isadoptionPending, bool isKidFriendly, bool isPetFriendly, bool ishypoallegernic, bool islegalInCity, int shelterId)
        {
            id = Id;
            name = Name;
            breed = Breed;
            species = Species;
            isSterile = Sterile;
            birthdate = Birthdate;
            age = Age;
            isadoptionPending = IsAdoptionPending;
            isKidFriendly = IsKidFriendly;
            isPetFriendly = IsPetFriendly;
            ishypoallegernic = IsHypoallergenic;
            islegalInCity = IsLegalInCity;
            //shelterId = ShelterId;
>>>>>>> 02292f0c14c4d9d4a55d5636a46e98b7dee13559

    }
}