using Microsoft.AspNet.Identity;
using PetAdopter_API.Services;
using System;
using System.Web.Http;

namespace PetAdopter_API.Controllers
{
    [Authorize]
    public class PetController : ApiController
    {
        // Create DomesticService
        [HttpPost]
        private DomesticService CreateDomesticService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var DomesticService = new DomesticService(userId);
            return DomesticService;
        }

        // GET by AdopterId
        [HttpGet]
        public IHttpActionResult GetDomesticByAdopterId(int id)
        {

            DomesticService domesticService = CreateDomesticService();
            var domestic = domesticService.GetDomesticByAdopterID(id);
            return Ok(domestic);

        }

        // GET by ShelterId
        [HttpGet]
        public IHttpActionResult GetDomesticByShelterId(int id)
        {

            DomesticService domesticService = CreateDomesticService();
            var domestic = domesticService.GetDomesticByShelterID(id);
            return Ok(domestic);

        }

        // Create ExoticService
        private ExoticService CreateExoticService()
        {

            var userId = Guid.Parse(User.Identity.GetUserId());
            var ExoticService = new ExoticService(userId);
            return ExoticService;

        }

        // GET by AdopterId
        [HttpGet]
        public IHttpActionResult GetExoticByAdopterId(int id)
        {

            ExoticService exoticService = CreateExoticService();
            var exotic = exoticService.GetExoticByAdopterID(id);
            return Ok(exotic);

        }

        // GET by ShelterId
        [HttpGet]
        public IHttpActionResult GetExoticByShelterId(int id)
        {

            ExoticService exoticService = CreateExoticService();
            var exotic = exoticService.GetExoticByShelterID(id);
            return Ok(exotic);

        }
    }
}
