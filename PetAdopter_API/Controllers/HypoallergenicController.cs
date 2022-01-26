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
    public class HypoallergenicController : ApiController
    {
        private readonly ApplicationDbContext _domestic = new ApplicationDbContext();

        // GET by HypoAllergenic
        // api/Dogs/{isHypoallergenic}
        [HttpGet]
        public IHttpActionResult GetHypo()
        {

            List<DomesticTable> hypoDogs = new List<DomesticTable>();
            foreach (DomesticTable dog in _domestic.Domestics)
            {
                if (dog.IsHypoallergenic == true)
                {
                    hypoDogs.Add(dog);
                }
                return (IHttpActionResult)hypoDogs;
            }

            return InternalServerError();

        }
    }
}
