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
    public class HypoallergenicController : ApiController
    {
        private readonly ApplicationDbContext _domestic = new ApplicationDbContext();

        // GET by HypoAllergenic
        // api/Dogs/{isHypoallergenic}
        [HttpGet]
        public async Task<IHttpActionResult> GetHypoallergenic([FromUri] bool ishypoallergenic)
        {
            var domestic = await _domestic.Domestics.Where(x => x.IsHypoallergenic == ishypoallergenic).ToListAsync();

            if (domestic == null)
            {
                return NotFound();
            }
            return Ok(domestic);
        }
    }
}
