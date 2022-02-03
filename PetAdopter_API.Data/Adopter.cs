using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PetAdopter_API.Models
{
    public class Adopter

    {
        [Key]
        public int AdopterId { get; set; }

        [Required]
        public Guid AdminId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }

       
        public virtual List<Domestic> DomesticList { get; set; } = new List<Domestic>();
        public virtual List<Exotic> ExoticList { get; set;} = new List<Exotic>();

    }
}