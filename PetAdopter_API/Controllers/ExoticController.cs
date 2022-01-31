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
    public class ExoticController : ApiController
    {

        // Create ExoticService
        private ExoticService CreateExoticService()
        {

            var userId = Guid.Parse(User.Identity.GetUserId());
            var ExoticService = new ExoticService(userId);
            return ExoticService;

        }

        // POST
        public IHttpActionResult Post(ExoticCreate exotic)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateExoticService();

            if (!service.CreateExotic(exotic))
                return InternalServerError();

            return Ok("New exotic pet has been posted for adoption!");
        }

        // GET ALL
        public IHttpActionResult Get()
        {

            ExoticService exoticService = CreateExoticService();
            var exotics = exoticService.GetExotics();
            return Ok(exotics);

        }

        // GET by ID
        public IHttpActionResult Get(int id)
        {

            ExoticService exoticService = CreateExoticService();
            var exotic = exoticService.GetExoticById(id);
            return Ok(exotic);

        }

        // PUT (update)
        public IHttpActionResult Put(ExoticEdit exotic)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            var service = CreateExoticService();

            if (!service.UpdateExotic(exotic))
                return InternalServerError();

            return Ok("Your Exotic pet information has been updated.");

        }

        // DELETE
        public IHttpActionResult Delete(int id)
        {
            var service = CreateExoticService();

            if (!service.DeleteExotic(id))
                return InternalServerError();

            return Ok("Success. The Exotic pet has been deleted from the database.");
        }

    } 
}
