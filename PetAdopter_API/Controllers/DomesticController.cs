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
    public class DomesticController : ApiController
    {

        // Create DomesticService
        [HttpPost]
        private DomesticService CreateDomesticService()
        {

            var userId = Guid.Parse(User.Identity.GetUserId());
            var DomesticService = new DomesticService(userId);
            return DomesticService;

        }

        // POST
        [HttpPost]
        public IHttpActionResult Post(DomesticCreate domestic)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateDomesticService();

            if (!service.CreateDomestic(domestic))
                return InternalServerError();

            return Ok("New domestic pet has been posted for adoption!");
        }

        // GET ALL
        [HttpGet]
        public IHttpActionResult Get()
        {

            DomesticService domesticService = CreateDomesticService();
            var domestics = domesticService.GetDomestics();
            return Ok(domestics);

        }

        // GET by ID
        [HttpGet]
        public IHttpActionResult Get(int id)
        {

            DomesticService domesticService = CreateDomesticService();
            var domestic = domesticService.GetDomesticById(id);
            return Ok(domestic);

        }

        // Get by Species
        [HttpGet]
        public IHttpActionResult Get(string species)
        {
            DomesticService domesticService = CreateDomesticService();
            var domestics = domesticService.GetDomesticBySpecies(species);
            return Ok(domestics);
        }

        // PUT (update)
        [HttpPut]
        public IHttpActionResult Put(DomesticEdit domestic)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateDomesticService();

            if (!service.UpdateDomestic(domestic))
                return InternalServerError();

            return Ok("Your domestic pet information has been updated.");
        }


        // DELETE
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var service = CreateDomesticService();

            if (!service.DeleteDomestic(id))
                return InternalServerError();

            return Ok("Success. The domestic pet has been deleted from the database.");
        }

    }
}

