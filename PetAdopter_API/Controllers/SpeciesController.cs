using Microsoft.AspNet.Identity;
using PetAdopter_API.Models.Species;
using PetAdopter_API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PetAdopter_API.Controllers
{
    public class SpeciesController : ApiController
    {
        private SpeciesService CreateSpeciesService()
        {

            var userId = Guid.Parse(User.Identity.GetUserId());
            var SpeciesService = new SpeciesService(userId);
            return SpeciesService;

        }
        [HttpGet]
        public IHttpActionResult Get([FromBody]SpeciesListItem species)
        {

            SpeciesService speciesService = CreateSpeciesService();
            var domestic = speciesService.GetSpecies(species);
            return Ok(domestic);

        }
    }
}
