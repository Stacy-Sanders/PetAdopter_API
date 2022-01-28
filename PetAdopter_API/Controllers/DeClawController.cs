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
    public class DeclawController : ApiController
    {
        private readonly ApplicationDbContext _domestic = new ApplicationDbContext();
        [HttpGet]
        public IHttpActionResult GetDeclawedCats()
        {
            List<Domestic> declawedList = new List<Domestic>();
            foreach (Domestic cat in _domestic.Domestics)
            {
                if (cat.IsDeclawed == true)
                {
                    declawedList.Add(cat);
                }
                return (IHttpActionResult)declawedList;
            }
            return InternalServerError();
        }
    }
}
