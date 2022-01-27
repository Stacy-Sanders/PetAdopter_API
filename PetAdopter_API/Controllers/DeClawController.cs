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
    public class DeclawController : ApiController
    {
        private readonly ApplicationDbContext _domestic = new ApplicationDbContext();
        
        [HttpGet]
        public async Task<IHttpActionResult> GetDeclawedCats([FromUri] bool isdeclawed)
        {
            var domestic = await _domestic.Domestics.Where(x => x.IsDeclawed == isdeclawed).ToListAsync();

            if (domestic == null)
            {
                return NotFound();
            }
            return Ok(domestic);
        }
    }
}
