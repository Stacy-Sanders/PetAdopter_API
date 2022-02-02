using PetAdopter_API.Data;
using PetAdopter_API.Models;
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
                                    IsAdoptionPending = e.IsAdoptionPending,
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
                                    IsAdoptionPending = e.IsAdoptionPending,
                                    IsKidFriendly = e.IsKidFriendly,
                                    IsPetFriendly = e.IsPetFriendly,
                                    IsHypoallergenic = e.IsHypoallergenic,
                                    IsHouseTrained = e.IsHouseTrained,
                                    IsDeclawed = e.IsDeclawed,
                                    CreatedUtc = e.CreatedUtc,
                                    ShelterId = e.ShelterId,
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
                                        IsAdoptionPending = e.IsAdoptionPending,
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
                                    IsAdoptionPending = e.IsAdoptionPending,
                                    IsKidFriendly = e.IsKidFriendly,
                                    IsPetFriendly = e.IsPetFriendly,
                                    IsHypoallergenic = e.IsHypoallergenic,
                                    IsHouseTrained = e.IsHouseTrained,
                                    IsDeclawed = e.IsDeclawed,
                                    ShelterId = e.ShelterId,
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
                                    IsAdoptionPending = e.IsAdoptionPending,
                                    IsKidFriendly = e.IsKidFriendly,
                                    IsPetFriendly = e.IsPetFriendly,
                                    IsHypoallergenic = e.IsHypoallergenic,
                                    IsHouseTrained = e.IsHouseTrained,
                                    IsDeclawed = e.IsDeclawed,
                                    ShelterId = e.ShelterId,
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
                                    IsAdoptionPending = e.IsAdoptionPending,
                                    IsKidFriendly = e.IsKidFriendly,
                                    IsPetFriendly = e.IsPetFriendly,
                                    IsHypoallergenic = e.IsHypoallergenic,
                                    IsHouseTrained = e.IsHouseTrained,
                                    IsDeclawed = e.IsDeclawed,
                                    ShelterId = e.ShelterId,
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
                                    IsAdoptionPending = e.IsAdoptionPending,
                                    IsKidFriendly = e.IsKidFriendly,
                                    IsPetFriendly = e.IsPetFriendly,
                                    IsHypoallergenic = e.IsHypoallergenic,
                                    IsLegalInCity = e.IsLegalInCity,
                                    CreatedUtc = e.CreatedUtc,
                                    ShelterId = e.ShelterId,
                                    AdopterId = e.AdopterId,
                                }
                        );
                return entity.ToArray();
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
                                    IsAdoptionPending = e.IsAdoptionPending,
                                    IsKidFriendly = e.IsKidFriendly,
                                    IsPetFriendly = e.IsPetFriendly,
                                    IsHypoallergenic = e.IsHypoallergenic,
                                    IsLegalInCity = e.IsLegalInCity,
                                    CreatedUtc = e.CreatedUtc,
                                    ShelterId = e.ShelterId,
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
                                        IsAdoptionPending = e.IsAdoptionPending,
                                        IsKidFriendly = e.IsKidFriendly,
                                        IsPetFriendly = e.IsPetFriendly,
                                        IsHypoallergenic = e.IsHypoallergenic,
                                        IsLegalInCity = e.IsLegalInCity,
                                        CreatedUtc = e.CreatedUtc,
                                        ShelterId = e.ShelterId,
                                        AdopterId = e.AdopterId,
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
                                    IsAdoptionPending = e.IsAdoptionPending,
                                    IsKidFriendly = e.IsKidFriendly,
                                    IsPetFriendly = e.IsPetFriendly,
                                    IsHypoallergenic = e.IsHypoallergenic,
                                    IsLegalInCity = e.IsLegalInCity,
                                    CreatedUtc = e.CreatedUtc,
                                    ShelterId = e.ShelterId,
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
                                    IsAdoptionPending = e.IsAdoptionPending,
                                    IsKidFriendly = e.IsKidFriendly,
                                    IsPetFriendly = e.IsPetFriendly,
                                    IsHypoallergenic = e.IsHypoallergenic,
                                    IsLegalInCity = e.IsLegalInCity,
                                    CreatedUtc = e.CreatedUtc,
                                    ShelterId = e.ShelterId,
                                }
                        );
                return entity.ToArray();
            }
        }
    }
}
