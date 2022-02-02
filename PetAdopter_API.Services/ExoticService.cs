﻿using PetAdopter_API.Data;
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
                    IsAdoptionPending = model.IsAdoptionPending,
                    IsKidFriendly = model.IsKidFriendly,
                    IsPetFriendly = model.IsPetFriendly,
                    IsHypoallergenic = model.IsHypoallergenic,
                    IsLegalInCity = model.IsLegalInCity,
                    CreatedUtc = DateTimeOffset.Now,
                    AdopterId = model.AdopterId,
                    ShelterId = model.ShelterId,
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
                                    CreatedUtc = e.CreatedUtc
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
                        IsAdoptionPending = entity.IsAdoptionPending,
                        IsKidFriendly = entity.IsKidFriendly,
                        IsPetFriendly = entity.IsPetFriendly,
                        IsHypoallergenic = entity.IsHypoallergenic,
                        IsLegalInCity = entity.IsLegalInCity,
                        CreatedUtc = entity.CreatedUtc,
                        ShelterId = entity.ShelterId,
                    };
            }
        }

        public IEnumerable<ExoticListItem> GetExoticBySpecies(string species)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Exotics
                        .Where(e => e.Species == species && e.AdminId == _userId)
                        .Select(e =>
                                    new ExoticListItem
                                    {
                                        ExoticId = e.ExoticId,
                                        Species = e.Species,
                                        Name = e.Name,

                                    }
                                    );
                return entity.ToArray();
            }
        }

        public IEnumerable<ExoticListItem> GetExoticByLegality(bool isLegalInCity)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Exotics
                        .Where(e => e.IsLegalInCity == isLegalInCity && e.AdminId == _userId)
                        .Select(
                            e =>
                                new ExoticListItem
                                {
                                    ExoticId = e.ExoticId,
                                    Species = e.Species,
                                    Name = e.Name,
                                }

                        );
                return entity.ToArray();
            }
        }

        public IEnumerable<ExoticListItem> GetExoticByHypoallergenic(bool isHypoallergenic)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Exotics
                        .Where(e => e.IsHypoallergenic == isHypoallergenic && e.AdminId == _userId)
                        .Select(
                            e =>
                                new ExoticListItem
                                {
                                    ExoticId = e.ExoticId,
                                    Species = e.Species,
                                    Name = e.Name,
                                }

                        );
                return entity.ToArray();
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
                entity.IsAdoptionPending = model.IsAdoptionPending;
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

