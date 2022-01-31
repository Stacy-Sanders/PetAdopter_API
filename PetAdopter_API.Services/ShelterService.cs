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
                    Rating = model.Rating
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
                        .Where(e => e.AdminId == _userId)
                        .Select(
                        e =>
                            new ShelterListItem
                            {
                                ShelterId = e.ShelterId,
                                ShelterName = e.Name,
                                City = e.City,
                                State = e.State,
                                Rating = e.Rating,
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
                    .Single(e => e.ShelterId == id && e.AdminId == _userId);
                return
                    new ShelterDetail
                    {
                        ShelterId = entity.ShelterId,
                        ShelterName = entity.Name,
                        City = entity.City,
                        State = entity.State,
                        Rating = entity.Rating
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
                        .Single(e => e.ShelterId == model.ShelterId && e.AdminId == _userId);
                entity.ShelterId = model.ShelterId;
                entity.Name = model.ShelterName; 
                entity.City = model.City;
                entity.State = model.State;
                entity.Rating = model.Rating;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteShelter(int shelterId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx.Shelters
                        .Single(e => e.ShelterId == shelterId && e.AdminId == _userId);
                ctx.Shelters.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
