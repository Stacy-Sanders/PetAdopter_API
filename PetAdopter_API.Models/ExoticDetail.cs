using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetAdopter_API.Models
{
    public class ExoticDetail
    {
        public int ExoticId { get; set; }

        public string Species { get; set; }

        public string Name { get; set; }

        public string Breed { get; set; }

        public string Sex { get; set; }

        public bool IsSterile { get; set; }

        public DateTime BirthDate { get; set; }

        public float Age
        {

            get
            {
                TimeSpan age = DateTime.Now - BirthDate;
                return (int)Math.Floor(age.TotalDays / 365.24);
            }

        }

        public bool IsAdoptionPending { get; set; }

        public bool IsKidFriendly { get; set; }

        public bool IsPetFriendly { get; set; }

        public bool IsHypoallergenic { get; set; }

        public bool IsLegalInCity { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }

        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
