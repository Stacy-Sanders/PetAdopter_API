using PetAdopter_API.Data;
using PetAdopter_API.Models;
using PetAdopter_API.Models.Legality;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetAdopter_API.Services
{
    public class LegalityService
    {
        private readonly Guid _userId;

        public LegalityService(Guid userId)
        {
            _userId = userId;
        }

        public IEnumerable<LegalListItem> GetLegalInCity()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Exotics
                        .Where(e => e.AdminId == _userId)
                        .Select(
                            e =>
                                new LegalListItem
                                {
                                    IsLegalInCity = e.IsLegalInCity,
                                    Species = e.Species,
                                    Breed = e.Breed,
                                    Name = e.Name,
                                    Sex = e.Sex,
                                    BirthDate = e.BirthDate,
                                    ShelterId = e.ShelterId,
                                    IsAdoptionPending = e.IsAdoptionPending,
                                    CreatedUtc = e.CreatedUtc
                                }
                        );

                return query.ToArray();
            }
        }
    }
}







