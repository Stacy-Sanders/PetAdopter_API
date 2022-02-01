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
    public class LegalityController : ApiController
    {

        // Post
        // Create Legality Service
        [HttpPost]
        private LegalityService CreateLegalityService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var LegalityService = new LegalityService(userId);
            return LegalityService;
        }

        // GET by Legality
        // api/Legality
        [HttpGet]
        public IHttpActionResult Get()
        {
            LegalityService legalityService = CreateLegalityService();
            var legal = legalityService.GetLegalInCity();
            return Ok(legal);
        }
            
    }
}
        

