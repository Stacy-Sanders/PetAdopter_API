using PetAdopter_API.Data;
using PetAdopter_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetAdopter_API.Services
{
    public class DomesticService
    {
        private readonly Guid _userId;

        public DomesticService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateDomestic(DomesticCreate model)
        {
            var entity =
                new Domestic()
                {
                    AdminId = _userId,
                    Species = model.Species,
                    Name = model.Name,
                    Breed = model.Breed,
                    Sex = model.Sex,
                    IsSterile = model.IsSterile,
                    BirthDate = model.BirthDate,
                    IsAdoptionPending = model.IsAdoptionPending,
                    IsKidFriendly = model.IsKidFriendly,
                    IsPetFriendly = model.IsPetFriendly,
                    IsHouseTrained = model.IsHouseTrained,
                    IsHypoallergenic = model.IsHypoallergenic,
                    IsDeclawed = model.IsDeclawed,
                    CreatedUtc = DateTimeOffset.Now
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Domestics.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<DomesticListItem> GetDomestics()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Domestics
                        .Where(e => e.AdminId == _userId)
                        .Select(
                            e =>
                                new DomesticListItem
                                {
                                    DomesticId = e.DomesticId,
                                    Species = e.Species,
                                    Name = e.Name,
                                    CreatedUtc = e.CreatedUtc
                                }
                        );
                
                return query.ToArray();
            }
        }

        public DomesticDetail GetDomesticById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Domestics
                        .Single(e => e.DomesticId == id && e.AdminId == _userId);
                return
                    new DomesticDetail 
                    { 
                        DomesticId = entity.DomesticId,
                        Species = entity.Species,
                        Name = entity.Name,
                        Breed = entity.Breed,
                        Sex = entity.Sex,
                        IsSterile = entity.IsSterile,
                        BirthDate = entity.BirthDate,
                        IsAdoptionPending = entity.IsAdoptionPending,
                        IsKidFriendly = entity.IsKidFriendly,
                        IsPetFriendly = entity.IsPetFriendly,
                        IsHypoallergenic = entity.IsHypoallergenic,
                        IsHouseTrained = entity.IsHouseTrained,
                        IsDeclawed = entity.IsDeclawed,
                        CreatedUtc = entity.CreatedUtc
                    };

            }
        }

        public bool UpdateDomestic(DomesticEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Domestics
                        .Single(e => e.DomesticId == model.DomesticId && e.AdminId == _userId);

                entity.Species = model.Species;
                entity.Name = model.Name;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
                
            }
        }

        public bool DeleteDomestic(int domesticId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Domestics
                        .Single(e => e.DomesticId == domesticId && e.AdminId == _userId);

                ctx.Domestics.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}

        
