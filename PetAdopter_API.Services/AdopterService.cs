using PetAdopter_API.Data;
using PetAdopter_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetAdopter_API.Services
{
    public class AdopterService
    {
        private readonly Guid _userId;

        public AdopterService(Guid userId)
        {
            _userId = userId;
        }

        public bool AdopterCreate(AdopterCreate model)
        {
            var entity =
                new Adopter()
                {
                    AdminId = _userId,
                    AdopterId = model.AdopterId,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    City = model.City,
                    State = model.State,
                    PhoneNumber = model.PhoneNumber,
                    CreatedUtc = DateTimeOffset.Now
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Adopter.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<AdopterListItem> GetAdopters()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Adopter
                        .Where(e => e.AdminId == _userId)
                        .Select(
                            e =>
                                new AdopterListItem
                                {
                                    AdopterId = e.AdopterId,
                                    FirstName = e.FirstName,
                                    LastName = e.LastName,
                                    City = e.City,
                                    State = e.State,
                                    PhoneNumber = e.PhoneNumber,
                                    CreatedUtc = e.CreatedUtc,
                                }
                        );

                return query.ToArray();
            }
        }
        public IEnumerable<AdopterPetList> GetAdoptersPetList(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Adopter.Where(e => e.AdminId == _userId && e.AdopterId == id )
                    .Select(e => new AdopterPetList
                {
                    AdopterId = e.AdopterId,
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    City = e.City,
                    State = e.State,
                    CreatedUtc = e.CreatedUtc,
                    Domestics = e.DomesticList,
                    Exotics = e.ExoticList
                });
                return query.ToArray();
            }
        }

        public AdopterDetail GetAdopterById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Adopter
                        .Single(e => e.AdopterId == id && e.AdminId == _userId);
                return
                    new AdopterDetail
                    {
                        AdopterId = entity.AdopterId,
                        FirstName = entity.FirstName,
                        LastName = entity.LastName,
                        City = entity.City,
                        State = entity.State,
                        PhoneNumber = entity.PhoneNumber,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
                    };

            }
        }

        public bool UpdateAdopter(AdopterEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Adopter
                        .Single(e => e.AdopterId == model.AdopterId && e.AdminId == _userId);

                entity.FirstName = model.FirstName;
                entity.LastName = model.LastName;
                entity.City = model.City;
                entity.State = model.State;
                entity.PhoneNumber = model.PhoneNumber;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;

            }
        }

        public bool DeleteAdopter(int adopterId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Adopter
                        .Single(e => e.AdopterId == adopterId && e.AdminId == _userId);

                ctx.Adopter.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
