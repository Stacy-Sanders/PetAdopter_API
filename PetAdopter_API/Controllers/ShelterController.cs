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
    [Authorize]
    public class ShelterController : ApiController
    {

        //Post
        //Create shelter service to be used for other methods
        [HttpPost]
        private ShelterService CreateShelterService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var ShelterService = new ShelterService(userId);
            return ShelterService;
        }

        [HttpPost]
        public IHttpActionResult CreateShelter(ShelterCreate shelter)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            var service = CreateShelterService();

            if (!service.CreateShelter(shelter)) 
                return InternalServerError();

            return Ok($"Shelter '{shelter.Name}' has been added to the database.");
        }

        //Get all shelters
        [HttpGet]
        public IHttpActionResult Get()
        {
            ShelterService shelterService = CreateShelterService();
            var shelters = shelterService.GetShelters();
            return Ok(shelters);
        }

        //Get shelters by Id
        [HttpGet]
        public IHttpActionResult GetShelterById(int id)
        {
            ShelterService shelterService = CreateShelterService();
            var shelter = shelterService.GetShelterById(id);
            return Ok(shelter);
        }

        [HttpPut]
        public IHttpActionResult Put(ShelterEdit shelter)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateShelterService();

            if (!service.UpdateShelter(shelter))
                return InternalServerError();

            return Ok($"Shelter '{shelter.Name}' has been updated.");
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var service = CreateShelterService();

            if (!service.DeleteShelter(id))
                return InternalServerError();

            return Ok("Shelter Deleted");
        }
    }
}
