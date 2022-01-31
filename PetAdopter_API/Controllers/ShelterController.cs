using Microsoft.AspNet.Identity;
using PetAdopter_API.Data;
using PetAdopter_API.Models;
using PetAdopter_API.Services;
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

        //Post
        //Create shelter service to be used for other methods
        private ShelterService CreateShelterService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var ShelterService = new ShelterService(userId);
            return ShelterService;
        }

        [HttpPost]
        public IHttpActionResult CreateShelter(ShelterCreate shelter)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            var service = CreateShelterService();
            if (!service.CreateShelter(shelter)) { return InternalServerError(); }
            return Ok($"Shelter '{shelter.ShelterName}' has been added to the database.");
        }

        //Get all shelters
        [HttpGet]
        public IHttpActionResult Get()
        {
            ShelterService shelterService = CreateShelterService();
            var shelter = shelterService.GetShelters();
            return Ok(shelter);
        }
        //Get shelters by Id
        public IHttpActionResult GetShelterById(int id)
        {
            ShelterService service = CreateShelterService();
            var shelter = service.GetShelterById(id);
            return Ok(shelter);
        }
        [HttpPut]
        public IHttpActionResult Put([FromUri] ShelterEdit updateShelter)
        {
            if (!ModelState.IsValid)return BadRequest(ModelState);
            var service = CreateShelterService();
            if (!service.UpdateShelter(updateShelter))return InternalServerError();
            return Ok($"Shelter '{updateShelter.ShelterName}' has been updated.");
        }
        public IHttpActionResult Delete (int id)
        {
            var service = CreateShelterService();
            if (!service.DeleteShelter(id))return InternalServerError();
            return Ok("Shelter Deleted");
        }
    }
}
