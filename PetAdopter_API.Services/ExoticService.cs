using PetAdopter_API.Data;
using PetAdopter_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetAdopter_API.Services
{
    public class ExoticService
    {
        private readonly Guid _userId;

        public ExoticService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateExotic(ExoticCreate model)
        {
            var entity =
                new Exotic()
                {
                    AdminId = _userId,
                    Species = model.Species,
                    Name = model.Name,
                    Breed = model.Breed,
                    Sex = model.Sex,
                    IsSterile = model.IsSterile,
                    BirthDate = model.BirthDate,
                    IsKidFriendly = model.IsKidFriendly,
                    IsPetFriendly = model.IsPetFriendly,
                    IsHypoallergenic = model.IsHypoallergenic,
                    IsLegalInCity = model.IsLegalInCity,
                    ShelterId = model.ShelterId,
                    AdopterId = model.AdopterId,
                    CreatedUtc = DateTimeOffset.Now,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Exotics.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ExoticListItem> GetExotics()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Exotics
                        .Where(e => e.AdminId == _userId)
                        .Select(
                            e =>
                                new ExoticListItem
                                {
                                    ExoticId = e.ExoticId,
                                    Species = e.Species,
                                    Name = e.Name,
                                    Breed = e.Breed,
                                    Sex = e.Sex,
                                    IsSterile = e.IsSterile,
                                    BirthDate = e.BirthDate,
                                    IsKidFriendly = e.IsKidFriendly,
                                    IsPetFriendly = e.IsPetFriendly,
                                    IsHypoallergenic = e.IsHypoallergenic,
                                    IsLegalInCity = e.IsLegalInCity,
                                    ShelterId = e.ShelterId,
                                    AdopterId = e.AdopterId,
                                    CreatedUtc = e.CreatedUtc,
                                    ModifiedUtc = e.ModifiedUtc,
                                }
                        );

                return query.ToArray();
            }
        }

        public ExoticDetail GetExoticById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Exotics
                        .Single(e => e.ExoticId == id && e.AdminId == _userId);
                return
                    new ExoticDetail
                    {
                        ExoticId = entity.ExoticId,
                        Species = entity.Species,
                        Name = entity.Name,
                        Breed = entity.Breed,
                        Sex = entity.Sex,
                        IsSterile = entity.IsSterile,
                        BirthDate = entity.BirthDate,
                        IsKidFriendly = entity.IsKidFriendly,
                        IsPetFriendly = entity.IsPetFriendly,
                        IsHypoallergenic = entity.IsHypoallergenic,
                        IsLegalInCity = entity.IsLegalInCity,
                        ShelterId = entity.ShelterId,
                        AdopterId = entity.AdopterId,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc,
                    };
            }
        }
        public bool UpdateExotic(ExoticEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Exotics
                        .Single(e => e.ExoticId == model.ExoticId && e.AdminId == _userId);

                entity.Species = model.Species;
                entity.Name = model.Name;
                entity.Breed = model.Breed;
                entity.Sex = model.Sex;
                entity.IsSterile = model.IsSterile;
                entity.BirthDate = model.BirthDate;
                entity.IsKidFriendly = model.IsKidFriendly;
                entity.IsPetFriendly = model.IsPetFriendly;
                entity.IsHypoallergenic = model.IsHypoallergenic;
                entity.IsLegalInCity = model.IsLegalInCity;
                entity.ShelterId = model.ShelterId;
                entity.AdopterId = model.AdopterId;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;

            }
        }

        public bool DeleteExotic(int exoticId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Exotics
                        .Single(e => e.ExoticId == exoticId && e.AdminId == _userId);

                ctx.Exotics.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}

       


