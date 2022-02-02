using Microsoft.AspNet.Identity;
using PetAdopter_API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PetAdopter_API.Controllers
{
    [Authorize]
    public class PetController : ApiController
    {
        // Create DomesticService
        [HttpPost]
        private PetService CreatePetService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var PetService = new PetService(userId);
            return PetService;

        }

        // GET by AdopterId
        [HttpGet]
        public IHttpActionResult GetDomesticByAdopterId(int id)
        {

            PetService petService = CreatePetService();
            var domesticPet = petService.GetDomesticByAdopterID(id);
            return Ok(domesticPet);

        }

        // GET by ShelterId
        [HttpGet]
        public IHttpActionResult GetDomesticByShelterId(int id)
        {

            PetService petService = CreatePetService();
            var domesticPet = petService.GetDomesticByShelterID(id);
            return Ok(domesticPet);

        }

        // Get by Species
        [HttpGet]
        public IHttpActionResult GetDomesticBySpecies(string species)
        {
            PetService petService = CreatePetService();
            var domesticPets = petService.GetDomesticBySpecies(species);
            return Ok(domesticPets);
        }

        // Get by Hypoallergenic
        [HttpGet]
        public IHttpActionResult GetDomesticByHypoallergenic(bool isHypoallergenic)
        {
            PetService petService = CreatePetService();
            var domesticPets = petService.GetDomesticByHypoallergenic(isHypoallergenic);
            return Ok(domesticPets);
        }

        // Get by Declawed
        [HttpGet]
        public IHttpActionResult GetDomesticByDeclawed(bool isDeclawed)
        {
            PetService petService = CreatePetService();
            var domesticPets = petService.GetDomesticByDeclawed(isDeclawed);
            return Ok(domesticPets);
        }

        // Get by Declawed
        [HttpGet]
        public IHttpActionResult GetDomesticByHouseTrained(bool isHouseTrained)
        {
            PetService petService = CreatePetService();
            var domesticPets = petService.GetDomesticByHouseTrained(isHouseTrained);
            return Ok(domesticPets);
        }

        // GET by AdopterId
        [HttpGet]
        public IHttpActionResult GetExoticByAdopterId(int id)
        {

            PetService petService = CreatePetService();
            var exoticPet = petService.GetExoticByAdopterID(id);
            return Ok(exoticPet);

        }

        // GET by ShelterId
        [HttpGet]
        public IHttpActionResult GetExoticByShelterId(int id)
        {

            PetService petService = CreatePetService();
            var exoticPet = petService.GetExoticByShelterID(id);
            return Ok(exoticPet);

        }

        // Get by Species
        [HttpGet]
        public IHttpActionResult GetExoticBySpecies(string species)
        {
            PetService petService = CreatePetService();
            var exoticPets = petService.GetExoticBySpecies(species);
            return Ok(exoticPets);
        }

        // Get by Legality
        [HttpGet]
        public IHttpActionResult GetExoticByLegal(bool isLegalInCity)
        {
            PetService petService = CreatePetService();
            var exoticPets = petService.GetExoticByLegality(isLegalInCity);
            return Ok(exoticPets);
        }

        // Get by Hypoallergenic
        [HttpGet]
        public IHttpActionResult GetExoticByHypoallergenic(bool isHypoallergenic)
        {
            PetService petService = CreatePetService();
            var exoticPets = petService.GetExoticByHypoallergenic(isHypoallergenic);
            return Ok(exoticPets);
        }


    }
}


