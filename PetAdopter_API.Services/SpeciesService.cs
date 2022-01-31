using PetAdopter_API.Data;
using PetAdopter_API.Models;
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
        public DomesticDetail GetSpecies(string species)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Domestics.Single(x => x.Species == species && x.AdminId == _userId);
                return new DomesticDetail
                {
                    Species = entity.Species,
                    Name = entity.Name,
                    ShelterId = entity.ShelterId,
                    Breed = entity.Breed,
                    Sex = entity.Sex,
                    BirthDate = entity.BirthDate,
                    IsAdoptionPending = entity.IsAdoptionPending,
                    CreatedUtc = entity.CreatedUtc,


                };
            }
        }
    }
}
