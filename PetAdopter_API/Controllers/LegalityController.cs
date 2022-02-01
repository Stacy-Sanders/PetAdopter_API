using PetAdopter_API.Data;
using PetAdopter_API.Models;
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
    public class LegalityController : ApiController
    {
        private readonly ApplicationDbContext _exotic = new ApplicationDbContext();

        // GET by Legallity
        // api/Dogs/{isLegal}
        [HttpGet]
        public async Task<IHttpActionResult> GetLegalInCity([FromUri] bool isLegalInCity)
        {
            var exotic = await _exotic.Exotics.Where(x => x.IsLegalInCity == isLegalInCity).ToListAsync();


            if (exotic == null)

            {
                return NotFound();
            }
            return Ok(exotic);
        }
    }
}

