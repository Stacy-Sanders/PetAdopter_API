using PetAdopter_API.Data;
using PetAdopter_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetAdopter_API.Services
{
    public class ShelterService
    {
        private readonly Guid _userId;

        public ShelterService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateShelter(ShelterCreate model)
        {
            var entity =
                new Shelter()
                {
                    AdminId = _userId,
                    ShelterId = model.ShelterId,
                    Name = model.Name,
                    City = model.City,
                    State = model.State,
                    Rating = model.Rating,
                    CreatedUtc = DateTimeOffset.Now,
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Shelters.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<ShelterListItem> GetShelters()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Shelters
                        .Select(
                        e =>
                            new ShelterListItem
                            {
                                ShelterId = e.ShelterId,
                                Name = e.Name,
                                City = e.City,
                                State = e.State,
                                Rating = e.Rating,
                                CreatedUtc = e.CreatedUtc
                            }
                        );
                return query.ToArray();
            }
        }
        public ShelterDetail GetShelterById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = 
                    ctx
                    .Shelters
                    .Single(e => e.ShelterId == id);
                return

                    new ShelterDetail
                    {
                        ShelterId = entity.ShelterId,
                        Name = entity.Name,
                        City = entity.City,
                        State = entity.State,
                        Rating = entity.Rating,
                        CreatedUtc = entity.CreatedUtc,
                    };
            }
        }
        public bool UpdateShelter(ShelterEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Shelters
                        .Single(e => e.ShelterId == model.ShelterId);

                entity.ShelterId = model.ShelterId;
                entity.Name= model.Name;
                entity.City = model.City;
                entity.State = model.State;
                entity.Rating = model.Rating;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteShelter(int shelterId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Shelters
                        .Single(e => e.ShelterId == shelterId && e.AdminId == _userId);

                ctx.Shelters.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
