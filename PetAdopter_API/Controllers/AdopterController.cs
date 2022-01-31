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

    public class AdopterController : ApiController
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();


        //Post(Create)
        [HttpPost]
        private AdopterService CreateAdopterService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var AdopterService = new AdopterService(userId);
            return AdopterService;
        
        
        }

        //Get All
        [HttpPost]
        public IHttpActionResult GetAll(AdopterCreate adopter)
        {

            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            var service = CreateAdopterService();
            if (!service.AdopterCreate(adopter)) { return InternalServerError(); }
            return Ok($"New Adopter {adopter.AdopterId} created!");
        }

        //Get By ID
        [HttpGet]
        public IHttpActionResult Get( int id)
        {
            AdopterService service = CreateAdopterService();
            var adopter = service.GetAdopterById(id);
            return Ok(adopter);
        }

        //Put (update)
        [HttpPut]

        public IHttpActionResult Put([FromUri] int id, [FromBody] AdopterEdit updatedAdopter)

        {
            
            if (!ModelState.IsValid)return BadRequest(ModelState);

            var service = CreateAdopterService();

            if (!service.UpdateAdopter(updatedAdopter))return InternalServerError();

            return Ok($" {updatedAdopter} was updated");

        }

        //Delete (delete)
        
        public IHttpActionResult Delete( int id)
        {
            var service = CreateAdopterService();
            if (!service.DeleteAdopter(id))return InternalServerError();
            return Ok($"Successfully Deleted Adopter {id} ");
        }
    }
}

