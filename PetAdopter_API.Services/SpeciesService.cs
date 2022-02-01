using PetAdopter_API.Data;
using PetAdopter_API.Models;
using PetAdopter_API.Models.Species;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PetAdopter_API.Services
{
    public class SpeciesService
    {
        private readonly Guid _userId;
        public SpeciesService(Guid userId)
        {
            _userId = userId;
        }
        public IEnumerable<SpeciesListItem> GetDomesticSpecies(SpeciesService species)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Domestics.Where(e => e.Species.Equals(species) && e.AdminId == _userId ).Select(e=> new SpeciesListItem
                
                {
                    Species = e.Species,
                    Name = e.Name,
                    ShelterId = e.ShelterId,
                    Breed = e.Breed,
                    Sex = e.Sex,
                    Birthdate = e.BirthDate,
                    IsAdoptionPending = e.IsAdoptionPending,
                    CreatedUtc = e.CreatedUtc,
                }) ;

                return entity;
            }
        }
    }
}
