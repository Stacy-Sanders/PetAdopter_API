using PetAdopter_API.Data;
using PetAdopter_API.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace PetAdopter_API.Controllers
{
    public class ExoticController : ApiController
    {
        private readonly ApplicationDbContext _exotic = new ApplicationDbContext();

        //create
        [HttpPost]
        public async Task<IHttpActionResult> CreateExotic([FromBody] Exotic exotic)
        {
            if (exotic is null)
            {
                return BadRequest("Your request body cannot be empty");
            }
            if (ModelState.IsValid)
            {
                _exotic.Exotics.Add(exotic);
                int changeCount = await _exotic.SaveChangesAsync();

                return Ok("Your pet has been posted!");
            }
            return BadRequest(ModelState);
        }

        //Get all exotics
        [HttpGet]
        public async Task<IHttpActionResult> GetAllExotic()
        {
            List<Exotic> exotics = await _exotic.Exotics.ToListAsync();
            return Ok(exotics);
        }
        //Get By Species
        [HttpGet]
        public async Task<IHttpActionResult> GetBySpecies([FromUri] string species)
        {

            var exotic = await _exotic.Exotics.Where(x => x.Species == species).ToListAsync();


            if (exotic is null)
            {
                return NotFound();
            }
            return Ok(exotic);
        }
        [HttpPut]
        public async Task<IHttpActionResult> UpdateExotic([FromUri] int id, [FromBody] Exotic updatedExotic)
        {
            if (id != updatedExotic.Id)
            {
                return BadRequest("Please enter a valid Id");
            }
            Exotic exotic = await _exotic.Exotics.FindAsync(id);
            if (exotic is null)
            {
                return NotFound();
            }

            exotic.Name = updatedExotic.Name;
            exotic.Sex = updatedExotic.Sex;
            exotic.Breed = updatedExotic.Breed;
            exotic.Birthdate = updatedExotic.Birthdate;
            exotic.IsAdoptionPending = updatedExotic.IsAdoptionPending;
            exotic.IsKidFriendly = updatedExotic.IsKidFriendly;
            exotic.IsPetFriendly = updatedExotic.IsPetFriendly;
            exotic.IsLegalInCity = updatedExotic.IsLegalInCity;
            //exotic.ShelterId = updatedExotic.ShelterId;
            exotic.Sterile = updatedExotic.Sterile;
            exotic.IsHypoallergenic = updatedExotic.IsHypoallergenic;

            await _exotic.SaveChangesAsync();

            return Ok("The animals info has been saved");
        }
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteExotic([FromUri] int id)
        {
            Exotic exotic = await _exotic.Exotics.FindAsync(id);
            if (exotic == null)
                return NotFound();

            _exotic.Exotics.Remove(exotic);

            if (await _exotic.SaveChangesAsync() == 1)
            {
                return Ok("The pet has been removed");
            }
            return BadRequest();
        }
    }
}
