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
    public class ShelterController : ApiController
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();


        //Post(Create)
        [HttpPost]
        public async Task<IHttpActionResult> CreateShelter([FromBody] Shelter model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("You need a request body");
            }
            if (ModelState.IsValid)
            {
                _context.Shelters.Add(model);
                int changeCount = await _context.SaveChangesAsync();
                return Ok();
            }
            return BadRequest(ModelState);
        }

        //Get All
        [HttpGet]
        public async Task<IHttpActionResult> GetAll()
        {
            List<Shelter> shelters = await _context.Shelters.ToListAsync();
            return Ok(shelters);
        }

        //Get By ID
        [HttpGet]
        public async Task<IHttpActionResult> GetById([FromUri] int id)
        {
            Shelter shelter = await _context.Shelters.FindAsync(id);

            if (shelter != null)
            {
                return Ok(shelter);
            }
            return NotFound();
        }

        //Put (update)
        [HttpPut]
        public async Task<IHttpActionResult> UpdateShelter([FromBody] int id, [FromBody] Shelter updatedShelter)
        {
            if (id != updatedShelter?.ShelterId)
            {
                return BadRequest("Ids do not match.");
            }
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Shelter shelter = await _context.Shelters.FindAsync(id);

            if (shelter is null)
                return NotFound();

            shelter.ShelterName = updatedShelter.ShelterName;
            shelter.State = updatedShelter.State;
            shelter.City = updatedShelter.City;
            shelter.Rating = updatedShelter.Rating;

            await _context.SaveChangesAsync();

            return Ok("The shelter was updated");
        }

        //Delete (delete)
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteShelter([FromUri] int id)
        {
            Shelter shelter = await _context.Shelters.FindAsync(id);
            if (shelter is null)
                return NotFound();

            _context.Shelters.Remove(shelter);

            if (await _context.SaveChangesAsync() == 1)
            {
                return Ok("The shelter was deleted");
            }

            return InternalServerError();
        }
    }
}
