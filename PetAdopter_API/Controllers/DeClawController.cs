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
    public class DeclawController : ApiController
    {
        private readonly ApplicationDbContext _domestic = new ApplicationDbContext();
        [HttpPost]
        private DomesticService CreateDomesticService()
        {

            var userId = Guid.Parse(User.Identity.GetUserId());
            var DomesticService = new DomesticService(userId);
            return DomesticService;

        }
        [HttpGet]
        public IHttpActionResult GetByDeclawed()
        {
            DomesticService domesticService = CreateDomesticService();
            var domestic = domesticService.GetDomesticByDeclawed();
            return Ok(domestic);
        }
    }
}
