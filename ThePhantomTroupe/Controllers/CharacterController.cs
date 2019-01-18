using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ThePhantomTroupe.Models;
using ThePhantomTroupe.Repository;

namespace ThePhantomTroupe.Controllers
{
    public class CharacterController : ApiController
    {
        [HttpGet]
        [Route("api/characters")]
        [ResponseType(typeof(List<RaiderIOCharacter>))]
        public HttpResponseMessage GetCharacter()
        {
            var result = new RaiderIoRepository().GetRaiderIOCharacters();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }


        [HttpGet]
        [Route("api/characters/{name}")]
        [ResponseType(typeof(RaiderIOCharacter))]
        public HttpResponseMessage GetCharacter(string name)
        {
            var result = new RaiderIoRepository().GetRaiderIOCharacter(name);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
    }
}
