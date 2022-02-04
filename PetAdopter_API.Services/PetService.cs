using PetAdopter_API.Data;
using PetAdopter_API.Models;
using PetAdopter_API.Models.Pet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetAdopter_API.Services
{
    public class PetService
    {
        private readonly Guid _userId;

        public PetService(Guid userId)
        {
            _userId = userId;
        }

        public IEnumerable<DomesticListItem> GetDomesticByAdopterID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Domestics
                        .Where(e => e.AdopterId == id && e.AdminId == _userId)
                        .Select(
                            e =>
                                new DomesticListItem
                                {
                                    DomesticId = e.DomesticId,
                                    Species = e.Species,
                                    Name = e.Name,
                                    Breed = e.Breed,
                                    Sex = e.Sex,
                                    IsSterile = e.IsSterile,
                                    BirthDate = e.BirthDate,
                                    IsKidFriendly = e.IsKidFriendly,
                                    IsPetFriendly = e.IsPetFriendly,
                                    IsHypoallergenic = e.IsHypoallergenic,
                                    IsHouseTrained = e.IsHouseTrained,
                                    IsDeclawed = e.IsDeclawed,
                                    CreatedUtc = e.CreatedUtc,
                                    ShelterId = e.ShelterId,
                                    AdopterId = e.AdopterId,
                                }
                        );
                return entity.ToArray();
            }
        }

        public bool UpdateAdopterDomestics(DomesticPetEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Domestics
                        .Single(e => e.DomesticId == model.DomesticId && e.AdminId == _userId);

                entity.DomesticId = model.DomesticId;
                entity.Name = model.Name;
                entity.AdopterId = model.AdopterId;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;

            }
        }

        public IEnumerable<DomesticListItem> GetDomesticByShelterID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Domestics
                        .Where(e => e.ShelterId == id && e.AdminId == _userId)
                        .Select(
                            e =>
                                new DomesticListItem
                                {
                                    DomesticId = e.DomesticId,
                                    Species = e.Species,
                                    Name = e.Name,
                                    Breed = e.Breed,
                                    Sex = e.Sex,
                                    IsSterile = e.IsSterile,
                                    BirthDate = e.BirthDate,
                                    IsKidFriendly = e.IsKidFriendly,
                                    IsPetFriendly = e.IsPetFriendly,
                                    IsHypoallergenic = e.IsHypoallergenic,
                                    IsHouseTrained = e.IsHouseTrained,
                                    IsDeclawed = e.IsDeclawed,
                                    CreatedUtc = e.CreatedUtc,
                                    ShelterId = e.ShelterId,
                                    AdopterId = e.AdopterId,
                                }
                        );
                return entity.ToArray();
            }

        }

        public IEnumerable<DomesticListItem> GetDomesticBySpecies(string species)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Domestics
                        .Where(e => e.Species == species && e.AdminId == _userId).Select(e =>
                                    new DomesticListItem
                                    {
                                        DomesticId = e.DomesticId,
                                        Species = e.Species,
                                        Name = e.Name,
                                        Breed = e.Breed,
                                        Sex = e.Sex,
                                        IsSterile = e.IsSterile,
                                        BirthDate = e.BirthDate,
                                        IsKidFriendly = e.IsKidFriendly,
                                        IsPetFriendly = e.IsPetFriendly,
                                        IsHypoallergenic = e.IsHypoallergenic,
                                        IsHouseTrained = e.IsHouseTrained,
                                        IsDeclawed = e.IsDeclawed,
                                        ShelterId = e.ShelterId,
                                        AdopterId = e.AdopterId,
                                        CreatedUtc = e.CreatedUtc,
                                    }
                                    );
                return entity.ToArray();
            }
        }

        public IEnumerable<DomesticListItem> GetDomesticByHypoallergenic(bool isHypoallergenic)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Domestics
                        .Where(e => e.IsHypoallergenic == isHypoallergenic && e.AdminId == _userId)
                        .Select(
                            e =>
                                new DomesticListItem
                                {
                                    DomesticId = e.DomesticId,
                                    Species = e.Species,
                                    Name = e.Name,
                                    Breed = e.Breed,
                                    Sex = e.Sex,
                                    IsSterile = e.IsSterile,
                                    BirthDate = e.BirthDate,
                                    IsKidFriendly = e.IsKidFriendly,
                                    IsPetFriendly = e.IsPetFriendly,
                                    IsHypoallergenic = e.IsHypoallergenic,
                                    IsHouseTrained = e.IsHouseTrained,
                                    IsDeclawed = e.IsDeclawed,
                                    ShelterId = e.ShelterId,
                                    AdopterId = e.AdopterId,
                                    CreatedUtc = e.CreatedUtc,
                                }

                        );
                return entity.ToArray();
            }
        }

        public IEnumerable<DomesticListItem> GetDomesticByDeclawed(bool isDeclawed)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Domestics
                        .Where(e => e.IsDeclawed == isDeclawed && e.AdminId == _userId)
                        .Select(
                            e =>
                                new DomesticListItem
                                {
                                    DomesticId = e.DomesticId,
                                    Species = e.Species,
                                    Name = e.Name,
                                    Breed = e.Breed,
                                    Sex = e.Sex,
                                    IsSterile = e.IsSterile,
                                    BirthDate = e.BirthDate,
                                    IsKidFriendly = e.IsKidFriendly,
                                    IsPetFriendly = e.IsPetFriendly,
                                    IsHypoallergenic = e.IsHypoallergenic,
                                    IsHouseTrained = e.IsHouseTrained,
                                    IsDeclawed = e.IsDeclawed,
                                    ShelterId = e.ShelterId,
                                    AdopterId = e.AdopterId,
                                    CreatedUtc = e.CreatedUtc,
                                }

                        );
                return entity.ToArray();
            }
        }

        public IEnumerable<DomesticListItem> GetDomesticByHouseTrained(bool isHouseTrained)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Domestics
                        .Where(e => e.IsHouseTrained == isHouseTrained && e.AdminId == _userId)
                        .Select(
                            e =>
                                new DomesticListItem
                                {
                                    DomesticId = e.DomesticId,
                                    Species = e.Species,
                                    Name = e.Name,
                                    Breed = e.Breed,
                                    Sex = e.Sex,
                                    IsSterile = e.IsSterile,
                                    BirthDate = e.BirthDate,
                                    IsKidFriendly = e.IsKidFriendly,
                                    IsPetFriendly = e.IsPetFriendly,
                                    IsHypoallergenic = e.IsHypoallergenic,
                                    IsHouseTrained = e.IsHouseTrained,
                                    IsDeclawed = e.IsDeclawed,
                                    ShelterId = e.ShelterId,
                                    AdopterId = e.AdopterId,
                                    CreatedUtc = e.CreatedUtc,
                                }

                        );
                return entity.ToArray();
            }
        }
        public IEnumerable<ExoticListItem> GetExoticByAdopterID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Exotics
                        .Where(e => e.AdopterId == id && e.AdminId == _userId)
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
                                }
                        );
                return entity.ToArray();
            }
        }

        public bool UpdateAdopterExotics(ExoticPetEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Exotics
                        .Single(e => e.ExoticId == model.ExoticId && e.AdminId == _userId);

                entity.ExoticId = model.ExoticId;
                entity.Name = model.Name;
                entity.AdopterId = model.AdopterId;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;

            }
        }

        public IEnumerable<ExoticListItem> GetExoticByShelterID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Exotics
                        .Where(e => e.ShelterId == id && e.AdminId == _userId)
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
                                }
                        );
                return entity.ToArray();
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
                                }
                        );
                return entity.ToArray();
            }

        }
    }
}

