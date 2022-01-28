using PetAdopter_API.Data;
using PetAdopter_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PetAdopter_API.Controllers
{
    public class LegallityController : ApiController
    {
        private readonly ApplicationDbContext _exotic = new ApplicationDbContext();

        // GET by Legallity
        // api/Dogs/{isLegal}
        [HttpGet]
        public IHttpActionResult GetLegal()
        {

            List<Exotic> legalExotics = new List<Exotic>();
            foreach (Exotic exotic in _exotic.Exotics)
            {
                if (exotic.IsLegalInCity == true)
                {
                    legalExotics.Add(exotic);
                }
                return (IHttpActionResult)legalExotics;
            }

            return InternalServerError();

        }
    }
}

